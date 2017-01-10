using Graphs;
using Logic;
using Resources;
using Sat;
using System;
using System.Collections.Generic;
using Utilities;

namespace OriginalIQTesterLogic
{
    public class GameLogic
    {
        private int _boardsLinesNumber;
        private int _emptyVertexIndex;
        private int _verticesNumber;
        private int _maxStepsNumber;
        private string _cnfInput;
        private int _id;
        private Dictionary<string, int> _variableToIdDict;
        private Dictionary<int, string> _idToVariableDict;

        public GameLogic(int boardsLinesNumber, int emptyVertexIndex)
        {
            _boardsLinesNumber = boardsLinesNumber;
            _emptyVertexIndex = emptyVertexIndex;
            _variableToIdDict = new Dictionary<string, int>();
            _idToVariableDict = new Dictionary<int, string>();
            _id = 1;
            _cnfInput = "cnfInput.txt";
        }

        private Graph BuildGraph(int lines, int emptyVertexIndex)
        {
            return new Graph(_boardsLinesNumber, emptyVertexIndex);
        }

        public List<Tuple<int, int, int>> BuildGroupA(Graph G, int vertices)
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

        public void BuildXVariables(List<Variable> X, Graph G, int vertices)
        {
            for (int p = 1; p <= _maxStepsNumber; p++)
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
                                _variableToIdDict.Add(var.ToString(), _id);
                                _idToVariableDict.Add(_id, var.ToString());
                                _id++;
                                X.Add(var);
                            }
                        }
                    }
                }
            }
        }

        public void BuildYVariables(List<Variable> Y, int vertices, int phases)
        {
            for (int v = 1; v <= vertices; v++)
            {
                for (int p = 1; p <= phases + 1; p++)
                {
                    Variable var = new Variable(v, p, _id);
                    _variableToIdDict.Add(var.ToString(), _id);
                    _idToVariableDict.Add(_id, var.ToString());
                    _id++;
                    Y.Add(var);
                }
            }
        }

        private int CalculateVerticesNumber()
        {
            int verticesNum = 0;
            for (int i = 1; i <= _boardsLinesNumber; i++)
            {
                verticesNum += i;
            }
            return verticesNum;
        }

        public List<Variable> SolveGame()
        {
            _verticesNumber = CalculateVerticesNumber();
            _maxStepsNumber = _verticesNumber - 2;

            // Build vertices graph
            Graph G = BuildGraph(_boardsLinesNumber, _emptyVertexIndex);

            // Create group A - valid triplets of neighbor vertices
            List<Tuple<int, int, int>> A = BuildGroupA(G, _verticesNumber);

            // Create X variables
            List<Variable> X = new List<Variable>();
            BuildXVariables(X, G, _verticesNumber);

            // Create Y variables
            List<Variable> Y = new List<Variable>();
            BuildYVariables(Y, _verticesNumber, _maxStepsNumber);

            // Generate formulas
            string initFormula = FormulaGenerator.GenerateInitialFormula(_emptyVertexIndex, _verticesNumber);
            string oneStepFormula = FormulaGenerator.GenerateOneStepFormula(A, _maxStepsNumber);
            string legalFormula = FormulaGenerator.GenerateLegalFormula(A, _maxStepsNumber);
            string stepsFormula = FormulaGenerator.GenerateStepsFormula(A, _verticesNumber, _maxStepsNumber);
            string finalFormula = FormulaGenerator.GenerateFinalFormula(_verticesNumber, _maxStepsNumber);

            // Convert NNF formulas to CNF format
            CnfConverter cnfConverter = new CnfConverter(_variableToIdDict, _idToVariableDict, _id);
            List<string> clausesList1 = cnfConverter.ConvertFormulaToCnfFormat(initFormula, "a");
            List<string> clausesList2 = cnfConverter.ConvertFormulaToCnfFormat(oneStepFormula, "b");
            List<string> clausesList3 = cnfConverter.ConvertFormulaToCnfFormat(legalFormula, "c");
            List<string> clausesList4 = cnfConverter.ConvertFormulaToCnfFormat(stepsFormula, "d");
            List<string> clausesList5 = cnfConverter.ConvertFormulaToCnfFormat(finalFormula, "e");

            // Create one list of CNF clauses
            List<string> allCnfClauses = new List<string>();
            allCnfClauses.AddRange(clausesList1);
            allCnfClauses.AddRange(clausesList2);
            allCnfClauses.AddRange(clausesList3);
            allCnfClauses.AddRange(clausesList4);
            allCnfClauses.AddRange(clausesList5);

            // Create CNF file
            CnfFileGenerator.CreateCnfFile(_cnfInput, allCnfClauses, _variableToIdDict);

            // Solve formula
            string sln = SatSolver.Solve(_cnfInput);

            // Build solution
            List<Variable> path = SolutionBuilder.BuildSolution(sln, _idToVariableDict);

            return path;
        }
    }
}
