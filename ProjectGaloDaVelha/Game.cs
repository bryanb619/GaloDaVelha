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



            // EXAMPLE OF PIECE CREATION => INSTACIATING
            
            // --- YELLOW PIECES ---

        //1st ROW (Yellow with no holes)
        // Big Yellow Square with no hole
        private Piece piece1 = new Piece
        (PieceSize.big,PieceColor.yellow,PieceShape.square,PieceHole.none);

        //public Piece Piece1 => piece1;

        // Big Yellow Circle with no hole
        private Piece piece2 = new Piece
        (PieceSize.big,PieceColor.yellow,PieceShape.circle,PieceHole.none);

        // Small Yellow Square with no hole
        private Piece piece3 = new Piece
        (PieceSize.small,PieceColor.yellow,PieceShape.square,PieceHole.none);
        
        // Small Yellow Circle with no hole
        private Piece piece4 = new Piece
        (PieceSize.small,PieceColor.yellow,PieceShape.circle,PieceHole.none);

        // 2nd ROW (Yello with holes)
        // Big Yellow Square with hole
        private Piece piece5 = new Piece
        (PieceSize.big,PieceColor.yellow,PieceShape.square,PieceHole.hole);

        // Big Yellow Circle with hole
        private Piece piece6 = new Piece(
            PieceSize.big,PieceColor.yellow,PieceShape.circle,PieceHole.hole);

        // Small Yellow Square with hole
        private Piece piece7 = new Piece
        (PieceSize.small,PieceColor.yellow,PieceShape.square,PieceHole.hole);

        // Small Yellow Circle with hole    
        private Piece piece8 = new Piece
        (PieceSize.small,PieceColor.yellow,PieceShape.circle,PieceHole.hole);

        // --- GREEN PIECES ---

        private Piece piece9 = new Piece
        (PieceSize.big,PieceColor.green,PieceShape.square,PieceHole.none);

        // Big Yellow Circle with no hole
        private Piece piece10 = new Piece
        (PieceSize.big,PieceColor.green,PieceShape.circle,PieceHole.none);

        // Small Yellow Square with no hole
        private Piece piece11 = new Piece
        (PieceSize.small,PieceColor.green,PieceShape.square,PieceHole.none);
        
        // Small Yellow Circle with no hole
        private Piece piece12 = new Piece
        (PieceSize.small,PieceColor.green,PieceShape.circle,PieceHole.none);

        // 2nd ROW (Yello with holes)
        // Big Yellow Square with hole
        private Piece piece13 = new Piece
        (PieceSize.big,PieceColor.green,PieceShape.square,PieceHole.hole);

        // Big Yellow Circle with hole
        private Piece piece14 = new Piece(
            PieceSize.big,PieceColor.green,PieceShape.circle,PieceHole.hole);

        // Small Yellow Square with hole
        private Piece piece15 = new Piece
        (PieceSize.small,PieceColor.green,PieceShape.square,PieceHole.hole);

        // Small Yellow Circle with hole    
        private Piece piece16 = new Piece
        (PieceSize.small,PieceColor.green,PieceShape.circle,PieceHole.hole);


        private int count_player = 0;
        private int player_number = 1;


        private string[,] letras = 
        {
            {"A","B","C","D"},
            {"E","F","G","H"},
            {"I","J","K","L"},
            {"M","N","O","P"}
        };

        private string[] pecas_array; 
    
        

        public void Start()
        {
            gameStatus = GameStatus.playing;

            Console.WriteLine("Welcome to Galo da Velha!");

            // TEST CODE
            //Console.WriteLine(piece1.GetPieceType());

            //

            // EXAMPLE OF GETTING INFO FROM PIECE
            //Console.WriteLine
            //($"Piece size:{piece1.GetPieceSize()} " 
            //+ $"{piece1.GetPieceColor()} Shape: {piece1.GetPieceShape()} "
            //+ $"Puncture: {piece1.GetPiecePuncture()}");

            //Console.ReadLine();

            //DisplayBoardUI();
            ManageTurns();

            // TODO : Adicionar metodo para construir o tabuleiro Visual
            // BuildUI(); chamar 1 vez => mostrar peças, texto, legendas, etc
            
            // !TODO!: Detetar vitória (de quem?), encerrar o jogo
            // Caso contrario, há peças ainda disponiveis? Se sim, continuar
            // Se não, empate encerrar jogo
            // check with while loop
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
            pecas_array = new string[]
            {
                piece1.GetPieceType(),piece2.GetPieceType(),
                piece3.GetPieceType(),piece4.GetPieceType(),
                piece5.GetPieceType(),piece6.GetPieceType(),
                piece7.GetPieceType(),piece8.GetPieceType(),
                piece9.GetPieceType(),piece10.GetPieceType(),
                piece11.GetPieceType(),piece12.GetPieceType(),
                piece13.GetPieceType(),piece14.GetPieceType(),
                piece15.GetPieceType(),piece16.GetPieceType()
            };
                        
            while (true)
            {
                if (count_player % 2 == 0)
                {
                    player_number = 1;
                    
                }
                else
                {
                    player_number = 2;
                }


                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        Console.Write("+----");
                    }
                    Console.WriteLine("+");
                    for (int col = 0; col < 4; col++)
                    {
                        Console.Write($"| {letras[row,col]}\u001b[0m ".PadRight(9));
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
                

                Console.WriteLine("\u001b[31m[Legenda: B = Grande || s = Pequeno] || Sair = EXIT\n");

                // ---------  WAITING HERE FOR NOW ---------
                Console.Write("\u001b[0m");

                Console.WriteLine($"\u001b[36m==[Jogador {player_number}]==\u001b[0m");
                

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
                                // TODO: Add link
                                List<string> pecas_list = new List<string>(pecas_array);
                                pecas_list.RemoveAt(user_piece);
                                pecas_array = pecas_list.ToArray();
                                count_player++;

                                break;
                            }

                        }
                    }
                }

                Console.WriteLine("///////////////////////////////////////////////\n");
            }

        }


        private void CheckGameStatus()
        {
            // check for win condition
           // gameStatus = CheckWinCondition();
            
            // while playing
            // check board status

            // apply game status
            Condition(gameStatus);

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
          
            Console.Write("\u001b[0m");
            
            // Limpa a tela antes de desenhar o tabuleiro

            // Loop para desenhar as linhas e colunas do tabuleiro 
            // [Layout da tabela usado pelo ChatGPT]

                
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