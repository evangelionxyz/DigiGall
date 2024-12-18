using System.Diagnostics;
using DigiGall.Data;
using DigiGall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DigiGall.Controllers
{
    public class HomeController : BaseController
    {
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

            // dummy
            //_dbContext.Quest.Add(new Quest(Guid.NewGuid().ToString(), "Quest 0", "Test", 10));
            //_dbContext.Quest.Add(new Quest(Guid.NewGuid().ToString(), "Quest 1", "Test", 12));
            //_dbContext.Quest.Add(new Quest(Guid.NewGuid().ToString(), "Quest 2", "Test", 13));
            //_dbContext.Quest.Add(new Quest(Guid.NewGuid().ToString(), "Quest 3", "Test", 112));
            //_dbContext.Quest.Add(new Quest(Guid.NewGuid().ToString(), "Quest 4", "Test", 14));
            //_dbContext.Quest.Add(new Quest(Guid.NewGuid().ToString(), "Quest 5", "Test", 17));
            //_dbContext.Quest.Add(new Quest(Guid.NewGuid().ToString(), "Quest 6", "Test", 16));
            //_dbContext.Quest.Add(new Quest(Guid.NewGuid().ToString(), "Quest 7", "Test", 10));
            //_dbContext.SaveChanges();

            return View();
        }

        public async Task<IActionResult> Quests()
        {
            var quests = await _dbContext.Quest.ToListAsync();
            return View(quests);
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult QuestDetails(string id)
        {
            var quest = _dbContext.Quest.FirstOrDefault(q => q.Id == id);
            if (quest == null)
            {
                return NotFound();
            }

            return View(quest);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
