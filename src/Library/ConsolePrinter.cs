using System;
using System.Text;

namespace PII_Game_Of_Life
{
    /*
    Clase encargada de imprimir.
    De ser necesario se podrian agregar distintas formas 
    de impresion.
    */
    public class ConsolePrinter
    {
        // Metodo para imprimir un tablero
        public static void PrintBoard(Board board, string trues, string falses)
        {
            int width = board.Width;
            int height = board.Height;

            Console.Clear();
            // Imprimir tablero
            StringBuilder s = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if(board.Content[x,y])
                    {
                        s.Append(trues);
                    }
                    else
                    {
                        s.Append(falses);
                    }
                }
                s.Append("\n");
            }
            Console.WriteLine(s.ToString());
        }
    }
}
