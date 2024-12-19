using DigiGall.Data;
using DigiGall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace DigiGall.Controllers
{
    public class AdminController : BaseController
    {

        public AdminController(UserContextService userContextService, ApplicationDbContext dbContext)
            : base(userContextService, dbContext)
        {
        }

        public async Task<IActionResult> Index(AdminViewState? state)
        {
            var users = await _dbContext.User
                 .Where(u => u.House != "Slytherin")
                 .ToListAsync();

            var transactions = await _dbContext.Transaction.ToListAsync();

            var viewModel = new AdminViewModel
            {
                State = state ?? AdminViewState.AddDigiGall,
                Users = users,
                Transactions = transactions
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGalleon(string userId, int galleon)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                user.Galleon += galleon;
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
