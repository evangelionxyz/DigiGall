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
        
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
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

                return View();
            }

            // proceed to create a new user
            string newId = Guid.NewGuid().ToString();
            User newUser = new User(newId, model.Name, model.TeamName, model.Email, model.Password);
            
            _dbContext.User.Add(newUser);
            _dbContext.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
