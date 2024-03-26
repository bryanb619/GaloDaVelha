using System.Drawing;

namespace ProjectGaloDaVelha
{
    public class Pieces
    {

        //private string name;

        //private Color color;

        private PieceSize size;

        private PieceColor color;

        private PieceShape shape;

        private PiecePuncture puncture;

    

       // public string Piece { get; set; }

        public Pieces
        (PieceSize size,PieceColor color, PieceShape shape, PiecePuncture puncture)
        {

            this.size = size;

            this.color = color;

            this.shape = shape;

            this.puncture = puncture;

        }

        // Setters
    }

}