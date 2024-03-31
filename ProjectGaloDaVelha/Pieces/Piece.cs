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
        public Piece(PieceSize setSize, PieceColor setColor, PieceShape setShape, PieceHole setHole)
        {

            // Set Size
            SetPieceSize(setSize);

            // Set Color
            SetPieceColor(setColor);

            //Set piece shape
            SetPieceShape(setShape);

            // Set Hole
            SetPiecePuncture(setHole);

            // Set pieceType 
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

        private PieceShape SetPieceShape(PieceShape newShape)
        {
          
            shape = newShape;

            return shape;

        }
   

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
            // returns string of size
            return size;
        }

        public string GetPieceColor()
        {
            // returns string of color
            return color;
        }

        public string GetPieceShape()
        {
            // returns string of shape
            return shape.ToString();
        }

        public bool GetPieceHole()
        {
            // returns boolean of hole
            return hasHole;
        }

        public string GetPieceType()
        {
            // returns string of pieceType
            return pieceType;
        }

    }

}