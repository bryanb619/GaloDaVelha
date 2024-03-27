using System.Drawing;

namespace ProjectGaloDaVelha
{
    /// <summary>
    /// 
    /// </summary>
    public class Pieces
    {
        // Class attributes

        private string pieceType; 

        // ref to PieceSize enum
        private string size;

        // ref to PieceColor enum
        private Color color;

        // ref to PieceShape enum
        private PieceShape shape;

        // ref to PiecePuncture enum
        private bool puncture;

   
        // Class constructor
        public Pieces(PieceSize size, PieceColor color, PieceShape shape, PiecePuncture puncture)
        {
            // Set Size
            SetPieceSize(size);

            // Set Color
            SetPieceColor(color);

            // Set Shape
            SetPieceShape(shape);
        
            // Set Puncture
            SetPiecePuncture(puncture);


            // TODO: Implement pieceType
            // pieceType = size + color + shape + puncture;

        }

        // Setters

        // Setter for Piece Size
        private string SetPieceSize(PieceSize newSize)
        {
   
            switch(newSize)
            {
                case PieceSize.small:
                {
                    size = "s";
                    break;
                }
                case PieceSize.big:
                {
                    size = "B";
                    break;
                }
            }
        
            return size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newColor">Enum passing color type</param>
        /// <returns>Returns actual value of color</returns>
        private Color SetPieceColor(PieceColor newColor)
        {

            switch (newColor)
            {
                case PieceColor.color1:
                {
                    color = Color.Red;
                    break;
                }
                   
                case PieceColor.color2:
                {
                    color = Color.Blue;
                    break;
                }
                    
            }

            return color;
        
        }


        private string SetPieceShape(PieceShape shape)
        {
            switch (shape)
            {
                case PieceShape.circle:
                {
                    this.shape = PieceShape.circle;
                    break;
                }
                case PieceShape.square:
                {
                    this.shape = PieceShape.square;
                    break;
                }
               
            }

            return this.shape.ToString();
        }

        private bool SetPiecePuncture(PiecePuncture puncture)
        {
            switch (puncture)
            {
                case PiecePuncture.none:
                {
                    this.puncture = false;
                    break;
                }
                
                case PiecePuncture.punctured:
                {
                    this.puncture = true;
                    break;
                }
               
            }

            return this.puncture;
        }


        // Getters

        public string GetPieceType()
        {
            return pieceType;
        }

        // Get Piece Size
        public string GetPieceSize()
        {
            return size;
        }

        public string GetPieceColor()
        {
            return color.ToString();
        }

        public string GetPieceShape()
        {
            return shape.ToString();
        }

        public bool GetPiecePuncture()
        {
            return puncture.ToString() == "True" ? true : false;
        }

        // Getters & Setters
        // Get & Set Piece shape
        //public PieceShape SetPieceShape { get; set; }

    }

}