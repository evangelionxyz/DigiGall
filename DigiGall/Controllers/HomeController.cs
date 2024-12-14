using System.Diagnostics;
using DigiGall.Data;
using DigiGall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DigiGall.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext dbContext, ILogger<HomeController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId.IsNullOrEmpty())
            {
                return RedirectToAction("Login", "Auth");
            }

            _dbContext.CurrentUser = _dbContext.User.FirstOrDefault(u => u.Id == userId);
            return View();
        }

        public IActionResult Quests()
        {
            var userId = HttpContext.Session.GetString("UserId");
            _dbContext.CurrentUser = _dbContext.User.FirstOrDefault(u => u.Id == userId);
            return View();
        }

        public IActionResult History()
        {
            var userId = HttpContext.Session.GetString("UserId");
            _dbContext.CurrentUser = _dbContext.User.FirstOrDefault(u => u.Id == userId);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
