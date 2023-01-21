
namespace jogoDaVelha.Models
{
    public class Game
    {
        private static List<Player> _Players;
      
        public Game()
        {
            _Players = new List<Player>();
        }

        public static void AddPlayer(Player player)
        {
            _Players.Add(player);
        }

        public static Player? FindPlayer(string username)
        {
            Player player = _Players.Find(player => player.Username == username);
            
            if(player != null)
                return player;
    
            return null;    
        }
    }
}
