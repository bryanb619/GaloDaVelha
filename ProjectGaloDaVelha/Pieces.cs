using System.Drawing;

namespace ProjectGaloDaVelha
{
    public class Pieces
    {

        private string name;

        private Color color;
        

       // public string Piece { get; set; }

        public Pieces(string piece, Color color)
        {
            // set piece name
            this.name = piece;
            // set color
            this.color = color;
        }
    }

}