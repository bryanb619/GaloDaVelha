using ProjectGaloDaVelha.GameData;

namespace ProjectGaloDaVelha
{
    /// <summary>
    ///  Simple Program class that creates instance of game class
    ///  and calls the start method, starting the GaloDaVelha game
    /// </summary>
    class Program
    {
        
        /// <summary>
        ///  Main initializes Program
        ///  Declares a instance of Game class
        ///  Calls the Start method of the Game class
        ///  Starts game (GaloDaVelha) Game class
        /// /// </summary>
        /// <param name="args">Not used</param>
        private static void Main(string[] args)
        {
            // create a game instance
            Game game = new Game();
            
            // start game method
            game.Start();

            
        }
    }
}
