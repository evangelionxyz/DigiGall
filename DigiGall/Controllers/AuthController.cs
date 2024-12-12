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
            // check if the username or email already exist
            bool usernameExists = _dbContext.User.Any(u => u.Name == model.Name);
            bool emailExists = _dbContext.User.Any(u => u.Email == model.Email);

            if (usernameExists || emailExists)
            {
                if (usernameExists)
                    ModelState.AddModelError(nameof(model.Name), "Username is already taken.");
                if (emailExists)
                    ModelState.AddModelError(nameof(model.Email), "Email is already registered.");

                return View(model);
            }

            // proceed to create a new user
            string newId = Guid.NewGuid().ToString();
            User newUser = new User(newId, model.Name, model.Email, model.Password, model.Phone, model.DateOfBirth);
            
            _dbContext.User.Add(newUser);
            _dbContext.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            var foundUser = _dbContext.User.FirstOrDefault(u =>
                (u.Email == model.Email) && u.Password == model.Password);

            if (foundUser == null)
            {
                ModelState.AddModelError("Email", "Invalid email or password");
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
