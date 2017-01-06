using System;
using System.Collections.Generic;
using Utilities;

namespace Logic
{
    public class FormulaGenerator
    {
        //-------------------------(formula 1) init ----------------------------//

        // q - the empty vertex
        public static string GenerateInitialFormula(int q)
        {
            string formula = $"~Y{q},1&";
            string clause = "";
            for (int i = 1; i <= Constants.VERTICES; i++)
            {
                if (i != q)
                {
                    clause += $"Y{i},1&";
                }
            }
            clause = clause.Remove(clause.Length - 1, 1);
            formula += clause;
            return formula;
        }

        //-------------------------(formula 2) one_step ----------------------------//

        public static string GenerateOneStepFormula(List<Tuple<int, int, int>> A)
        {
            string formula = "";
            for (int p = 1; p <= Constants.MAX_STEPS; p++)
            {
                formula += $"({GenerateOneStep2(p, A)})&";
            }
            formula = formula.Remove(formula.Length - 1, 1);
            return formula;
        }

        public static string GenerateOneStep1(int i, int j, int k, int p, List<Tuple<int, int, int>> A)
        {
            string clause = "";
            foreach (var tuple in A)
            {
                int r = tuple.Item1;
                int s = tuple.Item2;
                int t = tuple.Item3;
                if (r != i || s != j || t != k)
                {
                    clause += $"~X{r},{s},{t},{p}&";
                }
            }
            clause = clause.Remove(clause.Length - 1, 1);
            return clause;
        }

        public static string GenerateOneStep2(int p, List<Tuple<int, int, int>> A)
        {
            string clause = "";
            foreach (var tuple in A)
            {
                int i = tuple.Item1;
                int j = tuple.Item2;
                int k = tuple.Item3;
                clause += $"(X{i},{j},{k},{p}&{GenerateOneStep1(i, j, k, p, A)})|";
            }
            clause = clause.Remove(clause.Length - 1, 1);
            return clause;
        }

        //-------------------------(formula 3) legal ----------------------------//

        public static string GenerateLegalFormula(List<Tuple<int, int, int>> A)
        {
            string formula = "";
            for (int p = 1; p <= Constants.MAX_STEPS; p++)
            {
                formula += $"({GenerateLegal1(p, A)})&";
            }
            formula = formula.Remove(formula.Length - 1, 1);
            return formula;
        }

        public static string GenerateLegal1(int p, List<Tuple<int, int, int>> A)
        {
            string clause = "";
            foreach (var tuple in A)
            {
                int i = tuple.Item1;
                int j = tuple.Item2;
                int k = tuple.Item3;
                clause += $"(Y{i},{p}&Y{j},{p}&~Y{k},{p}&X{i},{j},{k},{p})|";
            }
            clause = clause.Remove(clause.Length - 1, 1);
            return clause;
        }

        //-------------------------(formula 4) steps ----------------------------//

        public static string GenerateStepsFormula(List<Tuple<int, int, int>> A)
        {
            string formula = "";
            for (int p = 1; p <= Constants.MAX_STEPS; p++)
            {
                formula += $"({GenerateSteps12(p, A)})&";
            }
            formula = formula.Remove(formula.Length - 1, 1);
            return formula;
        }

        public static string GenerateSteps12(int p, List<Tuple<int, int, int>> A)
        {
            string clause = "";
            foreach (var tuple in A)
            {
                int i = tuple.Item1;
                int j = tuple.Item2;
                int k = tuple.Item3;
                clause += $"({GenerateSteps2(p, i, j, k)}&{GenerateSteps1(p, i, j, k)})|";
            }
            clause = clause.Remove(clause.Length - 1, 1);
            return clause;
        }

        public static string GenerateSteps2(int p, int i, int j, int k)
        {
            return $"X{i},{j},{k},{p}&~Y{i},{p + 1}&~Y{j},{p + 1}&Y{k},{p + 1}";
        }

        public static string GenerateSteps1(int p, int i, int j, int k)
        {
            string clause = "";
            for (int a = 1; a <= Constants.VERTICES; a++)
            {
                if (a != i && a != j && a != k)
                {
                    clause += $"(Y{a},{p}>Y{a},{p + 1})&(Y{a},{p + 1}>Y{a},{p})&";
                }
            }
            clause = clause.Remove(clause.Length - 1, 1);
            return clause;
        }

        //-------------------------(formula 5) final ----------------------------//

        public static string GenerateFinalFormula()
        {
            string formula = "";
            for (int i = 1; i <= Constants.VERTICES; i++)
            {
                string clause = $"(Y{i},{Constants.MAX_STEPS + 1}&";
                for (int j = 1; j <= Constants.VERTICES; j++)
                {
                    if (j != i)
                    {
                        clause += $"~Y{j},{Constants.MAX_STEPS + 1}&";
                    }
                }
                clause = clause.Remove(clause.Length - 1, 1);
                formula += clause + ")|";
            }
            formula = formula.Remove(formula.Length - 1, 1);
            return formula;
        }
    }
}
