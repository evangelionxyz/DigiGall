using System.Text.Json;

namespace DigiGall.Models
{
    public class User
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string TeamName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int Galleon { get; set; } = 0;
        public int Rank { get; set; } = 1;

        public User() { 
        }

        public User(string id, string name, string teamName, string email, string password)
        {
            Id = id;
            Name = name;
            TeamName = teamName;
            Email = email;
            Password = password;
        }
    }
}
