namespace ProjectGaloDaVelha.GameData.BoardMapping
{

    /// <summary>
    /// Class that represents the game board
    ///  
    /// /// </summary>
    public class Board 
    {
        private string[,] boardMap =
        {
            {"A","B","C","D"},
            {"E","F","G","H"},
            {"I","J","K","L"},
            {"M","N","O","P"}
        };

        /// <summary>
        ///  
        /// </summary>
        /// <returns>returns board layout</returns>
        public string[,] GetBoard()
        {
            // board layout
            return boardMap;
        }

    }

}

