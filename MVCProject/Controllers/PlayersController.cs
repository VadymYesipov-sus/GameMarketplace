using InterviewMVCProject.Data;
using InterviewMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject.Filters;
using MVCProject.Interfaces;

namespace InterviewMVCProject.Controllers
{
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class PlayersController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ClassOptions = new List<SelectListItem>
                {
                new SelectListItem { Value = "Warrior", Text = "Warrior" },
                new SelectListItem { Value = "Mage", Text = "Mage" },
                new SelectListItem { Value = "Rogue", Text = "Rogue" }
                };

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Player player)
        {
            await _playerService.CreateAsync(player);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ServiceFilter(typeof(CheckIfExistsFilter<Player>))]
        [Route("Players/Edit/{playerId}")]
        public async Task<IActionResult> Edit(int playerId)
        {
            var player = await _playerService.GetByIdAsync(playerId);
            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Player editPlayer)
        {
            var player = await _playerService.EditAsync(editPlayer);
            return RedirectToAction("Details", "Players", new { id = editPlayer.PlayerId });
        }

        [HttpGet]
        [ServiceFilter(typeof(CheckIfExistsFilter<Player>))]
        [Route("Players/Delete/{playerId}")]
        public async Task<IActionResult> Delete(int playerId)
        {
            var player = await _playerService.GetByIdAsync(playerId);
            return View(player);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            await _playerService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Players/Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var player = await _playerService.DetailsAsync(id);
            return View(player);
        }

        //method created for API testing
        [HttpGet("api/players")]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _playerService.GetAllAsync();
            return Ok(players);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _playerService.GetAllAsync());
        }
    }
}
