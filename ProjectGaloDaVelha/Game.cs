using System;


namespace ProjectGaloDaVelha
{
    

    public class Game
    {
        // Board mapping
        private static Pieces[,] gameBoard = new Pieces[3, 3];


       // private GameStatus gameStatus;

         

        public void Start()
        {

            Console.WriteLine("Welcome to Galo da Velha!");

            //Console.ReadLine();

            //BuildBoard();
            DisplayBoardUI();
            //ManageTurns();
            //MovePiece();
            //CheckGameStatus();
            //EndGame();
        }
        //----------------------------------------------------------------------

        private void ManageTurns()
        {
            int turn = 0;

            while(true)
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

            // check for valid input & move

            // update game board
        }


        /// <summary>
        ///  TODO: Must clear board and reset game status
        /// </summary>
        private void EndGame(GameStatus gameStatus)
        {
            switch (gameStatus)
            {
                // Player 1 wins
                case GameStatus.player1Win:
                {
                    Console.WriteLine("Player 1 wins!");

                    break;
                }
                    

                // Player 2 wins
                case GameStatus.player2Win:
                {
                    Console.WriteLine("Player 2 wins!");

                    break;
                }
                   
                // Draw
                case GameStatus.draw:
                {
                    Console.WriteLine("It's a draw!");

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

        //private void 


    }
    
}