using System;
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

            // Input empty vertex index
            int emptyVertexIndex = 0;
            emptyVertexIndex = InputEmptyVertex();
            if (emptyVertexIndex < 0)
            {
                Console.WriteLine("Bad argument.");
                return;
            }
            if (!IsLegalVertexIndex(emptyVertexIndex, boardsLinesNumber))
            {
                Console.WriteLine("Illegal vertex index.");
                return;
            }

            gameLogic = new GameLogic(boardsLinesNumber, emptyVertexIndex);

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
    }
}
