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
            size = PieceSize.small;
            color = PieceColor.color1;
            shape = PieceShape.square;
            puncture = PiecePuncture.punctured;

            Pieces piece1 = new Pieces(size, color, shape, puncture);

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

                // Player 1 turn
                if(turn % 2 != 0)
                {

                    
                    //MovePiece();
                }
                else
                {
                    // Player 2 turn
                    //MovePiece();
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
            
            //Console.Clear(); // Limpa a tela antes de desenhar o tabuleiro

            // Loop para desenhar as linhas e colunas do tabuleiro 
            // [Usado pelo ChatGPT]
            Console.WriteLine("");
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write("+---");
                }
                Console.WriteLine("+");
                for (int col = 0; col < 4; col++)
                {
                    Console.Write("|   ");
                }
                Console.WriteLine("|");
            }
            // Desenha a última linha
            for (int col = 0; col < 4; col++)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");

            Console.WriteLine("---Peças disponiveis---");

            Console.WriteLine
            ($"{G_circ_S_furo_BIG}, {G_circ_C_furo_BIG},{G_quad_C_furo_BIG}, {G_quad_S_furo_BIG}");

            Console.WriteLine
            ($"{G_circ_S_furo_small}, {G_circ_C_furo_small},{G_quad_C_furo_small}, {G_quad_S_furo_small}");

            Console.WriteLine
            ($"{Y_circ_S_furo_BIG}, {Y_circ_C_furo_BIG},{Y_quad_C_furo_BIG}, {Y_quad_S_furo_BIG}");

            Console.WriteLine
            ($"{Y_circ_S_furo_small}, {Y_circ_C_furo_small},{Y_quad_C_furo_small}, {Y_quad_S_furo_small}");

            // ---------  WAITING HERE FOR NOW ---------
            Console.ReadLine();
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