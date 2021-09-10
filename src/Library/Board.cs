using System;

namespace PII_Game_Of_Life
{
    /*
    Clase Board, conoce el ancho y el largo del tablero
    asi como su contenido.
    */
    public class Board
    {
        public int Height 
        { 
            get
            {
                return Content.GetLength(1);
            }
        }

        public int Width
        { 
            get
            {
                return Content.GetLength(0);
            }
        }

        public bool[,] Content { get; set; }

        // Constructor
        public Board(bool[,] content)
        {   
            this.Content = content; 
        }
    }
}
