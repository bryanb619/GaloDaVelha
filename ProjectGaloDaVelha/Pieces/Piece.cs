namespace ProjectGaloDaVelha.Pieces
{
    /// <summary>
    ///  Base class for Piece
    ///  This Class is responsible for storing the piece attributes
    ///  such type representated by a string further on
    /// </summary>
    public class Piece
    {
        // --------------------------- Attributes --------------------------- //

        private string          pieceType; 

        // ref to PieceSize enum
        private string          size;

        // ref to PieceColor enum
        private string          color;

        // ref to PieceShape enum
        private PieceShape      shape;

        // ref to piece hole
        private bool            hasHole;


        // -------------------------- Constructor --------------------------- //
   
        /// <summary>
        ///  Constructor of Piece class
        ///  Receives 4 parameters being each type an enumerator
        ///  This constructor sets the piece attributes for:
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
            size            = SetPieceSize(setSize);

            // Set Color
            color           = SetPieceColor(setColor);

            //Set piece shape
            shape           = setShape;

            // Set Hole
            hasHole         = SetPieceHole(setHole);

            // Set pieceType 
            pieceType        = SetPieceType();
        }


        // --------------------------- Setters ------------------------------ //

        /// <summary>
        ///  Setter for Piece Size
        /// </summary>
        /// <param name="newSize"></param>
        /// <returns></returns>
        private string SetPieceSize(PieceSize newSize)
        {

            string rSize = ""; 
   
            switch(newSize)
            {
                case PieceSize.small:
                {
                    rSize = "s";
                    break;
                }
                case PieceSize.big:
                {
                    rSize = "B";
                    break;
                }
            }
        
            return rSize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newColor">Enum passing color type</param>
        /// <returns>Returns string value of color</returns>
        private string SetPieceColor(PieceColor newColor)
        {

            string rColor = "";

            switch (newColor)
            {
                case PieceColor.green:
                {
                    // Green
                    rColor= "\u001b[32m";
                    break;
                }
                   
                case PieceColor.yellow:
                {
                    // Yellow
                    rColor= "\u001b[33m";
                    break;
                }
                    
            }

            // string color
            return rColor;
        
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hole">Enum </param>
        /// <returns>returns bool stating hole condition</returns>
        private bool SetPieceHole(PieceHole hole)
        {

            bool rHasHole = false;

            switch (hole)
            {
                case PieceHole.none:
                {
                    rHasHole = false;
                    break;
                }
                
                case PieceHole.hole:
                {
                    rHasHole = true;
                    break;
                }
               
            }
            
            // bool hasHole
            return rHasHole;
        }

        /// <summary>
        ///  Sets Piece Type
        ///  Uses all initialized & 
        /// </summary>
        private string SetPieceType()
        {
            //Support variables
            string rPieceType = "";
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
            rPieceType = color + pieceConfig + size;    
            
            return rPieceType;
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