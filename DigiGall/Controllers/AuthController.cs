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
            User newUser = new User(newId, model.Name, model.TeamName, model.Email, model.Password);
            
            _dbContext.User.Add(newUser);
            _dbContext.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            var foundUser = _dbContext.User.FirstOrDefault(u =>
                (u.Name == model.Name || u.Email == model.Name) &&
                u.Password == model.Password
            );

            if (foundUser == null)
            {
                ModelState.AddModelError("Name", "Invalid username/email or password");
                return View(model);
            }

            _dbContext.CurrentUser = new User
            {
                Id = foundUser.Id,
                Name = foundUser.Name,
                Email = foundUser.Email,
                Password = foundUser.Password,
                TeamName = foundUser.TeamName,
                Rank = foundUser.Rank,
                Galleon = foundUser.Galleon
            };

            // parameter: Action, Controller
            return RedirectToAction("Index", "Home");
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
