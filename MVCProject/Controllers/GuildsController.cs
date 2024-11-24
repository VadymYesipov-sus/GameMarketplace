using InterviewMVCProject.Data;
using InterviewMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Filters;
using MVCProject.Interfaces;

namespace InterviewMVCProject.Controllers
{
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class GuildsController : Controller
    {
        private readonly IGuildService _guildService;

        public GuildsController(IGuildService guildService)
        {
            _guildService = guildService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _guildService.GetAllAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create (Guild guild)
        {
            await _guildService.CreateAsync(guild);
            return RedirectToAction("Index");
        }



    }
}
