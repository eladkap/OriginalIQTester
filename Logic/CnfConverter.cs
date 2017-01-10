using System.Collections.Generic;

namespace Logic
{
    public class CnfConverter
    {
        int _id;
        Dictionary<string, int> _variableToIdDict;
        Dictionary<int, string> _idToVariableDict;

        public CnfConverter(Dictionary<string, int> variableToIdDict, Dictionary<int, string> idToVariableDict, int startId)
        {
            _variableToIdDict = variableToIdDict;
            _idToVariableDict = idToVariableDict;
            _id = startId;
        }

        public List<string> ConvertFormulaToCnfFormat(string formula, string key)
        {
            if (formula.Equals(""))
            {
                return new List<string>();
            }
            List<string> cnfClauses = ConvertNnfToCnf(formula, key);
            return cnfClauses;
        }

        private List<string> ConvertNnfToCnf(string formula, string key)
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
                if (!_variableToIdDict.ContainsKey(var.ToString()))
                {
                    _variableToIdDict.Add(var.ToString(), _id);
                    _idToVariableDict.Add(_id, var.ToString());
                }
                _id++;
            }

            tseiting.SplitCnfClauses();

            // Convert CNF formula to CNF format for SAT solver

            List<string> cnfClauses = ConvertToCnfFormat(tseiting.cnfFormula);

            return cnfClauses;
        }

        private List<string> ConvertToCnfFormat(List<string> cnfFormula)
        {
            List<string> cnfFormat = new List<string>();
            foreach (var cnfClause in cnfFormula)
            {
                string cnfFormatClause = ConvertToCnfClauseFormat(cnfClause);
                cnfFormat.Add(cnfFormatClause);
            }
            return cnfFormat;
        }

        private string ConvertToCnfClauseFormat(string cnfClause)
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
                int id = _variableToIdDict[varName];
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
    }
}
