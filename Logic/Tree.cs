using System;
using System.Collections.Generic;

namespace Logic
{
    public class Tree<T> where T : IComparable
    {
        public class Node
        {
            public Node Left;
            public Node Right;
            public string Data;

            public Node(string data)
            {
                Left = null;
                Right = null;
                Data = data;
            }

            public Node(Node node)
            {
                Left = node.Left;
                Right = node.Right;
                Data = node.Data;
            }

            public bool IsLeaf()
            {
                return Left == null && Right == null;
            }

            public bool HasTwoChildren()
            {
                return Left != null && Right != null;
            }

            public void Display()
            {
                Console.Write($"[{Data},");
                if (Left != null)
                {
                    Console.Write($"l={Left.Data},");
                }
                else
                {
                    Console.Write($"l=None,");
                }
                if (Right != null)
                {
                    Console.Write($"r={Right.Data}]");
                }
                else
                {
                    Console.Write($"r=None]");
                }
                Console.WriteLine();
            }
        }

        List<Node> nodesList;

        public Tree()
        {
            Root = null;
            Count = 0;
            nodesList = new List<Node>();
        }

        public Node Root { get; set; }

        public int Count { get; private set; }

        public bool IsEmpty()
        {
            return Root == null;
        }

        public void InorderDisplay()
        {
            Node node = Root;
            InorderDisplayAux(node);
            Console.WriteLine();
        }

        private void InorderDisplayAux(Node node)
        {
            if (node == null)
            {
                return;
            }
            InorderDisplayAux(node.Left);
            node.Display();
            InorderDisplayAux(node.Right);
        }

        public void InorderTravel(Action<Node> action)
        {
            Node node = Root;
            InorderTravelAux(node, action);
        }

        private void InorderTravelAux(Node node, Action<Node> action)
        {
            if (node == null)
            {
                return;
            }
            InorderTravelAux(node.Left, action);
            action(node);
            InorderTravelAux(node.Right, action);
        }
    }
}
