using System;
using System.Threading.Tasks;


namespace AsyncAwaitClarification
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task<Player> playerTask = GetPlayerAsync();
          
        }

        class Player
        {
            public string Name { get; set; }
            public string Value { get; set; }

            public Player(string name, string value)
            {
                name = Name;
                value = Value;
            }

            public static Task<Player> GetPlayerAsync(string name, string value)
            {
                Player p = new Player(name, value);
        
            }
        }
    }
}
