namespace ProjectGaloDaVelha.GameData.BoardMapping
{
    public class Board 
    {
        private string[,] boardMap =
        {
            {"A","B","C","D"},
            {"E","F","G","H"},
            {"I","J","K","L"},
            {"M","N","O","P"}
        };

        public string[,] GetBoard()
        {
            return boardMap;
        }
    }

}

