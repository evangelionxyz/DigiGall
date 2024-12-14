using DigiGall.Data;
using Microsoft.AspNetCore.Mvc;
using DigiGall.Models;

namespace DigiGall.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            bool usernameExists = _dbContext.User.Any(u => u.Name == model.Name);
            if (usernameExists)
            {
                ModelState.AddModelError("Name", "Username is already taken.");
                return View(model);
            }

            string newId = Guid.NewGuid().ToString();
            model.House = "Gryffindor";
            User newUser = new User(newId, model.Name, model.Password, model.House, model.Phone, model.DateOfBirth);
            
            _dbContext.User.Add(newUser);
            _dbContext.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            var foundUser = _dbContext.User.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);

            if (foundUser == null)
            {
                ModelState.AddModelError("Name", "Invalid username or password");
                return View(model);
            }

            HttpContext.Session.SetString("UserId", foundUser.Id);
            HttpContext.Session.SetString("UserName", foundUser.Name);

            // parameter: Action, Controller
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Account()
        {
            var userId = HttpContext.Session.GetString("UserId");
            _dbContext.CurrentUser = _dbContext.User.FirstOrDefault(u => u.Id == userId);
            return View(_dbContext.CurrentUser);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }

}
