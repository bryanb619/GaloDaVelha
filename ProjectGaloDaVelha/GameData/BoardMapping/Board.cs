namespace ProjectGaloDaVelha.GameData.BoardMapping
{

    /// <summary>
    /// Class that represents the game board layout
    /// stores and protects board layout from outside access
    /// /// </summary>
    public class Board 
    {   
        // board layout
        private string[,] boardMap =
        {
            {"A","B","C","D"},
            {"E","F","G","H"},
            {"I","J","K","L"},
            {"M","N","O","P"}
        };

        /// <summary>
        /// Getter for the board map
        /// this is a visual representation of the board
        /// </summary>
        /// <returns>returns board layout as bidimensional array</returns>
        public string[,] GetBoard()
        {
            // board layout
            return boardMap;
        }

    }

}

