using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<DigiGall.Models.User> User { get; set; } = default!;
    }
}
