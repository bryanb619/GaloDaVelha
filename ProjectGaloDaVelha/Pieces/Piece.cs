namespace ProjectGaloDaVelha.Pieces
{
    /// <summary>
    /// 
    /// </summary>
    public class Piece
    {
        // Class attributes

        private string pieceType; 

        // ref to PieceSize enum
        private string size;

        // ref to PieceColor enum
        private string color;

        // ref to PieceShape enum
        private PieceShape shape;

        // ref to piece hole
        private bool hasHole;

   
        // Class constructor
        public Piece(PieceSize newSize, PieceColor color, PieceShape newShape, PieceHole hole)
        {

            // Set Size
            SetPieceSize(newSize);

            // Set Color
            SetPieceColor(color);

            // Set Hole
            SetPiecePuncture(hole);

            shape = newShape;

            // DONE: Implement pieceType
            SetPieceType();

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
                case PieceColor.green:
                {
                    // green
                    color = "\u001b[32m";
                    break;
                }
                   
                case PieceColor.yellow:
                {
                    // yellow
                    color = "\u001b[33m";
                    break;
                }
                    
            }

            return color;
        
        }

        /*
        private  SetPieceShape(PieceShape newShape)
        {
           switch(newShape)
           {
               case PieceShape.circle:
               {
                    shape = PieceShape.circle;
                    break;
               }
               case PieceShape.square:
               {
                   
                   break;
               }
           }

           return shape;

        }
        */

        private bool SetPiecePuncture(PieceHole puncture)
        {
            switch (puncture)
            {
                case PieceHole.none:
                {
                    hasHole = false;
                    break;
                }
                
                case PieceHole.hole:
                {
                    hasHole = true;
                    break;
                }
               
            }

            return hasHole;
        }


        private void SetPieceType()
        {
            char pieceConfig = '\0';

            switch(shape)
            {

                // in case of circle shape
                case PieceShape.circle:
                {
                    // in case has hole 
                    if(hasHole) {pieceConfig = '\u25cf';}
                    
                    else {pieceConfig = '\u25cb';}

                    break;
                }

                case PieceShape.square:
                {
                    if(hasHole) {pieceConfig = '\u25a0';}

                    else{pieceConfig = '\u25a1';}

                    break;
                }
            } 

            pieceType = color + pieceConfig + size;    
        }


        // Getters

        // Get Piece Size
        
        public string GetPieceSize()
        {
            return size;
        }

        public string GetPieceColor()
        {
            return color;
        }

        public string GetPieceShape()
        {
            return shape.ToString();
        }

        public bool GetPieceHole()
        {
            return hasHole;
        }

        public string GetPieceType()
        {
            return pieceType;
        }

        // Getters & Setters
        // Get & Set Piece shape
        //public PieceShape SetPieceShape { get; set; }

    }

}