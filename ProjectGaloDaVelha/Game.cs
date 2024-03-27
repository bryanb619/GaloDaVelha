using System;


namespace ProjectGaloDaVelha
{
    
    public class Game
    {
        // Board mapping // consider static variables
        private Pieces[,] gameBoard = new Pieces[3, 3];

        private int turn = 0;


        private GameStatus gameStatus;

        // ref to PieceSize enum
        private PieceSize size;

        // ref to PieceColor enum
        private PieceColor color;

        // ref to PieceShape enum
        private PieceShape shape;

        // ref to PiecePuncture enum
        private PiecePuncture puncture;

        public void Start()
        {

            Console.WriteLine("Welcome to Galo da Velha!");

            // TEST CODE

            // EXAMPLE OF PIECE CREATION => INSTACIATING
            Pieces piece1 = new Pieces
            (PieceSize.small, PieceColor.color1, PieceShape.circle, PiecePuncture.none);

            // EXAMPLE OF GETTING INFO FROM PIECE
            Console.WriteLine
            ($"Piece size:{piece1.GetPieceSize()} " 
            + $"{piece1.GetPieceColor()} Shape: {piece1.GetPieceShape()} "
            + $"Puncture: {piece1.GetPiecePuncture()}");
            // -----------------------------------------------------------------

            //Console.ReadLine();


            //BuildBoard();
            DisplayBoardUI();
            //ManageTurns();
            //CheckGameStatus();
            //EndGame();
        }
        //----------------------------------------------------------------------

        private void ManageTurns()
        {
            
            while(gameStatus == GameStatus.playing)
            {
                // increment turn
                turn++;

                // determine player turn
                if(turn % 2 != 0)
                {
                    // Player 1 turn
                    MovePiece(Player.player1);
                }
                else
                {
                    // Player 2 turn
                    MovePiece(Player.player2);
                }

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">Enum received to set player move piece</param>
        private void MovePiece(Player player)
        {

            // Get player input
            Console.ReadLine();

            // check for valid input, move & piece type(size, color,shape,hole)

            // update game board

        }


        /// <summary>
        ///  TODO: Must clear board and reset game status
        /// </summary>
        private void Condition(GameStatus gameStatus)
        {
            switch (gameStatus)
            {
                // Player 1 wins
                case GameStatus.player1Win:
                {
                    EndGame("Player 1 wins!"); 

                    break;
                }
                
                // Player 2 wins
                case GameStatus.player2Win:
                {
                    EndGame("Player 2 wins!"); 

                    break;
                }
                   
                // Draw
                case GameStatus.draw:
                {
                    EndGame("It's a draw!"); 
                    
                    break;
                }
                
               // default: {Console.WriteLine("Unkown State"); break;} 
            }
        }

        //----------------------------------------------------------------------


        private void DisplayBoardUI()
        { 
            //"\u001b[32m  VERDE  ||| "\u001b[33m  AMARELO 

            string G_circ_S_furo_BIG = "\u001b[32m\u25cfB";
            string G_circ_C_furo_BIG = "\u001b[32m\u25cbB";
            string G_quad_C_furo_BIG = "\u001b[32m\u25a0B";
            string G_quad_S_furo_BIG = "\u001b[32m\u25a1B";

            string Y_circ_S_furo_BIG = "\u001b[33m\u25cfB";
            string Y_circ_C_furo_BIG = "\u001b[33m\u25cbB";
            string Y_quad_C_furo_BIG = "\u001b[33m\u25a0B";
            string Y_quad_S_furo_BIG = "\u001b[33m\u25a1B";

            string G_circ_S_furo_small = "\u001b[32m\u25cfs";
            string G_circ_C_furo_small = "\u001b[32m\u25cbs";
            string G_quad_C_furo_small = "\u001b[32m\u25a0s";
            string G_quad_S_furo_small = "\u001b[32m\u25a1s";

            string Y_circ_S_furo_small = "\u001b[33m\u25cfs";
            string Y_circ_C_furo_small = "\u001b[33m\u25cbs";
            string Y_quad_C_furo_small = "\u001b[33m\u25a0s";
            string Y_quad_S_furo_small = "\u001b[33m\u25a1s";
            
            // Limpa a tela antes de desenhar o tabuleiro

            // Loop para desenhar as linhas e colunas do tabuleiro 
            // [Layout da tabela usado pelo ChatGPT]

            char[,] letras = 
            {
                {'A','B','C','D'},
                {'E','F','G','H'},
                {'I','J','K','L'},
                {'M','N','O','P'}
            };
            
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write("+---");
                }
                Console.WriteLine("+");
                for (int col = 0; col < 4; col++)
                {
                    Console.Write($"| {letras[row,col]} ");
                }
                Console.WriteLine("|");
            }
            // Desenha a última linha
            for (int col = 0; col < 4; col++)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");

            Console.WriteLine("");

            Console.WriteLine("---Peças disponiveis---");

            Console.WriteLine
            ($"{G_circ_S_furo_BIG}[0]  || {G_circ_C_furo_BIG}[1]  || {G_quad_C_furo_BIG}[2]  || {G_quad_S_furo_BIG}[3] ");

            Console.WriteLine
            ($"{G_circ_S_furo_small}[4]  || {G_circ_C_furo_small}[5]  || {G_quad_C_furo_small}[6]  || {G_quad_S_furo_small}[7]");

            Console.WriteLine
            ($"{Y_circ_S_furo_BIG}[8]  || {Y_circ_C_furo_BIG}[9]  || {Y_quad_C_furo_BIG}[10] || {Y_quad_S_furo_BIG}[11]");

            Console.WriteLine
            ($"{Y_circ_S_furo_small}[12] || {Y_circ_C_furo_small}[13] || {Y_quad_C_furo_small}[14] || {Y_quad_S_furo_small}[15]");

            // ---------  WAITING HERE FOR NOW ---------
            Console.Write("\u001b[0m");

            Console.Write("Escreve a letra onde deseja colocar a peça:  ");
            char user_place = char.Parse(Console.ReadLine());

            Console.Write("Qual é o numero da peça que deseja:  ");
            int user_piece = int.Parse(Console.ReadLine());
            Console.Clear();
        }
        
            
        private void BuildBoard()
        {
            //
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    //gameBoard[row, col] ;
                }
            }

        }


        private void EndGame(string status)
        {
            Console.WriteLine(status);

            // reset board


            // reset game status
        }

        //private void 


    }
    
}