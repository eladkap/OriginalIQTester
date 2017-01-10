using System;
using System.Collections.Generic;
using Utilities;

namespace Logic
{
    public class FormulaGenerator
    {
        /// <summary>
        /// Generates formula 1 (init)
        /// </summary>
        /// <param name="emptyVertexIndex">Empty vertex index</param>
        /// <returns>Formula 1</returns>
        public static string GenerateInitialFormula(int emptyVertexIndex, int vertices)
        {
            string formula = $"~Y{emptyVertexIndex},1&";
            string clause = "";
            for (int i = 1; i <= vertices; i++)
            {
                if (i != emptyVertexIndex)
                {
                    clause += $"Y{i},1&";
                }
            }
            clause = clause.Remove(clause.Length - 1, 1);
            formula += clause;
            return formula;
        }

        //-------------------------(formula 2) one_step ----------------------------//
        /// <summary>
        /// Generates formula 2 (one_step)
        /// </summary>
        /// <param name="A">All valid triplets of neighbor vertices</param>
        /// <returns>Formula 2</returns>
        public static string GenerateOneStepFormula(List<Tuple<int, int, int>> A, int maxSteps)
        {
            string formula = "";
            for (int p = 1; p <= maxSteps; p++)
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

        /// <summary>
        /// Generates formula 3 (legal)
        /// </summary>
        /// <param name="A">All valid triplets of neighbor vertices</param>
        /// <returns>Formula 3</returns>
        public static string GenerateLegalFormula(List<Tuple<int, int, int>> A, int maxSteps)
        {
            string formula = "";
            for (int p = 1; p <= maxSteps; p++)
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
        /// <summary>
        /// Generates formula 4 (steps)
        /// </summary>
        /// <param name="A">All valid triplets of neighbor vertices</param>
        /// <returns>Formula 4</returns>
        public static string GenerateStepsFormula(List<Tuple<int, int, int>> A, int vertices, int maxSteps)
        {
            string formula = "";
            for (int p = 1; p <= maxSteps; p++)
            {
                formula += $"({GenerateSteps12(p, A, vertices)})&";
            }
            formula = formula.Remove(formula.Length - 1, 1);
            return formula;
        }

        public static string GenerateSteps12(int p, List<Tuple<int, int, int>> A, int vertices)
        {
            string clause = "";
            foreach (var tuple in A)
            {
                int i = tuple.Item1;
                int j = tuple.Item2;
                int k = tuple.Item3;
                clause += $"({GenerateSteps2(p, i, j, k)}&{GenerateSteps1(p, i, j, k, vertices)})|";
            }
            clause = clause.Remove(clause.Length - 1, 1);
            return clause;
        }

        public static string GenerateSteps2(int p, int i, int j, int k)
        {
            return $"X{i},{j},{k},{p}&~Y{i},{p + 1}&~Y{j},{p + 1}&Y{k},{p + 1}";
        }

        public static string GenerateSteps1(int p, int i, int j, int k, int vertices)
        {
            string clause = "";
            for (int a = 1; a <= vertices; a++)
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
        /// <summary>
        /// Generates formula 5 (final)
        /// </summary>
        /// <returns>Formula 5</returns>
        public static string GenerateFinalFormula(int vertices, int maxSteps)
        {
            string formula = "";
            for (int i = 1; i <= vertices; i++)
            {
                string clause = $"(Y{i},{maxSteps + 1}&";
                for (int j = 1; j <= vertices; j++)
                {
                    if (j != i)
                    {
                        clause += $"~Y{j},{maxSteps + 1}&";
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
