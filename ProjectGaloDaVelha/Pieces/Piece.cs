namespace ProjectGaloDaVelha.Pieces
{
    /// <summary>
    /// Base class for Piece.
    /// This Class is responsible for storing the piece attributes.
    /// Such type is representated by a string. 
    /// The atrributes are used to create the equation of what piece it is.
    /// pieceType = color + pieceConfig + size; 
    /// 
    /// </summary>
    public class Piece
    {
        // --------------------------- Attributes --------------------------- //

        private string              pieceType; 

        // ref to PieceSize enum
        private string              size;

        // ref to PieceColor enum
        private string              color;

        // ref to PieceShape enum
        private PieceShape          shape;

        // ref to piece hole
        private bool                hasHole;


        // -------------------------- Constructor --------------------------- //
   
        /// <summary>
        /// Constructor of Piece class.
        /// Receives 4 parameters being each type an enumerator
        /// this constructor sets the piece attributes for:
        /// SIZE - COLOR - SHAPE - HOLE
        /// Atributes are equalized by functions calls except shape
        /// Finaly this piece will have a type that is equal to the sum of 
        /// strings defined by the functions.
        /// </summary>
        /// <param name="setSize">Enum: Size of piece </param>
        /// <param name="setColor">Enum: Color of piece </param>
        /// <param name="setShape">Enum: Shape of piece</param>
        /// <param name="setHole">Enum: Hole of piece</param>
        public Piece( PieceSize setSize, PieceColor setColor, 
                      PieceShape setShape, PieceHole setHole)
        {

            // Set Piece Size
            size                = SetPieceSize(setSize);

            // Set Piece Color
            color               = SetPieceColor(setColor);

            //Set piece shape
            shape               = setShape;

            // Set Piece Hole
            hasHole             = SetPieceHole(setHole);

            // Set PieceType 
            pieceType           = SetPieceType();
        }


        // --------------------------- Setters ------------------------------ //

        /// <summary>
        /// Setter for Piece Size.
        /// Function receives a PieceSize enumemrator and acording to the enum 
        /// value state, the switch case equalizes 
        ///  
        /// </summary>
        /// <param name="newSize">Enum: Size of Piece</param>
        /// <returns>returns the string that symbolizes the size state</returns>
        private string SetPieceSize(PieceSize newSize)
        {
            // Suport string to be returned
            string rSize = ""; 
   
            // decide what string to equalize to, based on the enum value
            switch(newSize)
            {
                case PieceSize.small:
                {
                    // piece is now of type small
                    rSize = "s";
                    break;
                }
                case PieceSize.big:
                {
                    // piece is now of type BIG
                    rSize = "B";
                    break;
                }
            }


            // return string size s or B
            return rSize;
        }

        /// <summary>
        ///  Functions sets the color of the piece instance
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
        /// Setter for Piece Hole.
        /// Function receives a PieceHole enumerator and acording to the value
        /// returns a bool value that states if it has a hole or not.
        /// </summary>
        /// <param name="hole">Enum </param>
        /// <returns>returns bool stating hole condition</returns>
        private bool SetPieceHole(PieceHole hole)
        {
            // Supoort variable
            // 
            bool rHasHole = false;

            switch (hole)
            {
                case PieceHole.none:
                {
                    // 
                    rHasHole = false;
                    break;
                }
                
                case PieceHole.hole:
                {
                    // 
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
        /// Getter for Piece Color
        /// </summary>
        /// <returns>returns string value of Piece Color type</returns>
        public string GetPieceColor()
        {
            // returns string of color
            return color;
        }
        
        /// <summary>
        /// Getter for Piece Shape
        /// </summary>
        /// <returns>returns enum of Piece Shape</returns>
        public PieceShape GetPieceShape()
        {
            // returns string of shape
            return shape;
        }
        
        /// <summary>
        /// Getter for Piece Hole
        /// </summary>
        /// <returns>returns bool value of hasHole</returns>
        public bool GetPieceHole()
        {
            // returns boolean of hole
            return hasHole;
        }

        /// <summary>
        ///  Getter for Piece Type
        /// </summary>
        /// <returns>returns string type of piece</returns>
        public string GetPieceType()
        {
            // returns string of pieceType
            return pieceType;
        }
    }
    // ------------------------- END ---------------------------------------- //

}