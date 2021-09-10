using System;
using System.Threading;

namespace PII_Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            // Carga y crea el tablero.
            Board gameBoard = FileLoader.LoadBoardFromLocalDir("E:\\GitHub\\Equipo14_PII_Game_Of_Life\\assets\\board.txt");

            // Game Loop.
            while (true)
            {   
                ConsolePrinter.PrintBoard(gameBoard, "|X|", "___");         // Imprime el tablero.
                gameBoard = GameLogic.CalculateNextGeneration(gameBoard);   // Calcula la siguiente generacion y reemplaza la variable.
                Thread.Sleep(300);
            }
        }
    }
}
