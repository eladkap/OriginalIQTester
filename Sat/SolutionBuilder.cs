﻿using Logic;
using System;
using System.Collections.Generic;

namespace Sat
{
    public class SolutionBuilder
    {
        private static bool HasNumber(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    return true;
                }
            }
            return false;
        }

        public static List<Variable> BuildSolution(string sln, Dictionary<int, string> idToVariableDict)
        {
            if (sln.Equals("UNSAT"))
            {
                return null;
            }

            string[] slnVector = sln.Split(new char[] { ',', '[', ']' });

            List<int> satisfiedIdsList = new List<int>();
            List<Variable> path = new List<Variable>();

            foreach (var literal in slnVector)
            {
                string literalId = literal;
                if (HasNumber(literalId))
                {
                    if (literalId[0] == ' ')
                    {
                        literalId = literalId.Remove(0, 1);
                    }
                    int id = 0;
                    bool result = int.TryParse(literalId, out id);
                    if (result && id > 0)
                    {
                        satisfiedIdsList.Add(id);
                    }
                }
            }

            foreach (var satisfiedId in satisfiedIdsList)
            {
                string satisfiedVar = idToVariableDict[satisfiedId];
                if (satisfiedVar[0] == 'X' || satisfiedVar[0] == 'Y')
                {
                    path.Add(new Variable(satisfiedVar));
                }
            }
            path.Sort();
            return path;
        }

        public static void ShowSolution(List<Variable> path)
        {
            foreach (var variable in path)
            {
                if (variable.Prefix.Equals("X"))
                {
                    Console.WriteLine($"{variable.Phase}: {variable.From} -> {variable.To}");
                }
            }
        }
    }
}
