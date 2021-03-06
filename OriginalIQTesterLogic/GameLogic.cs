﻿using Graphs;
using Logic;
using Resources;
using Sat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Utilities;

namespace OriginalIQTesterLogic
{
    public class GameLogic
    {
        private int _boardsLinesNumber;
        private int _verticesNumber;
        private int _maxStepsNumber;
        private bool[] _U_init;
        private bool[] _U_final;
        private string _cnfInput;
        private int _id;
        private int _mode;
        private Dictionary<string, int> _variableToIdDict;
        private Dictionary<int, string> _idToVariableDict;

        public GameLogic(int boardsLinesNumber, bool[] U_init, bool[] U_final, int mode)
        {
            _boardsLinesNumber = boardsLinesNumber;
            _mode = mode;
            if (mode == 1)
            {
                _maxStepsNumber = SumCheckers(U_init) - 1;
            }
            else
            {
                _maxStepsNumber = SumCheckers(U_init) - SumCheckers(U_final);
            }
            Console.WriteLine($"max steps: {_maxStepsNumber}");

            _U_init = U_init;
            _U_final = U_final;
            _variableToIdDict = new Dictionary<string, int>();
            _idToVariableDict = new Dictionary<int, string>();
            _id = 1;
            _cnfInput = "cnfInput.txt";
        }

        private int SumCheckers(bool[] U)
        {
            int sum = 0;
            for (int i = 1; i < U.Length; i++)
            {
                if (U[i])
                {
                    sum++;
                }
            }
            return sum;
        }

        private Graph BuildGraph(int lines, bool[] U_init)
        {
            return new Graph(_boardsLinesNumber, U_init);
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

        public List<Step> SolveGame(BackgroundWorker worker, Logger logger)
        {
            _verticesNumber = Graph.CalculateVertices(_boardsLinesNumber);

            // Build vertices graph

            logger.Write("Building graphs....");
            Graph G = BuildGraph(_boardsLinesNumber, _U_init);
            logger.WriteLine("DONE.");

            // Create group A - valid triplets of neighbor vertices
            logger.Write("Creating group A....");
            List<Tuple<int, int, int>> A = BuildGroupA(G, _verticesNumber);
            logger.WriteLine("DONE.");

            // Create X variables
            logger.Write("Creating X variables....");
            List<Variable> X = new List<Variable>();
            BuildXVariables(X, G, _verticesNumber);
            logger.WriteLine("DONE.");

            // Create Y variables
            logger.Write("Creating X variables....");
            List<Variable> Y = new List<Variable>();
            BuildYVariables(Y, _verticesNumber, _maxStepsNumber);
            logger.WriteLine("DONE.");

            // Generate formulas
            logger.Write("Generating formula 1....");
            string initFormula = FormulaGenerator.GenerateInitialFormula(_U_init);
            logger.WriteLine("DONE.");

            logger.Write("Generating formula 2....");
            string oneStepFormula = FormulaGenerator.GenerateOneStepFormula(A, _maxStepsNumber);
            logger.WriteLine("DONE.");

            logger.Write("Generating formula 3....");
            string legalFormula = FormulaGenerator.GenerateLegalFormula(A, _maxStepsNumber);
            logger.WriteLine("DONE.");

            logger.Write("Generating formula 4....");
            string stepsFormula = FormulaGenerator.GenerateStepsFormula(A, _verticesNumber, _maxStepsNumber);
            logger.WriteLine("DONE.");

            logger.Write("Generating formula 5....");
            string finalFormula;

            if (_mode == 1)
            {
                finalFormula = FormulaGenerator.GenerateFinalFormulaClassic(_verticesNumber, _maxStepsNumber);
            }
            else
            {
                finalFormula = FormulaGenerator.GenerateFinalFormulaAdvanced(_U_final, _maxStepsNumber);
            }
            logger.WriteLine("DONE.");


            // Check cancel
            if (worker.CancellationPending)
            {
                logger.WriteLine("Solver cancelled.");
                return null;
            }

            // Convert NNF formulas to CNF format
            CnfConverter cnfConverter = new CnfConverter(_variableToIdDict, _idToVariableDict, _id);

            logger.Write("Converting formula 1....");
            List<string> clausesList1 = cnfConverter.ConvertFormulaToCnfFormat(initFormula, "a");
            logger.WriteLine("DONE.");

            logger.Write("Converting formula 2....");
            List<string> clausesList2 = cnfConverter.ConvertFormulaToCnfFormat(oneStepFormula, "b");
            logger.WriteLine("DONE.");

            logger.Write("Converting formula 3....");
            List<string> clausesList3 = cnfConverter.ConvertFormulaToCnfFormat(legalFormula, "c");
            logger.WriteLine("DONE.");

            logger.Write("Converting formula 4....");
            List<string> clausesList4 = cnfConverter.ConvertFormulaToCnfFormat(stepsFormula, "d");
            logger.WriteLine("DONE.");

            logger.Write("Converting formula 5....");
            List<string> clausesList5 = cnfConverter.ConvertFormulaToCnfFormat(finalFormula, "e");
            logger.WriteLine("DONE.");

            //Check cancel
            if (worker.CancellationPending)
            {
                logger.WriteLine("Solver cancelled.");
                return null;
            }

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
            string sln = SatSolver.Solve(_cnfInput, worker, logger);

            // Build solution
            logger.Write("Building solution...");
            List<Variable> path = SolutionBuilder.BuildSolution(sln, _idToVariableDict);
            List<Step> stepsList = SolutionBuilder.RetrieveSolution(path);
            logger.WriteLine("DONE.");

            return stepsList;
        }
    }
}
