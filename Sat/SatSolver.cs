using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Utilities;

namespace Sat
{
    public class SatSolver
    {
        public static string Solve(string cnfInput, BackgroundWorker worker)
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

            string sln;

            using (Process pythonProcess = new Process())
            {
                // assign start information to the process 
                pythonProcess.StartInfo = processStartInfo;

                // start process 
                pythonProcess.Start();

                // check for cancellation
                while (true)
                {
                    if (worker.CancellationPending && !pythonProcess.HasExited)
                    {
                        pythonProcess.Kill();
                        break;
                    }
                    Thread.Sleep(100);
                }

                // Read the standard output of the app we called.  
                StreamReader myStreamReader = pythonProcess.StandardOutput;
                sln = myStreamReader.ReadLine();

                // wait exit signal from the app we called
                pythonProcess.WaitForExit();
            }
            return sln;
        }
    }
}
