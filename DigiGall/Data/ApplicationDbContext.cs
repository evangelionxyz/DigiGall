using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DigiGall.Models;

namespace DigiGall.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public async Task<List<string>> GetUserNameAsync()
        {
            return await User.Select(u => u.Name).ToListAsync();
        }

        //public async Task<List<Transaction>> GetAllTransactionWith(string status, string userId, string type)
        public async Task<List<Transaction>> GetAllTransactionWith(string status)
        {
            return await Transaction
                //.Where(t => t.Status == status && t.UserId == userId && t.Type == type)
                .Where(t => t.Status == status)
                .ToListAsync();
        }

        public DbSet<Models.User> User { get; set; } = default!;
        public DbSet<Models.Quest> Quest { get; set; } = default!;
        public DbSet<Models.UserQuest> UserQuest { get; set; } = default!;
        public DbSet<Models.Transaction> Transaction { get; set; } = default!;

        public Models.Quest? SelectedQuest = null;
    }
}