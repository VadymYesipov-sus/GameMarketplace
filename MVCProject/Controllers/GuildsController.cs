using InterviewMVCProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace InterviewMVCProject.Controllers
{
    public class GuildsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuildsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
