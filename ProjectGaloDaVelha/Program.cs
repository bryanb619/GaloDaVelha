using ProjectGaloDaVelha.Game;

namespace ProjectGaloDaVelha
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="args">Not used</param>
        private static void Main(string[] args)
        {

            // create game instance
            Game.Game game = new Game.Game();
            
            // start game instance
            game.Start();

            
        }
    }
}
