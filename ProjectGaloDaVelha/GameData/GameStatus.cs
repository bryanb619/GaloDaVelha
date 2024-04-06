namespace ProjectGaloDaVelha.GameData
{
    /// <summary>
    /// Enumerator defines the status of the game
    /// </summary>
    public enum GameStatus
    {
        /// <summary>
        ///  Player 1 win condition
        /// </summary>
        player1Win,

        /// <summary>
        ///  Player 2 win condition
        /// </summary>
        player2Win,

        /// <summary>
        /// Game draw condition
        /// use to check and apply game as draw
        /// </summary>
        draw,

        /// <summary>
        /// Game exit condition
        /// Use this to exit the game
        /// </summary>
        exit,

        /// <summary>
        /// Playing condition
        /// only used to start game and maintain game loop
        /// </summary>
        playing
    }
}