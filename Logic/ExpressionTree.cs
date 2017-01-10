using System;

namespace Logic
{
    public class ExpressionTree : IExpressionTree
    {
        private Tree<string> _tree;

        public ExpressionTree(string nnfExp)
        {
            CreateExpressionTree(nnfExp);
        }

        private int CalcOperatorsCount(string nnfExp)
        {
            int count = 0;
            for (int i = 0; i < nnfExp.Length; i++)
            {
                if (nnfExp[i] == '&' || nnfExp[i] == '|' || nnfExp[i] == '>')
                {
                    count++;
                }
            }
            return count;
        }

        public void CreateExpressionTree(string nnfExp)
        {
            _tree = new Tree<string>();
            Tree<string>.Node root = BuildExpressionTree(nnfExp);
            _tree.Root = root;
        }

        private static Tree<string>.Node BuildExpressionTreeAux(string exp)
        {
            return BuildExpressionTreeAux(exp);
        }

        public static string RemoveOuterBrackets(string exp)
        {
            // remove '('
            if (exp[0] == '(')
            {
                exp = exp.Remove(0, 1);
            }
            // remove ')'
            if (exp[exp.Length - 1] == ')')
            {
                exp = exp.Remove(exp.Length - 1, 1);
            }
            return exp;
        }

        public static string RemoveRedundantBrackets(string exp)
        {
            while (FindMainOperator(exp) == exp.Length && !IsAtom(exp))
            {
                exp = RemoveOuterBrackets(exp);
            }
            return exp;
        }

        private static Tree<string>.Node BuildExpressionTree(string exp)
        {
            string exp2 = RemoveRedundantBrackets(exp);
            if (IsAtom(exp))
            {
                string exp3 = RemoveOuterBrackets(exp);
                return new Tree<string>.Node(exp3);
            }

            int mainOperatorIndex = FindMainOperator(exp2);

            char mainOp = exp2[mainOperatorIndex];

            string leftStr = exp2.Substring(0, mainOperatorIndex);
            string rightStr = exp2.Substring(mainOperatorIndex + 1, exp2.Length - mainOperatorIndex - 1);

            Tree<string>.Node left = BuildExpressionTree(leftStr);
            Tree<string>.Node right = BuildExpressionTree(rightStr);
            Tree<string>.Node root = new Tree<string>.Node(mainOp.ToString());
            root.Left = left;
            root.Right = right;
            return root;
        }

        private static bool IsAtom(string exp)
        {
            return !exp.Contains("&") && !exp.Contains("|") && !exp.Contains(">");
        }

        public static bool IsOperator(Tree<string>.Node node)
        {
            return node.Data.Equals("&") || node.Data.Equals("|") || node.Data.Equals(">");
        }

        public static bool IsOperator(char ch)
        {
            return ch == '&' || ch == '|' || ch == '>';
        }

        private static bool ContainsOneOperator(string exp)
        {
            int count = 0;
            for (int i = 0; i < exp.Length; i++)
            {
                if (IsOperator(exp[i]))
                {
                    count++;
                }
            }
            return count == 1;
        }

        public static int FindMainOperator(string exp)
        {
            // there is only one operator
            if (ContainsOneOperator(exp))
            {
                if (exp.Contains("&"))
                {
                    return exp.IndexOf('&');
                }
                if (exp.Contains("|"))
                {
                    return exp.IndexOf('|');
                }
                if (exp.Contains(">"))
                {
                    return exp.IndexOf('>');
                }
            }

            int balance = 0; // balance between '(' and ')'
            int i;
            for (i = 0; i < exp.Length; i++)
            {
                if (balance == 0 && IsOperator(exp[i]))
                {
                    break;
                }
                if (exp[i] == '(')
                {
                    balance++;
                }
                if (exp[i] == ')')
                {
                    balance--;
                }
            }
            return i;
        }

        public void DisplayTree()
        {
            _tree.InorderDisplay();
        }

        public void InorderTravel(Action<Tree<string>.Node> action)
        {
            _tree.InorderTravel(action);
        }

        public Tree<string>.Node Root
        {
            get
            {
                return _tree.Root;
            }
        }
    }
}
