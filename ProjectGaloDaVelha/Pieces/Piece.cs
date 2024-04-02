namespace ProjectGaloDaVelha.Pieces
{
    /// <summary>
    /// 
    /// </summary>
    public class Piece
    {
        // --------------------- Attributes --------------------- //

        private string pieceType; 

        // ref to PieceSize enum
        private string size;

        // ref to PieceColor enum
        private string color;

        // ref to PieceShape enum
        private PieceShape shape;

        // ref to piece hole
        private bool hasHole;


        // -------------------------- Constructor --------------------------- //
   
        /// <summary>
        ///  Constructor of Piece class
        ///  Receives 4 parameters being each type an enumerator
        ///  This constructor sets the piece attributes:
        ///  SIZE - COLOR - SHAPE - HOLE
        ///  
        ///   
        /// </summary>
        /// <param name="setSize">Enum Size </param>
        /// <param name="setColor">Enum Color </param>
        /// <param name="setShape">Enum Shape</param>
        /// <param name="setHole">Enum Hole</param>
        public Piece(
        PieceSize setSize, 
        PieceColor setColor, 
        PieceShape setShape, 
        PieceHole setHole)
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


        // --------------------------- Setters ------------------------------ //

        /// <summary>
        ///  Setter for Piece Size
        /// </summary>
        /// <param name="newSize"></param>
        /// <returns></returns>
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
        /// <returns>Returns string value of color</returns>
        private string SetPieceColor(PieceColor newColor)
        {

            switch (newColor)
            {
                case PieceColor.green:
                {
                    // Green
                    color = "\u001b[32m";
                    break;
                }
                   
                case PieceColor.yellow:
                {
                    // Yellow
                    color = "\u001b[33m";
                    break;
                }
                    
            }

            // string color
            return color;
        
        }
        
        /// <summary>
        ///  Setter for Piece Shape
        ///  Receives an enumerator of PieceShape type
        ///  sets the shape attribute equal to parameter received
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
        /// <param name="hole">Enum </param>
        /// <returns>returns bool stating hole condition</returns>
        private bool SetPiecePuncture(PieceHole hole)
        {
            switch (hole)
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
            
            // bool hasHole
            return hasHole;
        }

        /// <summary>
        ///  Sets Piece Type
        ///  Uses all initialized & 
        /// </summary>
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

            // set pieceType
            pieceType = color + pieceConfig + size;    
        }


        // --------------------------- Getters ------------------------------ //

        /// <summary>
        ///  Getter for Piece Size
        ///  Function returns string of piece size
        /// 
        ///  Size is set by the SetPieceSize function
        /// </summary>
        /// <returns>returns attribute string size</returns>
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
    // ------------------------- END ---------------------------------------- //

}