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

        public DbSet<Models.User> User { get; set; } = default!;
        public DbSet<Models.Quest> Quest { get; set; } = default!;

        public DbSet<Models.UserQuest> UserQuest { get; set; } = default!;
        public DbSet<Models.Prefect> Prefect { get; set; } = default!;
        public DbSet<Models.Transaction> Transaction { get; set; } = default!;

        public Models.Quest? SelectedQuest = null;
    }
}
