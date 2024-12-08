using System.Text.Json;

namespace DigiGall.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public String TeamName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public int Galleon {get; set;}
        public int Rank { get; set; }

        public User(string name, string teamName, string email, string password)
        {
            this.Name = name;
            this.TeamName = teamName;
            this.Email = email;
            this.Password = password;
            this.Galleon = 0;
            this.Rank = 1;
        }
    }
}
