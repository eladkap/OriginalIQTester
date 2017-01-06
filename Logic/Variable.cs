using System;

namespace Logic
{
    public class Variable : IComparable
    {
        public Variable(int vertex, int phase, int id)
        {
            Id = id;
            Vertex = vertex;
            Phase = phase;
            Prefix = "Y";
        }

        public Variable(int from, int via, int to, int phase, int id)
        {
            Id = id;
            From = from;
            Via = via;
            To = to;
            Phase = phase;
            Prefix = "X";
        }

        public Variable(int index, string prefix)
        {
            Index = index;
            Prefix = prefix;
        }

        public Variable(string str)
        {
            Prefix = str[0] + "";
            string[] s = str.Split(new char[] { ',' });
            if (s.Length == 2) // Y variable
            {
                Vertex = int.Parse(s[0].Remove(0, 1));
                Phase = int.Parse(s[1]);
            }
            else if (s.Length == 4) // X variable
            {
                From = int.Parse(s[0].Remove(0, 1));
                Via = int.Parse(s[1]);
                To = int.Parse(s[2]);
                Phase = int.Parse(s[3]);
            }
        }

        // for CNF file
        public int Id { get; set; }

        // for ai variables
        public int Index { get; set; }

        public string Prefix { get; set; }

        // for Y variables
        public int Vertex { get; set; }

        // for Y variables
        public int Phase { get; set; }

        // for X variables - i
        public int From { get; set; }

        // for X variables - j
        public int Via { get; set; }

        // for X variables - k
        public int To { get; set; }

        public override string ToString()
        {
            if (Prefix.Equals("Y"))
            {
                return "Y" + Vertex + "," + Phase;
            }
            else if (Prefix.Equals("X"))
            {
                return "X" + From + "," + Via + "," + To + "," + Phase;
            }
            else
            {
                return Prefix + Index;
            }
        }

        public int CompareTo(object obj)
        {
            Variable varObj = (Variable)obj;
            if (Phase == varObj.Phase)
            {
                return Vertex - varObj.Vertex;
            }
            return Phase - varObj.Phase;
        }
    }
}
