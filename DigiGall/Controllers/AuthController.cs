using Microsoft.AspNetCore.Mvc;
using DigiGall.Models;

namespace DigiGall.Controllers
{
    public class AuthController : Controller
    {
        private static List<User> users = new List<User>();

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string Name, string Email, string Password, string TeamName)
        {
            int newId = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;

            User newUser = new User(Name, TeamName, Email, Password)
            {
                Id = newId
            };

            users.Add(newUser);
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
