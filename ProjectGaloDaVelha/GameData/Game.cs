using System;
using System.Collections.Generic;
using ProjectGaloDaVelha.Pieces;

//[System.Runtime]

namespace ProjectGaloDaVelha.GameData
{
    /// <summary>
    /// Galo Da Velha Game class
    /// 
    /// </summary>
    public class Game
    {
        // Board mapping // consider static variables
        //private Piece[,] addedPiecesToBoard = new Piece[3, 3];

        // X       
        // Y  |player1|


        private int turn = 0;

        private static GameStatus gameStatus;

        private  Player player; 

        // EXAMPLE OF PIECE CREATION => INSTACIATING
        
        // --- YELLOW PIECES ---

        //1st ROW (Yellow with no holes)
        // Big Yellow Square with no hole
        private static Piece piece1 = new Piece
        (PieceSize.big,PieceColor.yellow,PieceShape.square,PieceHole.none);
        //public Piece Piece1 => piece1;

        // Big Yellow Circle with no hole
        private static  Piece piece2 = new Piece
        (PieceSize.big,PieceColor.yellow,PieceShape.circle,PieceHole.none);

        // Small Yellow Square with no hole
        private static Piece piece3 = new Piece
        (PieceSize.small,PieceColor.yellow,PieceShape.square,PieceHole.none);
        
        // Small Yellow Circle with no hole
        private static Piece piece4 = new Piece
        (PieceSize.small,PieceColor.yellow,PieceShape.circle,PieceHole.none);

        // 2nd ROW (Yello with holes)
        // Big Yellow Square with hole
        private static  Piece piece5 = new Piece
        (PieceSize.big,PieceColor.yellow,PieceShape.square,PieceHole.hole);

        // Big Yellow Circle with hole
        private static Piece piece6 = new Piece(
            PieceSize.big,PieceColor.yellow,PieceShape.circle,PieceHole.hole);

        // Small Yellow Square with hole
        private static Piece piece7 = new Piece
        (PieceSize.small,PieceColor.yellow,PieceShape.square,PieceHole.hole);

        // Small Yellow Circle with hole    
        private static  Piece piece8 = new Piece
        (PieceSize.small,PieceColor.yellow,PieceShape.circle,PieceHole.hole);

        // --- GREEN PIECES ---
        private static  Piece piece9 = new Piece
        (PieceSize.big,PieceColor.green,PieceShape.square,PieceHole.none);

        // Big Yellow Circle with no hole
        private static Piece piece10 = new Piece
        (PieceSize.big,PieceColor.green,PieceShape.circle,PieceHole.none);

        // Small Yellow Square with no hole
        private static Piece piece11 = new Piece
        (PieceSize.small,PieceColor.green,PieceShape.square,PieceHole.none);
        
        // Small Yellow Circle with no hole
        private static Piece piece12 = new Piece
        (PieceSize.small,PieceColor.green,PieceShape.circle,PieceHole.none);

        // 2nd ROW (Yello with holes)
        // Big Yellow Square with hole
        private static Piece piece13 = new Piece
        (PieceSize.big,PieceColor.green,PieceShape.square,PieceHole.hole);

        // Big Yellow Circle with hole
        private static Piece piece14 = new Piece(
            PieceSize.big,PieceColor.green,PieceShape.circle,PieceHole.hole);

        // Small Yellow Square with hole
        private static Piece piece15 = new Piece
        (PieceSize.small,PieceColor.green,PieceShape.square,PieceHole.hole);

        // Small Yellow Circle with hole    
        private static Piece piece16 = new Piece
        (PieceSize.small,PieceColor.green,PieceShape.circle,PieceHole.hole);


        private int count_player = 0;
        private int player_number = 1;


        // Mapping of the board
        private string[,] pos = 
        {
            {"A","B","C","D"},
            {"E","F","G","H"},
            {"I","J","K","L"},
            {"M","N","O","P"}
        };

        //private Piece[] piecesArray;


        private string[] pecas_array =
        {   
            piece1.GetPieceType(),  piece2.GetPieceType(),
            piece3.GetPieceType(),  piece4.GetPieceType(),
            piece5.GetPieceType(),  piece6.GetPieceType(),
            piece7.GetPieceType(),  piece8.GetPieceType(),
            piece9.GetPieceType(),  piece10.GetPieceType(),
            piece11.GetPieceType(), piece12.GetPieceType(),
            piece13.GetPieceType(), piece14.GetPieceType(),
            piece15.GetPieceType(), piece16.GetPieceType()
        };

        //
        private Piece[] piecesArray = 
        {
            piece1,piece2,piece3,piece4,
            piece5,piece6,piece7,piece8,
            piece9,piece10,piece11,piece12,
            piece13,piece14,piece15,piece16

        };


        //Verificar as linhas horizontais, verticais e diagonais 
        private Piece[,] piecesVerified = new Piece[4,4]; 
        

        
        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            // change game status to playing on start
            gameStatus = GameStatus.playing;

            Assistant(); 

            ManageTurns();

            //DisplayBoardUI();

            // TODO : Adicionar metodo para construir o tabuleiro Visual
            // BuildUI(); chamar 1 vez => mostrar peças, texto, legendas, etc
            
            // !TODO!: Detetar vitória (de quem?), encerrar o jogo
            // Caso contrario, há peças ainda disponiveis? Se sim, continuar
            // Se não, empate encerrar jogo
            // check with while loop
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void Assistant()
        {
            Console.WriteLine("Bem-vindo to Galo da Velha! \n");


            Console.WriteLine("Jogo consiste em colocar as peças no " 
            +"tabuleiro e fazer uma sequência de uma cor, forma, tamanho ou furo");

            Console.WriteLine
            ("O tabuleiro é composto por 4 linhas e 4 colunas. "
            +"As Posições do tabuleiro são representadas por letras\n");

            Console.Write
            ("As peças são representadas numericamente (input) "
            +"e com cores, formas e tamanhos diferentes "
            +"são de 2 tamanhos, 4 formatos e 2 "
            +"cores totalizando 16 peças únicas.\n"
            +"Boa sorte!\n"
            +"Pressione qualquer tecla para continuar... "); 

            Console.ReadLine();


            try
            {
                Console.Clear();
            }

            catch
            {
                Console.WriteLine($"Failed to clear. Continuing..."); 
            }

            
        }
            
        /// <summary>
        /// 
        /// </summary>
        private void ManageTurns()
        {


            while(gameStatus == GameStatus.playing)
            {

                CheckGameStatus();

                // increment turn if no 
                turn++;

                // determine player turn

                //1, 3, 5 // Player 1 turn
                if(turn % 2 != 0) 
                {
                    player = Player.Player1;
                }

                // Player 2 turn // 2, 4, 6
                else
                {
                    player = Player.Player2; 
                }

                MovePiece(player); 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">Enum received to set player move piece</param>
        private void MovePiece(Player player)
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
                    Console.Write
                    ($"| {pos[row,col]}\u001b[0m ".PadRight(9));
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
                        // Ajusta a largura da coluna
                        Console.Write 
                        ($"{pecas_array[index]}[{index}]".PadRight(15)); 
                    }
                    
                }
                Console.WriteLine(); // Nova linha após cada linha de elementos
            }
            

            Console.WriteLine
            ("\u001b[31m[Legenda: B = Grande || s = Pequeno] || Sair = ESC"
            + "|| Ajuda = H" + "\n");

            // ---------  WAITING HERE FOR NOW ---------
            Console.Write("\u001b[0m");

            Console.WriteLine
            ($"\u001b[36m==[ {player.ToString()} ]==\u001b[0m");
            

            Console.Write("Escreve a letra onde deseja colocar a peça:"
            +" Ou ação adicional: ");

            string user_place = Console.ReadLine();

            // Upper case the string
            //user_place.ToUpper(); 

            //user_place = user_place.ToUpper(); 


            Console.Write("Qual é o numero da peça que deseja: ");
            int user_piece = int.Parse(Console.ReadLine());

            //Verificar se a Letra existe na letra 
            //e substituir pela peça

            // TODO: Adicionar condição para não poder 
            //colocar peças em cima de outras
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (pos[i,j] == user_place)
                    {

                        // Classe de board, guarda essa info

                        // pega na pos do 
                        if
                        (user_piece < pecas_array.Length && user_piece >= 0)
                        {
                            // representação visual do array
                            pos[i,j] = pecas_array[user_piece];

                            // representação lógica do array
                            piecesVerified[i,j] = piecesArray[user_piece];
                            

                            // representação visual do array
                            List<string> pecas_list = 
                            new List<string>(pecas_array);
                            pecas_list.RemoveAt(user_piece);
                            pecas_array = pecas_list.ToArray();

                            // representação lógica do array
                            List<Piece> pecas_list_code = 
                            new List<Piece>(piecesArray);
                            pecas_list_code.RemoveAt(user_piece);
                            piecesArray = pecas_list_code.ToArray();

                            break;
                        }

                    }
                }
            }

            
            // Verificar peças horizontal e vertical
            for (int i = 0; i < piecesVerified.GetLength(0); i++)
            {
                int counter_ColorHorizontal = 1;
                int counter_ShapeHorizontal = 1;
                int counter_HoleHorizontal = 1;
                int counter_SizeHorizontal = 1;

                int counter_ColorVertical = 1;
                int counter_ShapeVertical = 1;
                int counter_HoleVertical = 1;
                int counter_SizeVertical = 1;

                int counter_ColorDiag_L = 1;
                int counter_ShapeDiag_L = 1;
                int counter_HoleDiag_L = 1;
                int counter_SizeDiag_L = 1;

                int counter_ColorDiag_R_ = 1;
                int counter_ShapeDiag_R = 1;
                int counter_HoleDiag_R = 1;
                int counter_SizeDiag_R = 1;

                int j,k;

                for (j = 1, k = 1; j < piecesVerified.GetLength(1); j++, k++) // Se a cor, forma, hole e tamanho for igual:
                {
                    // Verificação horizontal
                    if (piecesVerified[i, j] != null && piecesVerified[i, j - 1] != null) // Se não for vazio
                    {
                        
                        if (piecesVerified[i, j].GetPieceColor() == piecesVerified[i, j - 1].GetPieceColor())
                        {
                            counter_ColorHorizontal++;
                            
                        }
                        else
                        {
                            counter_ColorHorizontal = 1;
                        }

                        if (piecesVerified[i, j].GetPieceShape() == piecesVerified[i, j - 1].GetPieceShape())
                        {
                            counter_ShapeHorizontal++;
                        }
                        else
                        {
                            counter_ShapeHorizontal = 1;
                        }

                        if (piecesVerified[i, j].GetPieceHole() == piecesVerified[i, j - 1].GetPieceHole())
                        {
                            counter_HoleHorizontal++;
                        }
                        else
                        {
                            counter_HoleHorizontal = 1;
                        }

                        if (piecesVerified[i, j].GetPieceSize() == piecesVerified[i, j - 1].GetPieceSize())
                        {
                            counter_SizeHorizontal++;
                        }
                        else
                        {
                            counter_SizeHorizontal = 1;
                        }

                        if (counter_ColorHorizontal == 4 || counter_ShapeHorizontal == 4 || counter_HoleHorizontal == 4 || counter_SizeHorizontal == 4)
                        {
                            Console.WriteLine("O jogador tal ganhou na horizontal!"); // Um dos jogadores ganhou
                            // JOGO FECHA
                            break;
                        }
                    }

                    // Verificação vertical
                    if (piecesVerified[j, i] != null && piecesVerified[j - 1, i] != null) // Se não for vazio
                    {
                        if (piecesVerified[j, i].GetPieceColor() == piecesVerified[j - 1, i].GetPieceColor())
                        {
                            counter_ColorVertical++;
                        }
                        else
                        {
                            counter_ColorVertical = 1;
                        }

                        if (piecesVerified[j, i].GetPieceShape() == piecesVerified[j - 1, i].GetPieceShape())
                        {
                            counter_ShapeVertical++;
                        }
                        else
                        {
                            counter_ShapeVertical = 1;
                        }

                        if (piecesVerified[j, i].GetPieceHole() == piecesVerified[j - 1, i].GetPieceHole())
                        {
                            counter_HoleVertical++;
                        }
                        else
                        {
                            counter_HoleVertical = 1;
                        }

                        if (piecesVerified[j, i].GetPieceSize() == piecesVerified[j - 1, i].GetPieceSize())
                        {
                            counter_SizeVertical++;
                        }
                        else
                        {
                            counter_SizeVertical = 1;
                        }

                        if (counter_ColorVertical == 4 || counter_ShapeVertical == 4 || counter_HoleVertical == 4 || counter_SizeVertical == 4)
                        {
                            Console.WriteLine("O jogador tal ganhou na vertical!"); // Um dos jogadores ganhou
                            // JOGO FECHA
                            break;
                        }
                    }
                    
                    
                    // Verificação DIAGONAL_LEFT
                    if (i > 0 && j > 0 && piecesVerified[k - 1, j - 1] != null && piecesVerified[j , k ] != null)
                    {
                        
                        
                        if (piecesVerified[k - 1, j - 1].GetPieceColor() == piecesVerified[k , j ].GetPieceColor())
                        {
                            counter_ColorDiag_L++;
                            
                        }
                        else
                        {
                            counter_ColorDiag_L = 1;
                        }

                        if (piecesVerified[k - 1, j - 1].GetPieceShape() == piecesVerified[k , j ].GetPieceShape())
                        {
                            counter_ShapeDiag_L++;
                        }
                        else
                        {
                            counter_ShapeDiag_L = 1;
                        }

                        if (piecesVerified[k - 1, j - 1].GetPieceHole() == piecesVerified[k , j ].GetPieceHole())
                        {
                            counter_HoleDiag_L++;
                        }
                        else
                        {
                            counter_HoleDiag_L = 1;
                        }

                        if (piecesVerified[k - 1, j - 1].GetPieceSize() == piecesVerified[k , j ].GetPieceSize())
                        {
                            counter_SizeDiag_L++;
                        }
                        else
                        {
                            counter_SizeDiag_L = 1;
                        }

                        if  (counter_ColorDiag_L == 4 || counter_ShapeDiag_L == 4 || counter_HoleDiag_L == 4 || counter_SizeDiag_L == 4)
                        {
                            Console.WriteLine
                            ("O jogador tal ganhou na diagonal da esquerda"); // Um dos jogadores ganhou
                            // JOGO FECHA
                            break;
                        }
                    }

                    // Verificação DIAGONAL_RIGHT
                    if (i > 0 && j < piecesVerified.GetLength(1) - 1 && piecesVerified[i, j] != null && piecesVerified[i - 1, j + 1] != null) // Se não for vazio
                    {
                        
                        
                        if (piecesVerified[i, j].GetPieceColor() == piecesVerified[i - 1, j + 1].GetPieceColor())
                        {
                            counter_ColorDiag_R_++;
                            
                        }
                        else
                        {
                            counter_ColorDiag_R_ = 1;
                        }

                        if (piecesVerified[i, j].GetPieceShape() == piecesVerified[i - 1, j + 1].GetPieceShape())
                        {
                            counter_ShapeDiag_R++;
                        }
                        else
                        {
                            counter_ShapeDiag_R = 1;
                        }

                        if (piecesVerified[i, j].GetPieceHole() == piecesVerified[i - 1, j + 1].GetPieceHole())
                        {
                            counter_HoleDiag_R++;
                        }
                        else
                        {
                            counter_HoleDiag_R = 1;
                        }

                        if (piecesVerified[i, j].GetPieceSize() == piecesVerified[i - 1, j + 1].GetPieceSize())
                        {
                            counter_SizeDiag_R++;
                        }
                        else
                        {
                            counter_SizeDiag_R = 1;
                        }

                        if  (counter_ColorDiag_R_ == 4 || counter_ShapeDiag_R == 4 || counter_HoleDiag_R == 4 || counter_SizeDiag_R == 4)
                        {
                            Console.WriteLine
                            ("O jogador tal ganhou na diagonal da direita"); // Um dos jogadores ganhou
                            // JOGO FECHA
                            break;
                        }
                    }
                }
}


            // clear console

            try
            {
                Console.Clear();
            }

            catch
            {
                Console.WriteLine("Continuing"); 
            }
            
        }


        private void CheckGameStatus()
        {

            if(pecas_array.Length < 1 )
            {
                gameStatus = GameStatus.draw;
                
            }

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
            Console.WriteLine(status + "Pressione enter para sair\n");

            // RESTART GAME
            //Console.ReadLine();

            return;
            // clear console

            // reset board


            // reset game status
        }

        //private void 


    }
    
}