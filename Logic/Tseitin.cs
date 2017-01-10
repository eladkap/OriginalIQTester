using System.Collections.Generic;

namespace Logic
{
    public class Tseitin
    {
        public List<string> cnfFormula;
        public List<string> cnfClauses;
        public List<string> tseitinClauses;
        public List<Variable> vars;
        public List<Tree<string>.Node> opNodes;
        public ExpressionTree expTree;
        public string key;
        private int _runId;

        public Tseitin(ExpressionTree expTree, string key)
        {
            this.key = key;
            this.expTree = expTree;
            cnfFormula = new List<string>();
            cnfClauses = new List<string>();
            tseitinClauses = new List<string>();
            vars = new List<Variable>();
            opNodes = new List<Tree<string>.Node>();
            _runId = 1;
        }

        /// <summary>
        /// Adds artificial variables acccording to Tsietin algorithm while scanning the node
        /// </summary>
        /// <param name="node">Tsietin tree node</param>
        private void DoAction(Tree<string>.Node node)
        {
            if (node == expTree.Root)
            {
                vars.Add(new Variable(0, key));
                opNodes.Add(node);
                return;
            }
            // node has binary operator
            if (node.HasTwoChildren())
            {
                vars.Add(new Variable(_runId, key));
                opNodes.Add(node);
                _runId++;
            }
        }

        public void TseitingConvert()
        {
            expTree.InorderTravel(DoAction);

            // add the root var "a0"
            tseitinClauses.Add($"{key}0");
            for (int i = 0; i < vars.Count; i++)
            {
                string leftOperand;
                string rightOperand;

                // left operand
                Tree<string>.Node leftNode = opNodes[i].Left;
                if (!ExpressionTree.IsOperator(leftNode))
                {
                    leftOperand = leftNode.Data;
                }
                else
                {
                    int index = opNodes.IndexOf(leftNode);
                    leftOperand = vars[index].ToString();
                }

                // right operand
                Tree<string>.Node rightNode = opNodes[i].Right;
                if (!ExpressionTree.IsOperator(rightNode))
                {
                    rightOperand = rightNode.Data;
                }
                else
                {
                    int index = opNodes.IndexOf(rightNode);
                    rightOperand = vars[index].ToString();
                }

                string op = opNodes[i].Data;
                string tseitinClause = $"{vars[i]}={leftOperand}{op}{rightOperand}";
                tseitinClauses.Add(tseitinClause);
            }
        }

        private static string Not(string literal)
        {
            return "~" + literal;
        }

        /// <summary>
        /// Removes redundant "nots" (~) in the literal
        /// </summary>
        /// <param name="literal">Literal</param>
        /// <returns>Simplified literal</returns>
        public static string Simplify(string literal)
        {
            string simplifiedLiteral = "";
            string variable = literal.Substring(literal.LastIndexOf('~') + 1);
            int i = 0;
            int notCount = 0;
            while (i < literal.Length)
            {
                notCount = 0;
                while (literal[i] == '~' && i < literal.Length)
                {
                    notCount++;
                    i++;
                }
                if (notCount % 2 == 1)
                {
                    simplifiedLiteral += '~';
                }
                i++;
            }
            simplifiedLiteral += variable;
            return simplifiedLiteral;
        }

        private static string ConvertDisjunction(string clause)
        {
            string cnfClause;
            string[] vars = clause.Split(new char[] { '=', '&', '|', '>' });
            string x = vars[0];
            string y = vars[1];
            string z = vars[2];
            string notX = Simplify(Not(x));
            string notY = Simplify(Not(y));
            string notZ = Simplify(Not(z));
            cnfClause = $"({notY}|{x})&({notZ}|{x})&({notX}|{y}|{z})";
            return cnfClause;
        }

        private static string ConvertConjunction(string clause)
        {
            string cnfClause = "";
            string[] vars = clause.Split(new char[] { '=', '&', '|', '>' });
            string x = vars[0];
            string y = vars[1];
            string z = vars[2];
            string notX = Simplify(Not(x));
            string notY = Simplify(Not(y));
            string notZ = Simplify(Not(z));
            cnfClause = $"({notX}|{y})&({notX}|{z})&({notY}|{notZ}|{x})";
            return cnfClause;
        }

        private static string ConvertImplication(string clause)
        {
            string cnfClause = "";
            string[] vars = clause.Split(new char[] { '=', '&', '|', '>' });
            string x = vars[0];
            string y = vars[1];
            string z = vars[2];
            string notX = Simplify(Not(x));
            string notY = Simplify(Not(y));
            string notZ = Simplify(Not(z));
            cnfClause = $"({x}|{y})&({x}|{notZ})&({notX}|{notY}|{z})";
            return cnfClause;
        }

        public void CnfConvert()
        {
            cnfClauses.Add($"({key}0)");
            foreach (var tseitinClause in tseitinClauses)
            {
                if (IsDisjunction(tseitinClause))
                {
                    string cnfCluase = ConvertDisjunction(tseitinClause);
                    cnfClauses.Add(cnfCluase);
                }
                else if (IsConjunction(tseitinClause))
                {
                    string cnfCluase = ConvertConjunction(tseitinClause);
                    cnfClauses.Add(cnfCluase);
                }
                else if (IsImplication(tseitinClause))
                {
                    string cnfClause = ConvertImplication(tseitinClause);
                    cnfClauses.Add(cnfClause);
                }
            }
        }

        private bool IsDisjunction(string tseitinClause)
        {
            for (int i = 0; i < tseitinClause.Length; i++)
            {
                if (tseitinClause[i] == '|')
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsConjunction(string tseitinClause)
        {
            for (int i = 0; i < tseitinClause.Length; i++)
            {
                if (tseitinClause[i] == '&')
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsImplication(string tseitinClause)
        {
            for (int i = 0; i < tseitinClause.Length; i++)
            {
                if (tseitinClause[i] == '>')
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Splits CNF clauses seperated with AND operators
        /// </summary>
        public void SplitCnfClauses()
        {
            foreach (var clause in cnfClauses)
            {
                string[] innerClauses = clause.Split(new char[] { '&' });
                foreach (var c in innerClauses)
                {
                    cnfFormula.Add(c);
                }
            }
        }
    }
}
