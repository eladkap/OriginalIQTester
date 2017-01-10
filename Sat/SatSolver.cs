using System.Diagnostics;
using System.IO;
using Utilities;

namespace Sat
{
    public class SatSolver
    {
        public static string Solve(string cnfInput)
        {
            // full path of python interpreter  
            string python = Constants.PYTHON_INTERPRETER_FULL_PATH;

            // python app to call  
            string pythonScript = Constants.PYTHON_SAT_SOLVER;

            // Create new process start info 
            ProcessStartInfo processStartInfo = new ProcessStartInfo(python);

            // make sure we can read the output from stdout 
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;

            // set python script arguments
            processStartInfo.Arguments = pythonScript + " " + cnfInput;

            Process pythonProcess = new Process();
            // assign start information to the process 
            pythonProcess.StartInfo = processStartInfo;

            // start process 
            pythonProcess.Start();

            // Read the standard output of the app we called.  
            StreamReader myStreamReader = pythonProcess.StandardOutput;
            string sln = myStreamReader.ReadLine();

            // wait exit signal from the app we called 
            pythonProcess.WaitForExit();

            // close the process 
            pythonProcess.Close();
            return sln;
        }
    }
}
