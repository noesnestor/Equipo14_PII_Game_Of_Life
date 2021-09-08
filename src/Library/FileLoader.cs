using System;
using System.IO;

namespace PII_Game_Of_Life
{
    /*
    Esta clase es la experta en cargar archivos.
    Tener esto separado del resto nos facilita al momento de 
    agregar distintas formas de carga de archivos.
    */
    public class FileLoader
    {
        // Metodo para cargar un tablero desde una direccion local.
        public static Board LoadBoardFromLocalDir(string url)
        {
            string content = File.ReadAllText(url);
            string[] contentLines = content.Split('\n');
            bool[,] gameBoard = new bool[contentLines.Length, contentLines[0].Length];

            for (int  y = 0; y < contentLines.Length; y++)
            {
                for (int x = 0; x < contentLines[y].Length; x++)
                {
                    if(contentLines[y][x] == '1')
                    {
                        gameBoard[x,y] = true;
                    }
                }
            }
            
            return  new Board(gameBoard);
        }
    }
}
