﻿using System;
using Logic;
using System.Collections.Generic;
using Sat;
using OriginalIQTesterLogic;

namespace OriginalIQTester
{
    class Program
    {
        private static int InputLinesNum()
        {
            string linesNumStr = Console.ReadLine();
            int linesNum = 0;
            bool result = int.TryParse(linesNumStr, out linesNum);
            if (!result)
            {
                return -1;
            }
            else
            {
                return linesNum;
            }
        }

        private static int InputEmptyVertex()
        {
            string emptyVertexIndex = Console.ReadLine();
            int index = 0;
            bool result = int.TryParse(emptyVertexIndex, out index);
            if (!result)
            {
                return -1;
            }
            else
            {
                return index;
            }
        }

        private static int CalculateVerticesNumber(int boardsLinesNumber)
        {
            int verticesNum = 0;
            for (int i = 1; i <= boardsLinesNumber; i++)
            {
                verticesNum += i;
            }
            return verticesNum;
        }

        private static bool IsLegalVertexIndex(int vertexIndex, int boardsLinesNumber)
        {
            return vertexIndex >= 1 && vertexIndex <= CalculateVerticesNumber(boardsLinesNumber);
        }

        static void Main(string[] args)
        {
            GameLogic gameLogic;

            // Input board lines number in board
            int boardsLinesNumber = 0;
            boardsLinesNumber = InputLinesNum();
            if (boardsLinesNumber < 0)
            {
                Console.WriteLine("Bad argument.");
                return;
            }


            bool[] U_final = new bool[15 + 1];
            bool[] U_init = new bool[15 + 1]; // change the '15' with variable in the app
            CreateUInit(U_init);
            CreateUFinal(U_final);

            int mode = 1;// classic
           

            gameLogic = new GameLogic(boardsLinesNumber, U_init, U_final, mode);

            Console.WriteLine("Solving...");
            List<Variable> path = gameLogic.SolveGame();

            if (path == null)
            {
                Console.WriteLine("No solution.");
            }
            else
            {
                SolutionBuilder.ShowSolution(path);
            }

            Console.WriteLine("End.");
        }

        private static void CreateUInit(bool[] u_init)
        {
            for (int i = 1; i < u_init.Length; i++)
            {
                u_init[i] = true;
            }
            u_init[11] = false;
            u_init[15] = false;
        }

        private static void CreateUFinal(bool[] u_final)
        {
            for (int i = 1; i < u_final.Length; i++)
            {
                u_final[i] = false;
            }
            u_final[15] = true;
            u_final[11] = true;
        }
    }
}
