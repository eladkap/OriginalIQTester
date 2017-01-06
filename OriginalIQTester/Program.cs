using System;
using Logic;
using System.Collections.Generic;
using Sat;
using Graphs;
using Utilities;
using Resources;

namespace OriginalIQTester
{
    class Program
    {
        static string input = "";
        static string cnfInput = "cnfInput.txt";
        static int _id = 1;
        static Dictionary<string, int> variableToIdDict = new Dictionary<string, int>();
        static Dictionary<int, string> idToVariableDict = new Dictionary<int, string>();

        // belongs to main
        private static Graph BuildGraph(int lines, int emptyVertexIndex)
        {
            return new Graph(Constants.LINES, emptyVertexIndex);
        }

        // belongs to main
        static List<Tuple<int, int, int>> BuildGroupA(Graph G, int vertices)
        {
            List<Tuple<int, int, int>> A = new List<Tuple<int, int, int>>();
            for (int i = 1; i <= vertices; i++)
            {
                for (int j = 1; j <= vertices; j++)
                {
                    for (int k = 1; k <= vertices; k++)
                    {
                        if (G.AreAlignedNeighbors(i, j, k))
                        {
                            Tuple<int, int, int> T = new Tuple<int, int, int>(i, j, k);
                            A.Add(T);
                        }
                    }
                }
            }
            return A;
        }

        // belongs to main
        static void BuildXVariables(List<Variable> X, Graph G, int vertices)
        {
            for (int p = 1; p <= Constants.MAX_STEPS; p++)
            {
                for (int i = 1; i <= vertices; i++)
                {
                    for (int j = 1; j <= vertices; j++)
                    {
                        for (int k = 1; k <= vertices; k++)
                        {
                            if (G.AreAlignedNeighbors(i, j, k))
                            {
                                Variable var = new Variable(i, j, k, p, _id);
                                variableToIdDict.Add(var.ToString(), _id);
                                idToVariableDict.Add(_id, var.ToString());
                                _id++;
                                X.Add(var);
                            }
                        }
                    }
                }
            }
        }

        // belongs to main
        static void BuildYVariables(List<Variable> Y, int vertices, int phases)
        {
            for (int v = 1; v <= vertices; v++)
            {
                for (int p = 1; p <= phases + 1; p++)
                {
                    Variable var = new Variable(v, p, _id);
                    variableToIdDict.Add(var.ToString(), _id);
                    idToVariableDict.Add(_id, var.ToString());
                    _id++;
                    Y.Add(var);
                }
            }
        }

        // belongs to main 
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

        // belongs to main
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

        // belongs to converter
        static List<string> ConvertToCnfFormat(List<string> cnfFormula)
        {
            List<string> cnfFormat = new List<string>();
            foreach (var cnfClause in cnfFormula)
            {
                string cnfFormatClause = ConvertToCnfClauseFormat(cnfClause);
                cnfFormat.Add(cnfFormatClause);
            }
            return cnfFormat;
        }

        // belongs to converter
        private static string ConvertToCnfClauseFormat(string cnfClause)
        {
            string cnfFormatClause = "";
            string[] literals = cnfClause.Split(new char[] { '(', ')', '|' });

            foreach (var literal in literals)
            {
                if (literal.Length == 0)
                {
                    continue;
                }
                string varName = literal.Substring(literal.LastIndexOf('~') + 1);
                int id = variableToIdDict[varName];
                if (literal[0] == '~')
                {
                    cnfFormatClause += $"-{id} ";
                }
                else
                {
                    cnfFormatClause += $"{id} ";
                }
            }
            return cnfFormatClause;
        }

        // belongs to converter
        // we use "key" to distingush between different Tseitin artificial variables "ai"
        private static List<string> ConvertNnfToCnf(string formula, string key)
        {
            ExpressionTree expTree = new ExpressionTree(formula);

            // Convert NNF to Tseitin formula
            Tseitin tseiting = new Tseitin(expTree, key);

            tseiting.TseitingConvert();

            // Convert Tseitin to CNF formula
            tseiting.CnfConvert();

            // Generate natural id for each variable - to CNF format

            foreach (var var in tseiting.vars)
            {
                var.Id = _id;
                if (!variableToIdDict.ContainsKey(var.ToString()))
                {
                    variableToIdDict.Add(var.ToString(), _id);
                    idToVariableDict.Add(_id, var.ToString());
                }
                _id++;
            }

            tseiting.SplitCnfClauses();

            // Convert CNF formula to CNF format for SAT solver

            List<string> cnfClauses = ConvertToCnfFormat(tseiting.cnfFormula);

            return cnfClauses;
        }

        // belongs to converter
        private static List<string> ConvertFormulaToCnfFormat(string formula, string key)
        {
            if (formula.Equals(""))
            {
                return new List<string>();
            }
            List<string> cnfClauses = ConvertNnfToCnf(formula, key);
            return cnfClauses;
        }

        static void Main(string[] args)
        {
            // Input lines number in board
            int linesNum = 0;
            linesNum = InputLinesNum();
            if (linesNum < 0)
            {
                Console.WriteLine("Bad argument.");
                return;
            }
            Constants.LINES = linesNum;
            int count = 0;
            for (int i = 1; i <= linesNum; i++)
            {
                count += i;
            }
            Constants.VERTICES = count;
            Constants.MAX_STEPS = Constants.VERTICES - 2;

            // Input empty vertex index
            int emptyVertexIndex = 0;
            emptyVertexIndex = InputEmptyVertex();
            if (emptyVertexIndex < 0)
            {
                Console.WriteLine("Bad argument.");
                return;
            }

            // Build vertices graph
            Graph G = BuildGraph(Constants.LINES, emptyVertexIndex);
            Console.WriteLine("Build vertices graph.");


            // Create group A - valid triplets of neighbor vertices
            List<Tuple<int, int, int>> A = BuildGroupA(G, Constants.VERTICES);
            Console.WriteLine("Create group A.");

            foreach (var triplet in A)
            {
                Console.WriteLine($"{triplet.Item1},{triplet.Item2},{triplet.Item3}");
            }

            // Create X variables
            List<Variable> X = new List<Variable>();
            BuildXVariables(X, G, Constants.VERTICES);

            // Create Y variables
            List<Variable> Y = new List<Variable>();
            BuildYVariables(Y, Constants.VERTICES, Constants.MAX_STEPS);


            // Generate formulas
            string initFormula = FormulaGenerator.GenerateInitialFormula(emptyVertexIndex);
            string oneStepFormula = FormulaGenerator.GenerateOneStepFormula(A);
            string legalFormula = FormulaGenerator.GenerateLegalFormula(A);
            string stepsFormula = FormulaGenerator.GenerateStepsFormula(A);
            string finalFormula = FormulaGenerator.GenerateFinalFormula();

            Console.WriteLine("Generate formulas.");

            // Convert initFormula to CNF format
            List<string> clausesList1 = ConvertFormulaToCnfFormat(initFormula, "a");
            Console.WriteLine("a.");
            List<string> clausesList2 = ConvertFormulaToCnfFormat(oneStepFormula, "b");
            Console.WriteLine("b.");
            List<string> clausesList3 = ConvertFormulaToCnfFormat(legalFormula, "c");
            Console.WriteLine("c.");
            List<string> clausesList4 = ConvertFormulaToCnfFormat(stepsFormula, "d");
            Console.WriteLine("d.");
            List<string> clausesList5 = ConvertFormulaToCnfFormat(finalFormula, "e");
            Console.WriteLine("e.");

            Console.WriteLine("Convert initFormula to CNF format.");


            // Create one list of CNF clauses
            List<string> allCnfClauses = new List<string>();
            allCnfClauses.AddRange(clausesList1);
            Console.WriteLine("Constraint 1 created.");

            allCnfClauses.AddRange(clausesList2);
            Console.WriteLine("Constraint 2 created.");

            allCnfClauses.AddRange(clausesList3);
            Console.WriteLine("Constraint 3 created.");

            allCnfClauses.AddRange(clausesList4);
            Console.WriteLine("Constraint 4 created.");

            allCnfClauses.AddRange(clausesList5);
            Console.WriteLine("Constraint 5 created.");

            // Create CNF file
            CnfFileGenerator.CreateCnfFile(cnfInput, allCnfClauses, variableToIdDict);
            Console.WriteLine("CNF format file created.");

            // Solve formula
            Console.WriteLine("Solving...");
            string sln = SatSolver.Solve(cnfInput);

            // Build solution
            List<Variable> path = SolutionBuilder.BuildSolution(sln, idToVariableDict);
            SolutionBuilder.ShowSolution(path);

            Console.WriteLine("End.");
        }
    }
}
