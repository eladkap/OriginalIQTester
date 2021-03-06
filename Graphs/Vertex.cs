﻿using Utilities;

namespace Graphs
{
    public class Vertex : IVertex
    {
        public int[] Neighbors { get; set; }

        public int Index { get; set; }

        public bool HasChecker { get; set; }

        public Vertex()
        {

        }

        public Vertex(int index, bool hasChecker, int[] neighborsArray)
        {
            Index = index;
            HasChecker = hasChecker;
            Neighbors = new int[Constants.MAX_NEIGHBORS];
            for (int i = 0; i < Constants.MAX_NEIGHBORS; i++)
            {
                Neighbors[i] = neighborsArray[i];
            }
        }

        public Vertex CopyVertex()
        {
            Vertex newVertex = new Vertex();
            newVertex.HasChecker = HasChecker;
            newVertex.Index = Index;
            newVertex.Neighbors = new int[Neighbors.Length];
            for (int i = 0; i < Neighbors.Length; i++)
            {
                newVertex.Neighbors[i] = Neighbors[i];
            }

            return newVertex;
        }

        public int NeighborType(int vertexIndex)
        {
            for (int i = 0; i < Constants.MAX_NEIGHBORS; i++)
            {
                if (Neighbors[i] == vertexIndex)
                {
                    return i + 1;
                }
            }
            return 0;
        }

        public bool IsNeighbor(int vertexIndex)
        {
            for (int i = 0; i < Constants.MAX_NEIGHBORS; i++)
            {
                if (Neighbors[i] == vertexIndex)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            string s = $"{Index}: ";
            foreach (var neig in Neighbors)
            {
                if (true)
                {
                    s += neig + " ";
                }
            }
            return s;
        }
    }
}
