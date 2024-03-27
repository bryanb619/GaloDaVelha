using System;
using System.Collections.Generic;
using System.Drawing;


namespace ProjectGaloDaVelha
{
    
    public class Game
    {
        // Board mapping // consider static variables
        private Piece[,] addedPiecesToBoard = new Piece[3, 3];

        // X       
        // Y  |player1|


        private int turn = 0;


        private GameStatus gameStatus;


        

        public void Start()
        {

            Console.WriteLine("Welcome to Galo da Velha!");

            // TEST CODE

            // EXAMPLE OF PIECE CREATION => INSTACIATING
            Piece piece1 = new Piece(PieceSize.small, PieceColor.yellow, PieceShape.square, PieceHole.hole);


            //Console.WriteLine(piece1.GetPieceType());

            //Pieces piece2 = new Pieces(PieceSize.big, PieceColor.color2, PieceShape.square, PiecePuncture.hole);


            //

            // EXAMPLE OF GETTING INFO FROM PIECE
            //Console.WriteLine
            //($"Piece size:{piece1.GetPieceSize()} " 
            //+ $"{piece1.GetPieceColor()} Shape: {piece1.GetPieceShape()} "
            //+ $"Puncture: {piece1.GetPiecePuncture()}");
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
                if(turn % 2 != 0) //1, 3, 5
                {
                    // Player 1 turn
                    MovePiece(Player.player1);
                }
                else
                {
                    // Player 2 turn // 2, 4, 6
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

                                    // cor[33] \unicode(dentro define se é furo ou nao) + tamanho 
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

            Console.Write("\u001b[0m");
            
            // Limpa a tela antes de desenhar o tabuleiro

            // Loop para desenhar as linhas e colunas do tabuleiro 
            // [Layout da tabela usado pelo ChatGPT]

            string[,] letras = 
            {
                {"A","B","C","D"},
                {"E","F","G","H"},
                {"I","J","K","L"},
                {"M","N","O","P"}
            };

            string[] pecas_array =
            {
                G_circ_S_furo_BIG,G_circ_C_furo_BIG,G_quad_C_furo_BIG,G_quad_S_furo_BIG,
                G_circ_S_furo_small,G_circ_C_furo_small,G_quad_C_furo_small,G_quad_S_furo_small,
                Y_circ_S_furo_BIG,Y_circ_C_furo_BIG,Y_quad_C_furo_BIG,Y_quad_S_furo_BIG,
                Y_circ_S_furo_small,Y_circ_C_furo_small,Y_quad_C_furo_small,Y_quad_S_furo_small


            };

            while (true)
            {
                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        Console.Write("+----");
                    }
                    Console.WriteLine("+");
                    for (int col = 0; col < 4; col++)
                    {
                        Console.Write($"| {letras[row,col]} \u001b[0m ");
                    }
                    
                    Console.WriteLine("|");
                }
                // Desenha a última linha
                for (int col = 0; col < 4; col++)
                {
                    Console.Write("+----");
                }
                Console.WriteLine("+");

                Console.WriteLine("");

                Console.WriteLine("[---Peças disponiveis---]");

                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        int index = row * 4 + col; // Calcula o índice correto
                        if (index < pecas_array.Length)
                        {
                            Console.Write($"{pecas_array[index]}[{index}]".PadRight(15)); // Ajusta a largura da coluna
                        }
                        
                    }
                    Console.WriteLine(); // Nova linha após cada linha de elementos
                }
                

                Console.WriteLine("\u001b[31m[Legenda: B = Grande || s = Pequeno] || Sair = EXIT");

                // ---------  WAITING HERE FOR NOW ---------
                Console.Write("\u001b[0m");

                Console.Write("Escreve a letra onde deseja colocar a peça:  ");
                string user_place = Console.ReadLine();

                Console.Write("Qual é o numero da peça que deseja:  ");
                int user_piece = int.Parse(Console.ReadLine());

        

                

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (letras[i,j] == user_place)
                        {
                            if(user_piece < pecas_array.Length && user_piece >= 0)
                            {
                                letras[i,j] = pecas_array[user_piece];

                                
                                List<string> pecas_list = new List<string>(pecas_array);
                                pecas_list.RemoveAt(user_piece);
                                pecas_array = pecas_list.ToArray();

                                //break;
                            }

                        }
                    }
                }

                

                
                

            }
            
            
            
                
                
                

                

                

                
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