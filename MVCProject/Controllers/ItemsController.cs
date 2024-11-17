using InterviewMVCProject.Data;
using InterviewMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InterviewMVCProject.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create(int ownerId)
        {
            ViewBag.PlayerId = ownerId;

            ViewBag.RarityOptions = new List<SelectListItem>
            {
            new SelectListItem { Value = "Common", Text = "Common" },
            new SelectListItem { Value = "Uncommon", Text = "Uncommon" },
            new SelectListItem { Value = "Rare", Text = "Rare" },
            new SelectListItem { Value = "Epic", Text = "Epic"},
            new SelectListItem { Value = "Legendary", Text = "Legendary"}
            };

            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item item, int ownerId)
        {

            if (ModelState.IsValid)
            {
                item.PlayerId = ownerId;
                Console.WriteLine($"Owner ID: {ownerId}, Player ID: {item.PlayerId}");
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Players", new { id = ownerId });
            }
            return View(item);
        }



        public IActionResult Index()
        {
            return View();
        }


    }
}
