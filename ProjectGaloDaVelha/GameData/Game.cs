using System;
using System.IO; // Used for reading files
using System.Collections.Generic;
using ProjectGaloDaVelha.Pieces; // for pieces enum and classes
using ProjectGaloDaVelha.GameData.BoardMapping; // for board class
using ProjectGaloDaVelha.GameData.Enviroment; // for file directory class


namespace ProjectGaloDaVelha.GameData
{
    /// <summary>
    /// Galo Da Velha Game class
    /// 
    /// </summary>
    public class Game
    {
        // reference to the game status enum
        private static GameStatus gameStatus;

        // Reference to the player enum
        private static Player player;

        // Reference to the turn
        private static int turn = 0;
        
        // Reference to the file directory class
        private static FileDirectory fileDirectory = new FileDirectory();

        // Mapping of the board
        // start board
        private static Board board = new Board();

        private static string[,] boardMap = board.GetBoard();

 
        // --- YELLOW PIECES --- //

        //1st ROW (Yellow with no holes)
        // Big Yellow Square with no hole
        private static Piece piece1 = new Piece
        (PieceSize.big, PieceColor.yellow, PieceShape.square, PieceHole.none);
        //public Piece Piece1 => piece1;

        // Big Yellow Circle with no hole
        private static Piece piece2 = new Piece
        (PieceSize.big, PieceColor.yellow, PieceShape.circle, PieceHole.none);

        // Small Yellow Square with no hole
        private static Piece piece3 = new Piece
        (PieceSize.small, PieceColor.yellow, PieceShape.square, PieceHole.none);

        // Small Yellow Circle with no hole
        private static Piece piece4 = new Piece
        (PieceSize.small, PieceColor.yellow, PieceShape.circle, PieceHole.none);

        // 2nd ROW (Yello with holes)
        // Big Yellow Square with hole
        private static Piece piece5 = new Piece
        (PieceSize.big, PieceColor.yellow, PieceShape.square, PieceHole.hole);

        // Big Yellow Circle with hole
        private static Piece piece6 = new Piece
        (PieceSize.big, PieceColor.yellow, PieceShape.circle, PieceHole.hole);

        // Small Yellow Square with hole
        private static Piece piece7 = new Piece
        (PieceSize.small, PieceColor.yellow, PieceShape.square, PieceHole.hole);

        // Small Yellow Circle with hole    
        private static Piece piece8 = new Piece
        (PieceSize.small, PieceColor.yellow, PieceShape.circle, PieceHole.hole);

        // --- GREEN PIECES ---
        private static Piece piece9 = new Piece
        (PieceSize.big, PieceColor.green, PieceShape.square, PieceHole.none);

        // Big Yellow Circle with no hole
        private static Piece piece10 = new Piece
        (PieceSize.big, PieceColor.green, PieceShape.circle, PieceHole.none);

        // Small Yellow Square with no hole
        private static Piece piece11 = new Piece
        (PieceSize.small, PieceColor.green, PieceShape.square, PieceHole.none);

        // Small Yellow Circle with no hole
        private static Piece piece12 = new Piece
        (PieceSize.small, PieceColor.green, PieceShape.circle, PieceHole.none);

        // 2nd ROW (Yello with holes)
        // Big Yellow Square with hole
        private static Piece piece13 = new Piece
        (PieceSize.big, PieceColor.green, PieceShape.square, PieceHole.hole);

        // Big Yellow Circle with hole
        private static Piece piece14 = new Piece(
            PieceSize.big, PieceColor.green, PieceShape.circle, PieceHole.hole);

        // Small Yellow Square with hole
        private static Piece piece15 = new Piece
        (PieceSize.small, PieceColor.green, PieceShape.square, PieceHole.hole);

        // Small Yellow Circle with hole    
        private static Piece piece16 = new Piece
        (PieceSize.small, PieceColor.green, PieceShape.circle, PieceHole.hole);



  
        // Array of pieces types
        private static string[] pecas_array =
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
        private static Piece[] piecesArray =
        {
            piece1,     piece2,     piece3,     piece4,
            piece5,     piece6,     piece7,     piece8,
            piece9,     piece10,    piece11,    piece12,
            piece13,    piece14,    piece15,    piece16

        };


        //Verificar as linhas horizontais, verticais e diagonais 
        private static Piece[,] piecesVerified = new Piece[4, 4];


        /// <summary>
        /// Starts Game Operations
        /// </summary>
        public void Start()
        {
            // change game status to playing on start
            gameStatus = GameStatus.playing;

            // Calls the manage turns method
            // method, diceides the player turn
            RunGame();

            // TODO: STEVEN
            // XML comments
            // Fix CONSOLE CLEAR()
            // RESEARCH ON BOARD CLASS

            //TODO: HUGO
            // Same pos Pieces issues & Turn issue
            // upper case the string
            // Letter lenght check
            // Readme
        }


        /// <summary>
        /// 
        /// </summary>
        private void RunGame()
        {

            // Calls the welcome text method
            Welcome();

            // Loop the the game while game status is playing
            while (gameStatus == GameStatus.playing)
            {
                
                // Check for draw
                CheckForDraw();

                // Update board
                UpdateBoard();

                // Move piece
                MovePiece();
            }

        }
         /// <summary>
        ///  Display welcome message to the player
        ///  provides instructions on how to play the game
        ///  uses System.IO & StreamReader to read from text file
        ///  Locates file using FileDirectory class & file path
        ///  Loops thorugh each line of the file and prints it content
        /// </summary>
        private void Welcome()
        {

            // try to read text file
            try
            {   
                // enters enter before text
                Console.WriteLine(); 
                
                
                using (StreamReader sr = new StreamReader
                (fileDirectory.Info
                +"/ProjectGaloDaVelha/GameData/WelcomeText.txt"))
                {
                    // line to be printed
                    string line;

                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }

                   
                }

                Console.ReadLine();

                Console.Clear();

            }

            catch 
            {

               // Console.WriteLine(e.Message);
            }

            //

        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateBoard()
        {
            Console.WriteLine();

            // Display board
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
                    ($"| {boardMap[row, col]}\u001b[0m ".PadRight(9));
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


            // Mostar peças disponiveis
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
                // Nova linha após cada linha de elementos
                Console.WriteLine(); 
            }


        }


        /// <summary>
        /// 
        /// </summary>
        private void MovePiece()
        {
        
            turn++;

            // determine player turn

            //1, 3, 5 -> Player 1 turn
            if (turn % 2 != 0)
            {
                player = Player.Player1;
            }

            // Player 2 turn -> 2, 4, 6
            else
            {
                player = Player.Player2;
            }


            SetPieceOnBoard();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetPieceOnBoard()
        {
            // Muda cor para vermelho
            Console.WriteLine
            ("\u001b[31m[Legenda: B = Grande || s = Pequeno] || Sair do jogo = ESC\n");

            // ---------  WAITING HERE FOR NOW ---------
            Console.Write("\u001b[0m"); // Muda cor para branco


            Console.WriteLine
            ($"\u001b[36m==[ {player} ]==\u001b[0m");


            Console.Write("Escreve a letra onde deseja colocar a peça: ");

            string user_place = Console.ReadLine().ToUpper();


            if (user_place == "ESC")
            {
                //gameStatus = GameStatus.exit;
                EndGame(GameStatus.exit);
                //Environment.Exit(0); //Meter no relatorio
                
            }

            //Se o input for maior de 1 caracter e não for ESC
            while (user_place != "ESC" && user_place.Length > 1)
            {
                if (user_place == "ESC")
                {
                    //gameStatus = GameStatus.exit;
                    EndGame(GameStatus.exit);
                    //Environment.Exit(0); //Meter no relatorio
                }
                
                Console.Write
                ("A letra tem mais do que 1 caracter, insira a letra novamente: ");
                user_place = Console.ReadLine().ToUpper();

            }

            // TODO: Adicionar condição para não poder
            // Upper case the string
            //user_place.ToUpper(); 

            //user_place = user_place.ToUpper(); 


            Console.Write("Qual é o numero da peça que deseja: ");
            string user_piece_string = Console.ReadLine();
            int user_piece;

            if (user_piece_string == "ESC")
            {
                EndGame(GameStatus.exit);
                //Meter no relatorio
            }

            //Se o input do número não for um numero valido:
            while (!int.TryParse(user_piece_string, out user_piece))
            {
                Console.Write("Por favor, insira um número válido: ");
                user_piece_string = Console.ReadLine();

                if (user_piece_string == "ESC")
                {
                    EndGame(GameStatus.exit);
                //Environment.Exit(0); //Meter no relatorio
                }

            }
            
            user_piece = int.Parse(user_piece_string);

            //Se o input do número for maior/menos que os numeros existentes: 
            while (user_piece > pecas_array.Length || user_piece < 0)
            {
                Console.Write
                ("O número atribuido à peça não existe, insira o número novamente: ");
                user_piece = int.Parse(Console.ReadLine());

            }

            bool letter_dont_exist = true;

            while (letter_dont_exist)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (boardMap[i, j] == user_place)
                        {

                            // Classe de board, guarda essa info


                            // TODO: Adicionar condição para não poder 
                            //colocar peças em cima de outras

                            /*
                            if (user_place == invalido )
                            {
                                user_place = Console.ReadLine();
                            }

                            */


                            if
                            (user_piece < pecas_array.Length && user_piece >= 0)
                            {
                                // representação visual do array
                                boardMap[i, j] = pecas_array[user_piece];

                                // representação lógica do array
                                piecesVerified[i, j] = piecesArray[user_piece];


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

                                letter_dont_exist = false;
                                break;

                            }

                        }
                    }


                }
                if (letter_dont_exist == false)
                {
                    break;

                }

                Console.Write("Essa letra não existe no tabuleiro, insira a letra novamente: ");
                user_place = Console.ReadLine().ToUpper();

                if (user_place == "ESC")
                {
                    //gameStatus = GameStatus.exit;

                    EndGame(GameStatus.exit);        
                    //Environment.Exit(0); //Meter no relatorio
                    break;
                }

            }

            bool mensagemExibida = false; //Mensagem para quem ganhou, para certificar que a mensagem só dá print 1 vez

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

                int j, k, n;

                for (j = 1, k = 1, n = 3; j < piecesVerified.GetLength(1); j++, k++, n--) // Se a cor, forma, hole e tamanho for igual:
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

                        if ((counter_ColorHorizontal == 4 || counter_ShapeHorizontal == 4 || counter_HoleHorizontal == 4 || counter_SizeHorizontal == 4) && !mensagemExibida)
                        {
                            mensagemExibida = true;
                            Console.WriteLine
                            ($"***********************************\n"); 
                            //Console.WriteLine($"O {player.ToString()} ganhou na horizontal!"); // Um dos jogadores ganhou
                            // JOGO FECHA
                            switch (player)
                            {
                                case Player.Player1:
                                    {

                                        //gameStatus = GameStatus.player1Win;
                                        EndGame(GameStatus.player1Win,
                                        "na horizontal!");
                                        break;
                                    }
                                case Player.Player2:
                                    {
                                        //gameStatus = GameStatus.player2Win;
                                        EndGame(GameStatus.player2Win,
                                        "na horizontal!");
                                        break;
                                    }
                            }
                            break;

                        }
                    }

                    // Verificação vertical
                    if (piecesVerified[j, i] != null &&
                    piecesVerified[j - 1, i] != null) // Se não for vazio
                    {
                        if (piecesVerified[j, i].GetPieceColor() ==
                         piecesVerified[j - 1, i].GetPieceColor())
                        {
                            counter_ColorVertical++;
                        }
                        else
                        {
                            counter_ColorVertical = 1;
                        }

                        if (piecesVerified[j, i].GetPieceShape() ==
                         piecesVerified[j - 1, i].GetPieceShape())
                        {
                            counter_ShapeVertical++;
                        }
                        else
                        {
                            counter_ShapeVertical = 1;
                        }

                        if (piecesVerified[j, i].GetPieceHole() ==
                         piecesVerified[j - 1, i].GetPieceHole())
                        {
                            counter_HoleVertical++;
                        }
                        else
                        {
                            counter_HoleVertical = 1;
                        }

                        if (piecesVerified[j, i].GetPieceSize() ==
                         piecesVerified[j - 1, i].GetPieceSize())
                        {
                            counter_SizeVertical++;
                        }
                        else
                        {
                            counter_SizeVertical = 1;
                        }

                        if ((counter_ColorVertical == 4 || counter_ShapeVertical
                        == 4 || counter_HoleVertical == 4 || counter_SizeVertical == 4) && !mensagemExibida)
                        {
                            mensagemExibida = true;
                            Console.WriteLine
                            ($"***********************************\n"); 

                            //Console.WriteLine($"O {player.ToString()} ganhou na vertical!"); // Um dos jogadores ganhou
                                                                                             // JOGO FECHA
                                                                                             // break;
                            switch (player)
                            {
                                case Player.Player1:
                                    {
                                        //gameStatus = GameStatus.player1Win;
                                        EndGame(GameStatus.player1Win,
                                        "na vertical!");
                                        break;
                                    }
                                case Player.Player2:
                                    {
                                        //gameStatus = GameStatus.player2Win;
                                        EndGame(GameStatus.player2Win,
                                        "na vertical!");
                                        break;
                                    }
                            }
                            //break;

                        }
                    }


                    // Verificação DIAGONAL_LEFT
                    if (i > 0 && j > 0 && piecesVerified[k - 1, j - 1] !=
                    null && piecesVerified[j, k] != null)
                    {


                        if (piecesVerified[k - 1, j - 1].GetPieceColor() ==
                         piecesVerified[k, j].GetPieceColor())
                        {
                            counter_ColorDiag_L++;

                        }
                        else
                        {
                            counter_ColorDiag_L = 1;
                        }

                        if (piecesVerified[k - 1, j - 1].GetPieceShape() ==
                        piecesVerified[k, j].GetPieceShape())
                        {
                            counter_ShapeDiag_L++;
                        }
                        else
                        {
                            counter_ShapeDiag_L = 1;
                        }

                        if (piecesVerified[k - 1, j - 1].GetPieceHole() ==
                        piecesVerified[k, j].GetPieceHole())
                        {
                            counter_HoleDiag_L++;
                        }
                        else
                        {
                            counter_HoleDiag_L = 1;
                        }

                        if (piecesVerified[k - 1, j - 1].GetPieceSize() ==
                        piecesVerified[k, j].GetPieceSize())
                        {
                            counter_SizeDiag_L++;
                        }
                        else
                        {
                            counter_SizeDiag_L = 1;
                        }

                        if ((counter_ColorDiag_L == 4 || counter_ShapeDiag_L == 4 ||
                        counter_HoleDiag_L == 4 || counter_SizeDiag_L == 4) && !mensagemExibida)
                        {
                            mensagemExibida = true;
                            Console.WriteLine
                            ($"***********************************\n"); 
                            //Console.WriteLine
                            //($"O {player} ganhou na diagonal da esquerda"); // Um dos jogadores ganhou
                                                                                       // JOGO FECHA
                                                                                       // break;

                            switch (player)
                            {
                                case Player.Player1:
                                    {
                                        //gameStatus = GameStatus.player1Win;
                                        EndGame(GameStatus.player1Win,
                                        "na diagonal da esquerda!");
                                        break;
                                    }
                                case Player.Player2:
                                    {
                                        //gameStatus = GameStatus.player2Win;
                                        EndGame(GameStatus.player2Win,
                                        "na diagonal da esquerda!");
                                        break;
                                    }
                            }
                            //break;
                        }
                        
                    }

                    // Verificação DIAGONAL_RIGHT
                    if (i > 0 && j > 0 && piecesVerified[k - 1, n] != null &&
                    piecesVerified[k, n - 1] != null) // Se não for vazio
                    {


                        if (piecesVerified[k - 1, n].GetPieceColor() ==
                         piecesVerified[k, n - 1].GetPieceColor())
                        {
                            counter_ColorDiag_R_++;

                        }
                        else
                        {
                            counter_ColorDiag_R_ = 1;
                        }

                        if (piecesVerified[k - 1, n].GetPieceShape()
                        == piecesVerified[k, n - 1].GetPieceShape())
                        {
                            counter_ShapeDiag_R++;
                        }
                        else
                        {
                            counter_ShapeDiag_R = 1;
                        }

                        if (piecesVerified[k - 1, n].GetPieceHole()
                        == piecesVerified[k, n - 1].GetPieceHole())
                        {
                            counter_HoleDiag_R++;
                        }
                        else
                        {
                            counter_HoleDiag_R = 1;
                        }

                        if (piecesVerified[k - 1, n].GetPieceSize()
                        == piecesVerified[k, n - 1].GetPieceSize())
                        {
                            counter_SizeDiag_R++;
                        }
                        else
                        {
                            counter_SizeDiag_R = 1;
                        }

                        if ((counter_ColorDiag_R_ == 4 || counter_ShapeDiag_R == 4
                        || counter_HoleDiag_R == 4 || counter_SizeDiag_R == 4) && !mensagemExibida)
                        {
                            mensagemExibida = true;
                            Console.WriteLine
                            ($"***********************************\n"); 
                            // Um dos jogadores ganhou
                            //Console.WriteLine
                           //($"O {player.ToString()} ganhou na diagonal da direita"); 

                            switch (player)
                            {
                                case Player.Player1:
                                    {
                                        //gameStatus = GameStatus.player1Win;
                                        EndGame(GameStatus.player1Win,
                                        "na diagonal da direita!");
                                        break;
                                    }
                                case Player.Player2:
                                    {
                                        //gameStatus = GameStatus.player2Win;
                                        EndGame(GameStatus.player2Win,
                                        "na diagonal da direita!");
                                        break;
                                    }
                            }
                           // break;
                            
                        }
                        
                    }
                }
            }
            Console.WriteLine
            ($"***********************************\n"); 

        }

        /// <summary>
        /// 
        /// </summary>
        private void CheckForDraw()
        {

            if (pecas_array.Length < 1)
            {
                //gameStatus = GameStatus.draw;
                EndGame(GameStatus.draw);

            }

        }


        private void Win(Player player)
        {
            
        }

        /// <summary>
        ///  TODO: Must clear board and reset game status
        /// </summary>
        private void EndGame(GameStatus status, string winCondition = "")
        {
            // change game status
            gameStatus = status;

            // Final message
            string message = "";

            switch (gameStatus)
            {

                // Player 1 wins
                case GameStatus.player1Win:
                    {

                        message = "O jogador 1 ganhou";
                        break;
                    }

                // Player 2 wins
                case GameStatus.player2Win:
                    {
                        message = "O jogador 2 ganhou";
                        break;
                    }

                // Draw
                case GameStatus.draw:
                    {

                        message = "Empate!";
                        break;
                    }
                case GameStatus.exit:
                    {

                        message= "Jogo terminado!";
                        break;
                    }

                default: { break; }

            }


            if(winCondition.Length > 1)
            {
               // message += winCondition;
               Console.WriteLine($"{message} {winCondition}");

            }
            else
            {
                // display final message
                Console.WriteLine(message);

            }

            // update board one more time
            UpdateBoard(); 


            Console.WriteLine
            ("Utilize o comando: dotnet run --project ProjectGaloDaVelha para jogar novamente!");
                       
            // exit game 
            // similar command to return 
            Environment.Exit(0); 
            
            
        }

    }

}