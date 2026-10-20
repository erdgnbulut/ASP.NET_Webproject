using Microsoft.AspNetCore.Identity;

namespace efcoreApp.Data
{
    public class UserGame
    {
        public string UserId {get; set;} = null!;
        public User User {get; set;} = null!;

        public int GamesId {get; set;} 
        public Game Game {get; set;} = null!;
    }
}