
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
        private string color;

        // ref to PieceShape enum
        private string shape;

        // ref to PiecePuncture enum
        private bool puncture;

   
        // Class constructor
        public Pieces(PieceSize newSize, PieceColor color, PieceShape newShape, PiecePuncture puncture)
        {
            // Set Size
            SetPieceSize(newSize);

            // Set Color
            SetPieceColor(color);

            // Set Shape
            SetPieceShape(newShape);
        
            // Set Puncture
            SetPiecePuncture(puncture);


            // IF shape is circle && has hole => cb
            //h

            // IF NOT => cf 
            //h

            // IF shape is square && has hole => a0
            //h

            // IF NOT => a1
            //h


            // TODO: Implement pieceType
            // pieceType = color + shape + hole + size;


            // \u001b[32m + "\" + u25 + h + size


            switch(newShape)
            {
                case PieceShape.circle:
                {
                    if(this.puncture)
                    {
                        pieceType = this.color + this.shape + "cf" + size;
                    }
                    else
                    {
                        pieceType = this.color + this.shape + "cb" + size;
                    }
                    break;
                }

                case PieceShape.square:
                {
                    if(this.puncture)
                    {
                        pieceType = this.color +  shape + "a0" + size;
                    }
                    else
                    {
                        pieceType = this.color + shape + "a1" + size;
                    }
                    break;
                }
            }     

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
        private string SetPieceColor(PieceColor newColor)
        {

            switch (newColor)
            {
                case PieceColor.color1:
                {
                    // green
                    color = "\u001b[32m";
                    break;
                }
                   
                case PieceColor.color2:
                {
                    // yellow
                    color = "\u001b[33m";
                    break;
                }
                    
            }

            return color;
        
        }


        private string SetPieceShape(PieceShape newShape)
        {
            switch (newShape)
            {
                case PieceShape.circle:
                {
                    // circle
                    shape = "'\''u25";
                    break;
                }
                case PieceShape.square:
                {
                    // square
                    shape = "'\''u25";
                    break;
                }
               
            }

            return shape;
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
            return puncture;
        }

        // Getters & Setters
        // Get & Set Piece shape
        //public PieceShape SetPieceShape { get; set; }

    }

}