using System;


namespace ProjectGaloDaVelha
{

    public class Game
    {
        public void Start()
        {

            Console.WriteLine("Welcome to Galo da Velha!");

            //Console.ReadLine();

            //BuildBoard();
            DisplayBoardUI();
            //ManageTurns();
            //MovePiece();
            //CheckForWinner();
            //EndGame();
        }
        //----------------------------------------------------------------------

        private void ManageTurns()
        {


        }

        private void MovePiece()
        {

        }

        //----------------------------------------------------------------------


        private void DisplayBoardUI()
        {
            
            //Console.Clear(); // Limpa a tela antes de desenhar o tabuleiro

            // Loop para desenhar as linhas e colunas do tabuleiro
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
            
        }
        
            

        

        private void BuildBoard()
        {

        }

        //private void 


    }
    
}