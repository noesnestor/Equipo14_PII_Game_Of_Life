using System;

namespace PII_Game_Of_Life
{
    /*
    Clase que se encarga de la logica del juego.
    Esta bien tener un lugar con distintas logicas, de facil acceso
    y cambio.
    */
    public class GameLogic
    {
        // Método para calcular siguiente generación:
        public static Board CalculateNextGeneration(Board board)
        {
            int boardWidth = board.Width;
            int boardHeight = board.Height;

            Board cloneBoard = new Board(new bool[boardWidth, boardHeight]);

            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x-1; i <= x+1; i++)
                    {
                        for (int j = y-1;j <= y+1; j++)
                        {
                            if(i >=0 && i < boardWidth && j >= 0 && j < boardHeight && board.Content[i,j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    if(board.Content[x,y])
                    {
                        aliveNeighbors--;
                    }
                    if (board.Content[x,y] && aliveNeighbors < 2)
                    {
                        //Celula muere por baja población
                        cloneBoard.Content[x,y] = false;
                    }
                    else if (board.Content[x,y] && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                        cloneBoard.Content[x,y] = false;
                    }
                    else if (!board.Content[x,y] && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        cloneBoard.Content[x,y] = true;
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        cloneBoard.Content[x,y] = board.Content[x,y];
                    }
                }
            }
            return new Board(cloneBoard.Content);
        }
    }
}
