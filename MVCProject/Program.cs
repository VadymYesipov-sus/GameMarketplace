using InterviewMVCProject.Data;
using InterviewMVCProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVCProject.Filters;
using MVCProject.Interfaces;
using MVCProject.Repositories;
using MVCProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddScoped<GlobalExceptionFilter>();
builder.Services.AddScoped<IEntityService<Player>, PlayerService>();
//builder.Services.AddScoped<IEntityService<Item>, ItemService>();
builder.Services.AddScoped<CheckIfExistsFilter<Player>>();
builder.Services.AddScoped<CheckIfExistsFilter<Item>>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowLocalhost3000");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
