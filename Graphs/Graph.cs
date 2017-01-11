using System;
using System.Collections.Generic;
using Utilities;

namespace Graphs
{
    public class Graph : IGraph
    {
        public List<Vertex> V;

        public Graph(int n, bool[] U_init)
        {
            V = new List<Vertex>();

            int[,] M = new int[n + 2, n + 2];
            for (int i = 0; i < n + 2; i++)
            {
                for (int j = 0; j < n + 2; j++)
                {
                    M[i, j] = 0;
                }
            }

            int k = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    M[i, j] = k;
                    k++;
                }
            }
            k = 1;
            V.Add(null);
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    int[] neighborsArray = CreateNeighbors(M, i, j);
                    Vertex vertex = new Vertex(k, U_init[i], neighborsArray);
                    k++;
                    V.Add(vertex);
                }
            }
        }

        int[] CreateNeighbors(int[,] M, int i, int j)
        {
            int[] neighborsArray = new int[Constants.MAX_NEIGHBORS];
            neighborsArray[0] = M[i - 1, j];
            neighborsArray[1] = M[i, j + 1];
            neighborsArray[2] = M[i + 1, j + 1];
            neighborsArray[3] = M[i + 1, j];
            neighborsArray[4] = M[i, j - 1];
            neighborsArray[5] = M[i - 1, j - 1];
            return neighborsArray;
        }

        public bool AreAlignedNeighbors(int i, int j, int k)
        {
            return V[i].NeighborType(j) == V[j].NeighborType(k) && V[i].NeighborType(j) != 0 && V[j].NeighborType(k) != 0;
        }

        public void Show()
        {
            foreach (var vertex in V)
            {
                Console.WriteLine(vertex);
            }
        }
    }
}
