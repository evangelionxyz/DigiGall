using System.Text.Json;

namespace DigiGall.Models
{
    public class User
    {
        public String Id { get; set; }
        public string Name { get; private set; }
        public String TeamName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public int Galleon { get; set; } = 0;
        public int Rank { get; set; } = 1;

        public User() { }

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
