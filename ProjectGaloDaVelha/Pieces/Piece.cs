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

   
        /// <summary>
        ///  Constructor of Piece class
        ///  
        /// </summary>
        /// <param name="setSize">Enum </param>
        /// <param name="setColor">Enum</param>
        /// <param name="setShape">Enum</param>
        /// <param name="setHole">Enum</param>
        public Piece(PieceSize setSize, PieceColor setColor, 
        PieceShape setShape, PieceHole setHole)
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newShape"></param>
        /// <returns></returns>
        private PieceShape SetPieceShape(PieceShape newShape)
        {
          
            shape = newShape;

            return shape;

        }
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="puncture"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetPieceSize()
        {
            // returns string of size
            return size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetPieceColor()
        {
            // returns string of color
            return color;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PieceShape GetPieceShape()
        {
            // returns string of shape
            return shape;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetPieceHole()
        {
            // returns boolean of hole
            return hasHole;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetPieceType()
        {
            // returns string of pieceType
            return pieceType;
        }

    }

}