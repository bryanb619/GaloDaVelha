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
            // ----------------------- Yellow pieces ------------------------ //

            // Instances of Yellow pieces
            // 7 pieces in total 
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


            // ----------------------- Green pieces ------------------------- //

            // Instances of Yellow pieces
            // 7 pieces in total 
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
        // ------------------- END OF VARIABLES ----------------------------- //

        
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
            // -------------- Suport Variables -------------------------------//

            // Instance of FileDirectory 
            FileDirectory fileDirectory = new FileDirectory();

            // path of text file
            string welcomeText = "/ProjectGaloDaVelha/GameData/WelcomeText.txt";

            // Error Handling
            // try to read & output file content
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

            // Catches any exceptions as output
            catch (Exception error)
            {
                // Print exception message
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

            // Draws the last line
            for (int col = 0; col < 4; col++)
            {
                Console.Write("+----");
            }
            Console.WriteLine("+");

            Console.WriteLine("");


            
            //Shows available pieces
            Console.WriteLine("[---Peças disponiveis---]");

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    int index = row * 4 + col; // Calculates correct index
                    if (index < piecesArray.Length)
                    {
                        //Adjust the width of the collun 
                        Console.Write 
                        ($"{piecesArray[index].GetPieceType()}[{index}]".PadRight(15));
                    }

                }
                //New line afther each line of elements
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
                // Player 1 is now playing
                player = Player.Player1;
            }

            // Player 2 turn -> 2, 4, 6
            else
            {   // Player 2 is now playing
                player = Player.Player2;
            }

            // proceed to set pieces on board
            SetPieceOnBoard();
        }


        
        /// <summary>
        /// If the number of pieces available array is 0, call a get method that 
        /// that sets game to draw status and terminates the game
        /// the if stamente becomes valid once the length of the array
        /// (piecesArray) is 0 or lower. In other words, there are no more pieces
        /// available to play & now one has won the game, since checkForDraw()
        /// is the first method to run in the game loop.
        /// </summary>
        private void CheckForDraw()
        {
            // If there are no more pieces available
            // Set game status to draw.
            // End the game with a draw status
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

            // -------------- Suport Variables -------------------------------//

            // If one of the letters given by the user donst exist in the boargame 
            bool letter_dont_exist = true;

            // user_place = letter given by the user
            //user_piece_string = piece number given by the user in string type
            string user_place, user_piece_string;

            //Pieces Available array
            string[] visualPieces = new string[16];

            //user_piece = piece number given by the user but in int value
            int user_piece;



            
            //Change color to red
            Console.WriteLine("\u001b[31m[Legenda: B = Grande" 
            +"|| s = Pequeno] || Sair do jogo = ESC]\n");

            // ---------  WAITING HERE FOR NOW ---------
            Console.Write("\u001b[0m"); // Change color to white




            // ------------------------ Input ------------------------------- //

            Console.WriteLine
            ($"\u001b[36m==[ {player} ]==\u001b[0m");

            // Request input for piece placement 
            Console.Write("Escreve a letra onde deseja colocar a peça: ");

            // store value of input & convert to upper case
            user_place = Console.ReadLine().ToUpper();


            // indentify if input is = EXIT
            if (user_place == "ESC")
            {

                // EXIT game with exit status
                EndGame(GameStatus.exit);

            }

            //If input is higher than 1 caracter and its not "ESC"
            while (user_place != "ESC" && user_place.Length > 1)
            {
                // ask for a valid input
                if (user_place == "ESC")
                {
                    // EXIT game with exit status
                    EndGame(GameStatus.exit);
                }
                
                // Ask for a valid input
                Console.Write("A letra tem mais do que 1 caracter, " 
                +"insira a letra novamente: ");

                // store input
                user_place = Console.ReadLine().ToUpper();

            }

            // Request piece number
            Console.Write("Qual é o numero da peça que deseja: ");
            // store value of input
            user_piece_string = Console.ReadLine();
          

            //If input is = EXIT
            if (user_piece_string == "ESC")
            {
                // EXIT game with exit status
                EndGame(GameStatus.exit);
            }

            
            //If input number is not a valid number
            while (!int.TryParse(user_piece_string, out user_piece))
            {
                // Ask for a valid input number
                Console.Write("Por favor, insira um número válido: ");
                user_piece_string = Console.ReadLine();

                // If input is = EXIT
                if (user_piece_string == "ESC")
                {
                    // EXIT game with exit status
                    EndGame(GameStatus.exit);

                }

            }
            
            // store value of input for piece
            user_piece = int.Parse(user_piece_string);

            
            //If input number is higher/less then available numbers 
            while (user_piece > piecesArray.Length || user_piece < 0)
            {
                // request a valid input again
                Console.Write("O número atribuido à peça não existe," 
                +"insira o número novamente: ");

                // store input
                user_piece = int.Parse(Console.ReadLine());

            }

         
            // While the code doenst know that the letter given by the player exists:  
            while (letter_dont_exist)
            {
                // Checks every element of the boardMap array
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        // if letter place given by the player exist in the boargame:
                        if (board.GetBoard()[i, j] == user_place)
                        {

                             // if number of the piece is lower than length of piecesArray
                            if(user_piece < piecesArray.Length 
                            && user_piece >= 0)
                            {
                                
                                // string = piecesArray[user_piece].GetPieceType();
                                //Visual representation of the pieces array (string)
                                board.GetBoard()[i, j] = 
                                piecesArray[user_piece].GetPieceType();

                                // logic representacion of the array (class Pieces)
                                piecesVerified[i, j] = piecesArray[user_piece];

                                //Able to print the pieces array (string)
                                //Convert array to list 
                                List<string> pieceTypeList = 
                                piecesArray.Select
                                (piece => piece.GetPieceType()).ToList();

                                //Remove element from the list
                                pieceTypeList.RemoveAt(user_piece);

                                //Convert list to array again
                                visualPieces = pieceTypeList.ToArray();
                                
                                //Change array values (class Pieces)
                                //Convert array to list 
                                List<Piece> pecas_list_code =
                                new List<Piece>(piecesArray);
                                
                                //Remove element from the list
                                pecas_list_code.RemoveAt(user_piece);

                                //Convert list to array again
                                piecesArray = pecas_list_code.ToArray();

                                // now we know that the letter exists
                                letter_dont_exist = false;

                                break;
                            }

                        }
                    }


                }

                //If letter exist, breaks while cicle
                if (letter_dont_exist == false)
                {
                    break;
                }

                Console.Write
                ("Essa letra não existe no tabuleiro, insira a letra novamente: ");
                user_place = Console.ReadLine().ToUpper();

                //If new user_place is ESC, exit the game
                if (user_place == "ESC")
                {
                    // EXIT game with exit status  
                    EndGame(GameStatus.exit);        
                }

            }

            //Calls method that verifies if any of the players 
            //made a sequence of pieces (Horizontal,Vertical and Diagnoal)
            VerfifiedGameStatus();

        }



        /// <summary>
        /// Verifieds the pieces sequence, if any player made a sequence
        /// (Vertical, Horizontal or Diagnoal). If its true, 
        /// return one of the gameStatus (Player1 Win, Player2 Win) 
        /// and then return the final print of the boardgame status
        /// </summary>
        private void VerfifiedGameStatus()
        {
            /// If Win status wanst printable yet, its false
            bool mensagemExibida = false; 


            // Check lines sequence horizontal, vertical and diagnoal
            for (int i = 0; i < piecesVerified.GetLength(0); i++)
            {

                // -------------- Suport Variables ---------------------------//
                // Sequence count numbers (Vertical,Horizontal and Diagnoal)

                // Horizontal
                int counterColorHorizontal      = 1;
                int counterShapeHorizontal      = 1;
                int counterHoleHorizontal       = 1;
                int counterSizeHorizontal       = 1;

                // Vertical
                int counterColorVertical        = 1;
                int counterShapeVertical        = 1;
                int counterHoleVertical         = 1;
                int counterSizeVertical         = 1;

                // LEFT Diagonal
                int counterColorDiag_L          = 1;
                int counterShapeDiag_L          = 1;
                int counterHoleDiag_L           = 1;
                int counterSizeDiag_L           = 1;

                // RIGHT Diagonal
                int counterColorDiag_R_         = 1;
                int counterShapeDiag_R          = 1;
                int counterHoleDiag_R           = 1;
                int counterSizeDiag_R           = 1;


                // K and N are speciall chars to verified diagonal sequences
                int j, k, n;
                

                // ------------------ Verifying code ------------------------ //

                // Cicle for that runs every sequence possible 
                //inside of the PiecesVerified Array
                for (j = 1, k = 1, n = 3; j < 
                piecesVerified.GetLength(1); j++, k++, n--) 
                {
                    // Horizontal Verification
                     //If 1 and 2 elements are not empty
                    if (piecesVerified[i, j] != null && 
                    piecesVerified[i, j - 1] != null)
                    {
                        //If element 1 and 2 as the same color:
                        if (piecesVerified[i, j].GetPieceColor() == 
                        piecesVerified[i, j - 1].GetPieceColor())
                        {
                            //Incress count for same Color in Horizontal
                            counterColorHorizontal++;

                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterColorHorizontal = 1;
                        }

                        //If element 1 and 2 as the same shape:
                        if (piecesVerified[i, j].GetPieceShape() == 
                        piecesVerified[i, j - 1].GetPieceShape())
                        {
                            // increment horizontal shape counter
                            counterShapeHorizontal++;
                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterShapeHorizontal = 1;
                        }

                        //If element 1 and 2 as the same hole:
                        if (piecesVerified[i, j].GetPieceHole() == 
                        piecesVerified[i, j - 1].GetPieceHole())
                        {
                            counterHoleHorizontal++;
                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterHoleHorizontal = 1;
                        }

                        //If element 1 and 2 as the same size:
                        if (piecesVerified[i, j].GetPieceSize() ==
                         piecesVerified[i, j - 1].GetPieceSize())
                        {
                            counterSizeHorizontal++;
                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterSizeHorizontal = 1;
                        }

                        //If any of the counter Horizontal sequences equals 4 
                        //and the message was not printed yet:
                        if ((counterColorHorizontal == 4 ||
                        counterShapeHorizontal == 4 || 
                        counterHoleHorizontal == 4 || 
                         counterSizeHorizontal == 4) 
                         && !mensagemExibida)

                        {
                            //Mensage will be printed
                            mensagemExibida = true;
                            Console.WriteLine
                            ($"***********************************\n"); 
                       
                            switch (player)
                            {
                                //If its player 1 turn, then player 1 wins
                                case Player.Player1:
                                {
                                    // End game with player1 win status
                                    // send adicional message (Horizontal win)
                                    EndGame(GameStatus.player1Win,
                                    "na horizontal!");
                                    break;
                                }

                                //If its player 2 turn, then player 2 wins
                                case Player.Player2:
                                {
                                    // End game with player2 win status
                                    // send adicional message (Horizontal win)
                                    EndGame(GameStatus.player2Win,
                                    "na horizontal!");
                                    break;
                                }
                            }
                        }
                    }

                    // Vertical Verification
                    //If 1 and 2 elements are not empty
                    if (piecesVerified[j, i] != null &&
                    piecesVerified[j - 1, i] != null) 
                    {
                        //If element 1 and 2 as the same color:
                        if (piecesVerified[j, i].GetPieceColor() ==
                         piecesVerified[j - 1, i].GetPieceColor())
                        {
                            //Incress count for same Color in Vertical
                            counterColorVertical++;
                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterColorVertical = 1;
                        }

                        //If element 1 and 2 as the same shape:
                        if (piecesVerified[j, i].GetPieceShape() ==
                         piecesVerified[j - 1, i].GetPieceShape())
                        {
                            counterShapeVertical++;
                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterShapeVertical = 1;
                        }

                        //If element 1 and 2 as the same hole:
                        if (piecesVerified[j, i].GetPieceHole() ==
                         piecesVerified[j - 1, i].GetPieceHole())
                        {
                            counterHoleVertical++;
                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterHoleVertical = 1;
                        }

                        //If element 1 and 2 as the same Size:
                        if (piecesVerified[j, i].GetPieceSize() ==
                         piecesVerified[j - 1, i].GetPieceSize())
                        {
                            counterSizeVertical++;
                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterSizeVertical = 1;
                        }

                        //If any of the counter Vertical sequences equals 4 
                        //and the message was not printed yet:
                        if ((counterColorVertical == 4 || counterShapeVertical
                        == 4 || counterHoleVertical == 4 || counterSizeVertical 
                        == 4) && !mensagemExibida)
                        {
                            //Mensage will be printed
                            mensagemExibida = true;
                            Console.WriteLine
                            ($"***********************************\n"); 

                            switch (player)
                            {
                                //If its player 1 turn, then player 1 wins
                                case Player.Player1:
                                {
                                    // End game with player1 win status
                                    // send adicional message (Vertical win)
                                    EndGame(GameStatus.player1Win,
                                    "na vertical!");
                                    break;
                                }

                                //If its player 2 turn, then player 2 wins
                                case Player.Player2:
                                {
                                    // End game with player2 win status
                                    // send adicional message (Vertical win)
                                    EndGame(GameStatus.player2Win,
                                    "na vertical!");
                                    break;
                                }
                            }
                        }
                    }


                    // DIAGONAL_LEFT Verification

                    //If 1 and 2 elements are not empty
                    if (i > 0 && j > 0 && piecesVerified[k - 1, j - 1] !=
                    null && piecesVerified[j, k] != null) 
                    
                    {

                        //If element 1 and 2 as the same color:
                        if (piecesVerified[k - 1, j - 1].GetPieceColor() ==
                         piecesVerified[k, j].GetPieceColor())
                        {
                            counterColorDiag_L++;

                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterColorDiag_L = 1;
                        }

                        //If element 1 and 2 as the same shape:
                        if (piecesVerified[k - 1, j - 1].GetPieceShape() ==
                        piecesVerified[k, j].GetPieceShape())
                        {
                            counterShapeDiag_L++;
                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterShapeDiag_L = 1;
                        }

                        //If element 1 and 2 as the same hole:
                        if (piecesVerified[k - 1, j - 1].GetPieceHole() ==
                        piecesVerified[k, j].GetPieceHole())
                        {
                            counterHoleDiag_L++;
                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterHoleDiag_L = 1;
                        }

                        //If element 1 and 2 as the same size:
                        if (piecesVerified[k - 1, j - 1].GetPieceSize() ==
                        piecesVerified[k, j].GetPieceSize())
                        {
                            counterSizeDiag_L++;
                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterSizeDiag_L = 1;
                        }

                        //If any of the counter Diagonal_Left sequences equals 4 
                        //and the message was not printed yet:
                        if ((counterColorDiag_L == 4 || counterShapeDiag_L == 
                        4 ||counterHoleDiag_L == 4 || counterSizeDiag_L == 4) 
                        && !mensagemExibida)
                        {
                            //Mensage will be printed
                            mensagemExibida = true;

                            Console.WriteLine
                            ($"***********************************\n"); 


                            switch (player)
                            {
                                case Player.Player1:
                                {
                                    // End game with player1 win status
                                    // send adicional message (Diag Left win)
                                    EndGame(GameStatus.player1Win,
                                    "na diagonal da esquerda!");

                                    break;
                                }
                                case Player.Player2:
                                {
                                    // End game with player2 win status
                                    // send adicional message (Diag Left win)   
                                    EndGame(GameStatus.player2Win,
                                    "na diagonal da esquerda!");

                                    break;
                                }
                            }
                        }
                        
                    }

                    // Verificação DIAGONAL_RIGHT Verification
                    //If 1 and 2 elements are not empty
                    if (i > 0 && j > 0 && piecesVerified[k - 1, n] != null &&
                    piecesVerified[k, n - 1] != null) 
                    {

                        //If element 1 and 2 as the same color:
                        if (piecesVerified[k - 1, n].GetPieceColor() ==
                         piecesVerified[k, n - 1].GetPieceColor())
                        {
                            counterColorDiag_R_++;

                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterColorDiag_R_ = 1;
                        }

                        //If element 1 and 2 as the same shape:
                        if (piecesVerified[k - 1, n].GetPieceShape()
                        == piecesVerified[k, n - 1].GetPieceShape())
                        {
                            counterShapeDiag_R++;
                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterShapeDiag_R = 1;
                        }

                        //If element 1 and 2 as the same hole:
                        if (piecesVerified[k - 1, n].GetPieceHole()
                        == piecesVerified[k, n - 1].GetPieceHole())
                        {
                            counterHoleDiag_R++;
                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterHoleDiag_R = 1;
                        }

                        //If element 1 and 2 as the same Size:
                        if (piecesVerified[k - 1, n].GetPieceSize() == 
                        piecesVerified[k, n - 1].GetPieceSize())
                        {
                            counterSizeDiag_R++;
                        }
                        else
                        {
                            //Reset count if sequence was interupted
                            counterSizeDiag_R = 1;
                        }

                        //If any of the counter Vertical sequences equals 4 
                        //and the message was not printed yet:
                        if ((counterColorDiag_R_ == 4 || counterShapeDiag_R == 4
                        || counterHoleDiag_R == 4 ||counterSizeDiag_R == 4) 
                        && !mensagemExibida)
                        {
                            //Mensage will be printed
                            mensagemExibida = true;
                            Console.WriteLine
                            ($"***********************************\n"); 


                            switch (player)
                            {
                                //If its player 1 turn, then player 1 wins
                                case Player.Player1:
                                {
                                    // End game with player1 win status
                                    // send adicional message (Diag Right win)
                                    EndGame(GameStatus.player1Win,
                                    "na diagonal da direita!");

                                    break;
                                }
                                
                                //If its player 2 turn, then player 2 wins
                                case Player.Player2:
                                {
                                    // End game with player2 win status
                                    // send adicional message (Diag Right win)
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
        /// like (win, draw or quit) condition.
        /// Depending on the match result, a extra message will be printed
        /// If the match is a draw, output is just "Empate!"
        /// if the match is a win, output could be "Jogador 1 ganhou" 
        /// + "Condition of win" that can be vertical, diagonal or horizontal.
        /// messages are combined with interpolation
        /// In any sitituation, the game ends.
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
                        // Player 1 message
                        message = "O jogador 1 ganhou";
                        break;
                    }

                // Player 2 wins
                case GameStatus.player2Win:
                    {
                        // Player 2 message
                        message = "O jogador 2 ganhou";
                        break;
                    }

                // Draw
                case GameStatus.draw:
                    {
                        // Draw message
                        message = "Empate!";
                        break;
                    }
                case GameStatus.exit:
                    {
                        // Exit message
                        message= "Jogo terminado!";
                        break;
                    }

                default: { break; }

            }


            // if win condition is not empty
            // concatenate message with win condition
            if(winCondition.Length > 1)
            {
               // message += winCondition;
               Console.WriteLine($"{message} {winCondition}");

            }
            else
            {
                // display final message without concatenation
                Console.WriteLine(message);

            }

            // update board one last time
            UpdateBoard(); 

            // print command to play again
            Console.WriteLine
            ("Utilize o comando: dotnet run --project"
            +" ProjectGaloDaVelha para jogar novamente!");
                       
            // exit game 
            // similar command to return 
            Environment.Exit(0); 
            
        }

    }

}