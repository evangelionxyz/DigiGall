using DigiGall.Data;
using Microsoft.AspNetCore.Mvc;
using DigiGall.Models;

namespace DigiGall.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string Name, string Email, string Password, string TeamName)
        {
            string newId = Guid.NewGuid().ToString();
            User newUser = new User(newId, Name, TeamName, Email, Password);
            
            // TODO: save the user data to database
            _context.User.Add(newUser);
            _context.SaveChanges();
            
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
