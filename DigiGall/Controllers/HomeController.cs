using System.Diagnostics;
using DigiGall.Data;
using DigiGall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DigiGall.Controllers
{
    public class HomeController : BaseController
    {

        List<Quest> quests = new List<Quest>();

        public HomeController(UserContextService userContextService, ApplicationDbContext dbContext)
            : base(userContextService, dbContext)
        {
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId.IsNullOrEmpty())
            {
                return RedirectToAction("Login", "Auth");
            }

            quests.Add(new Quest(Guid.NewGuid().ToString(), "Quest 0", "Test", 10));
            quests.Add(new Quest(Guid.NewGuid().ToString(), "Quest 1", "Test", 12));
            quests.Add(new Quest(Guid.NewGuid().ToString(), "Quest 2", "Test", 13));

            return View();
        }

        public IActionResult Quests()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
