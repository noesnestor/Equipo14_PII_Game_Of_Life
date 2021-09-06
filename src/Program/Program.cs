﻿using System;
using System.IO;
using System.Text;
using System.Threading;

namespace PII_Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "C:\\Users\\rodri\\Desktop\\Prog II\\Equipo14_PII_Game_Of_Life\\assets\\board.txt";
            string content = File.ReadAllText(url);
            string[] contentLines = content.Split('\n');
            bool[,] gameBoard = new bool[contentLines.Length, contentLines[0].Length];

            for (int  y=0; y<contentLines.Length;y++)
            {
                for (int x=0; x<contentLines[y].Length; x++)
                {
                    if(contentLines[y][x]=='1')
                    {
                        gameBoard[x,y]=true;
                    }
                }
            }


            //////////////////////

            //bool[,] gameBoard = new bool[contentLines.Length, contentLines[0].Length];//variable que representa el tablero
            int boardWidth = gameBoard.GetLength(0);
            int boardHeight = gameBoard.GetLength(1);
            while (true)
            {
                Console.Clear();
                StringBuilder s = new StringBuilder();
                for (int y = 0; y<boardHeight;y++)
                {
                    for (int x = 0; x<boardWidth; x++)
                    {
                        if(gameBoard[x,y])
                        {
                            s.Append("|X|");
                        }
                        else
                        {
                            s.Append("___");
                        }
                    }
                    s.Append("\n");
                }
                Console.WriteLine(s.ToString());
                //=================================================

                bool[,] cloneboard = new bool[boardWidth, boardHeight];
                for (int x = 0; x < boardWidth; x++)
                {
                    for (int y = 0; y < boardHeight; y++)
                    {
                        int aliveNeighbors = 0;
                        for (int i = x-1; i<=x+1;i++)
                        {
                            for (int j = y-1;j<=y+1;j++)
                            {
                                if(i>=0 && i<boardWidth && j>=0 && j < boardHeight && gameBoard[i,j])
                                {
                                    aliveNeighbors++;
                                }
                            }
                        }
                        if(gameBoard[x,y])
                        {
                            aliveNeighbors--;
                        }
                        if (gameBoard[x,y] && aliveNeighbors < 2)
                        {
                            //Celula muere por baja población
                            cloneboard[x,y] = false;
                        }
                        else if (gameBoard[x,y] && aliveNeighbors > 3)
                        {
                            //Celula muere por sobrepoblación
                            cloneboard[x,y] = false;
                        }
                        else if (!gameBoard[x,y] && aliveNeighbors == 3)
                        {
                            //Celula nace por reproducción
                            cloneboard[x,y] = true;
                        }
                        else
                        {
                            //Celula mantiene el estado que tenía
                            cloneboard[x,y] = gameBoard[x,y];
                        }
                    }
                }
                gameBoard = cloneboard;
                cloneboard = new bool[boardWidth, boardHeight];
            //=================================================
            Thread.Sleep(300);
            }
        }
    }
}
