﻿using System;
using System.Collections.Generic;
using Utilities;

namespace Graphs
{
    public class Graph : IGraph
    {
        public List<Vertex> V;

        public Graph()
        {

        }

        public Graph(int boardLines, bool[] vector)
        {
            V = new List<Vertex>();

            int[,] M = new int[boardLines + 2, boardLines + 2];
            for (int i = 0; i < boardLines + 2; i++)
            {
                for (int j = 0; j < boardLines + 2; j++)
                {
                    M[i, j] = 0;
                }
            }

            int k = 1;
            for (int i = 1; i <= boardLines; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    M[i, j] = k;
                    k++;
                }
            }
            k = 1;
            V.Add(null);
            for (int i = 1; i <= boardLines; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    int[] neighborsArray = CreateNeighbors(M, i, j);
                    Vertex vertex = new Vertex(k, vector[k], neighborsArray);
                    k++;
                    V.Add(vertex);
                }
            }
        }

        // Graph g=graph.CopyGraph()
        public Graph CopyGraph()
        {
            Graph graph = new Graph();
            graph.V = new List<Vertex>();
            graph.V.Add(null);
            for (int i = 1; i < V.Count; i++)
            {
                Vertex v = V[i].CopyVertex();
                graph.V.Add(v);
            }
            return graph;
        }

        private int[] CreateNeighbors(int[,] M, int i, int j)
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

        public bool IsLegalMove(int i, int j, int k)
        {
            return AreAlignedNeighbors(i, j, k) && V[i].HasChecker && V[j].HasChecker && !V[k].HasChecker;
        }

        public void PerformStep(Step step)
        {
            V[step.From].HasChecker = false;
            V[step.Via].HasChecker = false;
            V[step.To].HasChecker = true;
        }

        public List<bool> GetVerticesState()
        {
            List<bool> verticesStateList = new List<bool>();
            foreach (var vertex in V)
            {
                verticesStateList.Add(vertex.HasChecker);
            }
            return verticesStateList;
        }

        public void SetChecker(int index)
        {
            V[index].HasChecker = true;
        }

        public void UnsetChecker(int index)
        {
            V[index].HasChecker = false;
        }

        public void Show()
        {
            foreach (var vertex in V)
            {
                Console.WriteLine(vertex);
            }
        }

        public static int CalculateVertices(int boardLines)
        {
            int sum = 0;
            for (int i = 1; i <= boardLines; i++)
            {
                sum += i;
            }
            return sum;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 1; i < V.Count; i++)
            {
                if (V[i].HasChecker)
                {
                    str += $"({i},T) ";
                }
                else
                {
                    str += $"({i},F) ";
                }
            }
            return str;
        }
    }
}
