using System;
using Logic;
using System.Collections.Generic;
using Sat;
using OriginalIQTesterLogic;
using Graphs;

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

        private static void CreateUInit(bool[] u_init)
        {
            for (int i = 1; i < u_init.Length; i++)
            {
                u_init[i] = true;
            }
            u_init[1] = false;
            u_init[5] = false;
            u_init[10] = false;
        }

        private static void CreateUFinal(bool[] u_final)
        {
            for (int i = 1; i < u_final.Length; i++)
            {
                u_final[i] = false;
            }
            u_final[4] = true;
            u_final[13] = true;
            u_final[15] = true;
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

            int mode = 1; // classic
            mode = 2; // advanced

            gameLogic = new GameLogic(boardsLinesNumber, U_init, U_final, mode);

            Console.WriteLine("Solving...");
            List<Step> stepsList = gameLogic.SolveGame();

            if (stepsList == null)
            {
                Console.WriteLine("No solution.");
            }
            else
            {
                SolutionBuilder.ShowSolution(stepsList);
            }

            Console.WriteLine("End.");
        }
    }
}
