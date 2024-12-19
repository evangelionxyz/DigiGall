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

            if (currentUser != null)
            {
                if (currentUser.House == "Slytherin")
                {
                    return RedirectToAction("Index", "Admin");
                }
            }

            ////dummy
            //_dbContext.Quest.Add(new Quest("Quest 0", "Test", 10));
            //_dbContext.Quest.Add(new Quest("Quest 1", "Test", 12));
            //_dbContext.Quest.Add(new Quest("Quest 2", "Test", 13));
            //_dbContext.Quest.Add(new Quest("Quest 3", "Test", 112));
            //_dbContext.Quest.Add(new Quest("Quest 4", "Test", 14));
            //_dbContext.Quest.Add(new Quest("Quest 5", "Test", 17));
            //_dbContext.Quest.Add(new Quest("Quest 6", "Test", 16));
            //_dbContext.Quest.Add(new Quest("Quest 7", "Test", 10));
            //_dbContext.SaveChanges();

            return View();
        }

        public async Task<IActionResult> Quests()
        {
            var globalQuests = await _dbContext.Quest.ToListAsync(); // all quests from database

            if (currentUser == null)
            {
                return NotFound();
            }

            var userQuests = await _dbContext.UserQuest
                .Where(uq => uq.UserId == currentUser.Id)
                .ToListAsync();

            var missionQuests = globalQuests
                .Where(gq => !userQuests.Any(uq => uq.TargetId == gq.Id))
                .ToList();

            foreach (var quest in missionQuests)
            {
                var newUserQuest = new UserQuest
                {
                    TargetId = quest.Id,
                    UserId = currentUser.Id,
                    Status = "Available"
                };
                _dbContext.UserQuest.Add(newUserQuest);
                userQuests.Add(newUserQuest);
            }

            await _dbContext.SaveChangesAsync();

            var questDetails = globalQuests.Select(gq => new QuestViewModel
            {
                Quest = gq,
                UserQuest = userQuests.FirstOrDefault(uq => uq.TargetId == gq.Id)
            }).ToList();

            return View(questDetails);
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

        public IActionResult ApplyQuest(string targetQuestId)
        {
            if (currentUser != null)
            {
                var selectedUserQuest = _dbContext.UserQuest.FirstOrDefault(q => q.TargetId == targetQuestId);
                var globalQuest = _dbContext.Quest.FirstOrDefault(q => q.Id == targetQuestId);
                if (selectedUserQuest != null && globalQuest != null)
                {
                    selectedUserQuest.Status = "UnderReview";
                    Transaction newTransaction = new Transaction(targetQuestId, "Quest");
                    newTransaction.Description = "Ini deskripsi";
                    newTransaction.Title = "Requesting " + globalQuest.Title;
                    _dbContext.Transaction.Add(newTransaction);
                    _dbContext.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ActionQuestAvailable(int amount)
        {
            if (currentUser != null)
            {
                currentUser.Galleon += amount;
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("UserId", "");
            return RedirectToAction("Login", "Auth");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
