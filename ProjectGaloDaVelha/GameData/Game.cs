using System; 
using System.Linq;                                  // user for Set List ops
using System.IO;                                    // Used for reading files
using System.Collections.Generic;                   // Used for List
using ProjectGaloDaVelha.Pieces;                    // Pieces enum and classes
using ProjectGaloDaVelha.GameData.BoardMapping;     // Board class
using ProjectGaloDaVelha.GameData.Enviroment;       // File directory class


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

        // Mapping of the board, creates a new instance of the board
        private static Board board = new Board();

        // Array of Pieces
        private static Piece[] piecesArray = 
        {
            // Yellow pieces
            new Piece(PieceSize.big, 
            PieceColor.yellow, PieceShape.square, PieceHole.none),
            new Piece(PieceSize.big, 
            PieceColor.yellow, PieceShape.circle, PieceHole.none),
            new Piece(PieceSize.small, 
            PieceColor.yellow, PieceShape.square, PieceHole.none),
            new Piece(PieceSize.small, 
            PieceColor.yellow, PieceShape.circle, PieceHole.none),
            new Piece(PieceSize.big, 
            PieceColor.yellow, PieceShape.square, PieceHole.hole),
            new Piece(PieceSize.big, 
            PieceColor.yellow, PieceShape.circle, PieceHole.hole),
            new Piece(PieceSize.small, 
            PieceColor.yellow, PieceShape.square, PieceHole.hole),
            new Piece(PieceSize.small, 
            PieceColor.yellow, PieceShape.circle, PieceHole.hole),

            // Greenn pieces
            new Piece(PieceSize.big, 
            PieceColor.green, PieceShape.square, PieceHole.none),
            new Piece(PieceSize.big, 
            PieceColor.green, PieceShape.circle, PieceHole.none),
            new Piece(PieceSize.small, 
            PieceColor.green, PieceShape.square, PieceHole.none),
            new Piece(PieceSize.small, 
            PieceColor.green, PieceShape.circle, PieceHole.none),
            new Piece(PieceSize.big, 
            PieceColor.green, PieceShape.square, PieceHole.hole),
            new Piece(PieceSize.big, 
            PieceColor.green, PieceShape.circle, PieceHole.hole),
            new Piece(PieceSize.small, 
            PieceColor.green, PieceShape.square, PieceHole.hole),
            new Piece(PieceSize.small, 
            PieceColor.green, PieceShape.circle, PieceHole.hole)
        };

        // arrays of pieces placed on the board
        private static Piece[,] piecesVerified = new Piece[4, 4];


        /// <summary>
        /// Method starts Game Operations.
        /// Sets games status to playing so the the game can be played and 
        /// controled with a while loop inside of the RunGame() method
        /// Finaly calls RunGame() 
        /// </summary>
        public void Start()
        {
            // changes game status to playing on start to enable playtime
            // operations
            gameStatus = GameStatus.playing;

            // Calls Further game methods
            // starts a a game loop
            RunGame();

        }


        /// <summary>
        /// Called by the Start() method. 
        /// Calls Welcome() (that displays a welcome & explanation text)
        /// Loops the game while the game status is playing.
        /// While in the loop it:
        /// - Checks for a draw         => CheckForDraw()
        /// - Updates the board         =>UpdateBoard()
        /// - Decides the player turn   => DecidePlayerTurn()
        /// /// </summary>
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
                DecidePlayerTurn();
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
            // Instance of FileDirectory 
            FileDirectory fileDirectory = new FileDirectory();

            string welcomeText = "/ProjectGaloDaVelha/GameData/WelcomeText.txt";

            // try code
            try
            {   

                // Enter before text
                Console.WriteLine(); 
                
                // use stream reader to read text
                using (StreamReader sr = new StreamReader(fileDirectory.GetDir() 
                + welcomeText))
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

                // whait for any input
                Console.ReadLine();

            }

            // Catches any exceptions
            catch (Exception error)
            {
                // Print error message
                Console.WriteLine(error.Message);
            }

        }

        /// <summary>
        /// Method that creates the layout boardgame
        /// using character with "for" loops to each row and colum
        /// 
        /// It also creates the remaining pieces menu
        /// </summary>
        private void UpdateBoard()
        {
            // Enter on console
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
                    ($"| {board.GetBoard()[row, col]}\u001b[0m ".PadRight(9));
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
                    if (index < piecesArray.Length)
                    {
                        // Ajusta a largura da coluna
                        Console.Write 
                        ($"{piecesArray[index].GetPieceType()}[{index}]".PadRight(15));
                    }

                }
                // Nova linha após cada linha de elementos
                Console.WriteLine(); 
            }

        }


        /// <summary>
        /// Turn value starts at 1. If turn is a odd number, its player 1 turn, 
        /// else is player 2 turn
        /// </summary>
        private void DecidePlayerTurn()
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
        /// If the number of pieces available array is 0, call a get method that 
        /// return a draw match
        /// </summary>
        private void CheckForDraw()
        {

            if (piecesArray.Length < 1)
            {
                // Set game status to draw
                EndGame(GameStatus.draw);

            }

        }


        /// <summary>
        /// This method is where the console asks the input of the player.
        /// Such as witch place you want to place the piece, 
        /// and what piece do you want.
        /// In case the input is not valid, error messages will appeard.
        /// 
        /// Afher that input is valid, it takes the pieces available array 
        /// and removes the piece that the player as choosen.
        /// 
        /// Finally, there a for cicle to count each sequence possible to win the game,
        /// counting the vertical, horizontal and diagonal lines. If theres no sequence, 
        /// the code just ignores and moves to the next turn  
        /// </summary>
        private void SetPieceOnBoard()
        {

            // Suport Variables 

            // ...
            bool letter_dont_exist = true;

            // Mensagem para quem ganhou, para certificar que a 
            // mensagem só dá print 1 vez
           

            string user_place, user_piece_string;

            string[] visualPieces = new string[16];

            int user_piece;


            // Muda cor para vermelho
            Console.WriteLine("\u001b[31m[Legenda: B = Grande" 
            +"|| s = Pequeno] || Sair do jogo = ESC]\n");

            // ---------  WAITING HERE FOR NOW ---------
            Console.Write("\u001b[0m"); // Muda cor para branco


            Console.WriteLine
            ($"\u001b[36m==[ {player} ]==\u001b[0m");


            Console.Write("Escreve a letra onde deseja colocar a peça: ");

            user_place = Console.ReadLine().ToUpper();


            if (user_place == "ESC")
            {

                EndGame(GameStatus.exit);

                
            }

            //Se o input for maior de 1 caracter e não for ESC
            while (user_place != "ESC" && user_place.Length > 1)
            {
                if (user_place == "ESC")
                {
                    EndGame(GameStatus.exit);
                }
                
                Console.Write("A letra tem mais do que 1 caracter, " 
                +"insira a letra novamente: ");
                user_place = Console.ReadLine().ToUpper();

            }


            Console.Write("Qual é o numero da peça que deseja: ");
            user_piece_string = Console.ReadLine();
          

            if (user_piece_string == "ESC")
            {
                EndGame(GameStatus.exit);
            }

            //Se o input do número não for um numero valido:
            while (!int.TryParse(user_piece_string, out user_piece))
            {
                Console.Write("Por favor, insira um número válido: ");
                user_piece_string = Console.ReadLine();

                if (user_piece_string == "ESC")
                {
                    EndGame(GameStatus.exit);

                }

            }
            
            user_piece = int.Parse(user_piece_string);

            //Se o input do número for maior/menos que os numeros existentes: 
            while (user_piece > piecesArray.Length || user_piece < 0)
            {
                Console.Write("O número atribuido à peça não existe," 
                +"insira o número novamente: ");

                user_piece = int.Parse(Console.ReadLine());

            }

         
            // While the code doenst know that the letter given by the player exists:  
            while (letter_dont_exist)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        // if letter place given by the player exist in the boargame:
                        if (board.GetBoard()[i, j] == user_place)
                        {


                            if(user_piece < piecesArray.Length 
                            && user_piece >= 0)
                            {
                                // representação visual do array
                                //  string = piecesArray[user_piece].GetPieceType();

                                board.GetBoard()[i, j] = 
                                piecesArray[user_piece].GetPieceType();

                                // representação lógica do array
                                piecesVerified[i, j] = piecesArray[user_piece];

                                List<string> pieceTypeList = 
                                piecesArray.Select
                                (piece => piece.GetPieceType()).ToList();



                                pieceTypeList.RemoveAt(user_piece);

                                visualPieces = pieceTypeList.ToArray();
                                

                                // representação lógica do array
                                List<Piece> pecas_list_code =
                                new List<Piece>(piecesArray);
                                pecas_list_code.RemoveAt(user_piece);
                                piecesArray = pecas_list_code.ToArray();

                                // now we know that the letter exists
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

                Console.Write
                ("Essa letra não existe no tabuleiro, insira a letra novamente: ");
                user_place = Console.ReadLine().ToUpper();

                if (user_place == "ESC")
                {

                    EndGame(GameStatus.exit);        
                }

            }

            VerfifiedGameStatus();

        }



        /// <summary>
        /// 
        /// </summary>
        private void VerfifiedGameStatus()
        {

            bool mensagemExibida = false; 


            // Check lines sequence horizontal, vertical and diagnoal
            for (int i = 0; i < piecesVerified.GetLength(0); i++)
            {

                //  
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

                // Se a cor, forma, hole e tamanho for igual:
                for (j = 1, k = 1, n = 3; j < 
                piecesVerified.GetLength(1); j++, k++, n--) 
                {
                    // Verificação horizontal
                    if (piecesVerified[i, j] != null && 
                    piecesVerified[i, j - 1] != null) // Se não for vazio
                    {

                        if (piecesVerified[i, j].GetPieceColor() == 
                        piecesVerified[i, j - 1].GetPieceColor())
                        {
                            counter_ColorHorizontal++;

                        }
                        else
                        {
                            counter_ColorHorizontal = 1;
                        }

                        if (piecesVerified[i, j].GetPieceShape() == 
                        piecesVerified[i, j - 1].GetPieceShape())
                        {
                            counter_ShapeHorizontal++;
                        }
                        else
                        {
                            counter_ShapeHorizontal = 1;
                        }

                        if (piecesVerified[i, j].GetPieceHole() == 
                        piecesVerified[i, j - 1].GetPieceHole())
                        {
                            counter_HoleHorizontal++;
                        }
                        else
                        {
                            counter_HoleHorizontal = 1;
                        }

                        if (piecesVerified[i, j].GetPieceSize() ==
                         piecesVerified[i, j - 1].GetPieceSize())
                        {
                            counter_SizeHorizontal++;
                        }
                        else
                        {
                            counter_SizeHorizontal = 1;
                        }

                        if ((counter_ColorHorizontal == 4 ||
                         counter_ShapeHorizontal == 4 || 
                         counter_HoleHorizontal == 4 || 
                         counter_SizeHorizontal == 4) 
                         && !mensagemExibida)

                        {
                            mensagemExibida = true;
                            Console.WriteLine
                            ($"***********************************\n"); 
                       

                            switch (player)
                            {
                                case Player.Player1:
                                    {
                                        EndGame(GameStatus.player1Win,
                                        "na horizontal!");
                                        break;
                                    }
                                case Player.Player2:
                                    {
                                        EndGame(GameStatus.player2Win,
                                        "na horizontal!");
                                        break;
                                    }
                            }

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
                        == 4 || counter_HoleVertical == 4 || counter_SizeVertical 
                        == 4) && !mensagemExibida)
                        {
                            mensagemExibida = true;
                            Console.WriteLine
                            ($"***********************************\n"); 

                            switch (player)
                            {
                                case Player.Player1:
                                    {
    
                                        EndGame(GameStatus.player1Win,
                                        "na vertical!");
                                        break;
                                    }
                                case Player.Player2:
                                    {

                                        EndGame(GameStatus.player2Win,
                                        "na vertical!");
                                        break;
                                    }
                            }
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

                        if ((counter_ColorDiag_L == 4 || counter_ShapeDiag_L == 
                        4 ||counter_HoleDiag_L == 4 || counter_SizeDiag_L == 4) 
                        && !mensagemExibida)
                        {
                            mensagemExibida = true;

                            Console.WriteLine
                            ($"***********************************\n"); 


                            switch (player)
                            {
                                case Player.Player1:
                                    {
                                        EndGame(GameStatus.player1Win,
                                        "na diagonal da esquerda!");
                                        break;
                                    }
                                case Player.Player2:
                                    {
                                        EndGame(GameStatus.player2Win,
                                        "na diagonal da esquerda!");
                                        break;
                                    }
                            }
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

                        if ((counter_ColorDiag_R_ == 4 ||
                         counter_ShapeDiag_R == 4
                        || counter_HoleDiag_R == 4 ||
                         counter_SizeDiag_R == 4) && !mensagemExibida)
                        {
                            mensagemExibida = true;
                            Console.WriteLine
                            ($"***********************************\n"); 


                            switch (player)
                            {
                                case Player.Player1:
                                    {
                                        EndGame(GameStatus.player1Win,
                                        "na diagonal da direita!");
                                        break;
                                    }
                                case Player.Player2:
                                    {
                                        EndGame(GameStatus.player2Win,
                                        "na diagonal da direita!");
                                        break;
                                    }
                            }
                       
                            
                        }
                        
                    }
                }
            }
            Console.WriteLine
            ($"***********************************\n");
        }

        /// <summary>
        /// Prints the result of the end of the match, 
        /// like (win, draw or quit) condition
        /// </summary>
        /// <param name="status">Enum game status</param>
        /// <param name="winCondition">string condition of win</param>
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

            // update board one last time
            UpdateBoard(); 


            Console.WriteLine
            ("Utilize o comando: dotnet run --project"
            +" ProjectGaloDaVelha para jogar novamente!");
                       
            // exit game 
            // similar command to return 
            Environment.Exit(0); 
            
        }

    }

}