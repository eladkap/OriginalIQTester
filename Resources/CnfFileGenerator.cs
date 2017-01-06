using System.Collections.Generic;
using System.IO;

namespace Resources
{
    public class CnfFileGenerator
    {
        public static void CreateCnfFile(string cnfInput, List<string> cnfClauses, Dictionary<string, int> variableToIdDict)
        {
            int vars = variableToIdDict.Keys.Count; // original and new variables
            int clauses = cnfClauses.Count;

            using (StreamWriter file = new StreamWriter(cnfInput))
            {
                file.WriteLine($"p cnf {vars} {clauses}");
                foreach (string clause in cnfClauses)
                {
                    file.WriteLine(clause);
                }
            }
        }
    }
}
