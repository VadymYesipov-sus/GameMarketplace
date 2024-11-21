using InterviewMVCProject.Data;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Services;

namespace InterviewMVCProject.Controllers
{
    public class GuildsController : Controller
    {
        private readonly GuildService _guildService;

        public GuildsController(GuildService guildService)
        {
            _guildService = guildService;
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
