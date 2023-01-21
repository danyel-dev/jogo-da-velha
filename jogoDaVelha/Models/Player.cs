
namespace jogoDaVelha.Models
{
    public class Player
    {
        public string? Full_name { get; set; }
        public string? Username { get; set; }
        public string? Password { private get; set; }

        public Player(string full_name, string username, string password)
        {
            Full_name = full_name;
            Username = username;
            Password = password;
        }
    }
}
