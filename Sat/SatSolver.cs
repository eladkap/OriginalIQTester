using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using Utilities;

namespace Sat
{
    public class SatSolver
    {
        public static string Solve(string cnfInput, BackgroundWorker worker, TextBox label3)
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

            // hide process window
            processStartInfo.WindowStyle = ProcessWindowStyle.Minimized;

            // set python script arguments
            processStartInfo.Arguments = pythonScript + " " + cnfInput;

            string sln;

            Process pythonProcess = new Process();

            // assign start information to the process 
            pythonProcess.StartInfo = processStartInfo;

            // start process 
            pythonProcess.Start();

            label3.Text = "Busy";
            // check for cancellation
            bool isBusy = true;
            while (isBusy)
            {
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (!clsProcess.ProcessName.Contains(pythonProcess.ProcessName))
                    {
                        isBusy = false;
                        break;
                    }
                }

                if (worker.CancellationPending)
                {
                    label3.Text = "Cancel";
                    pythonProcess.Kill();
                    break;
                }
                Thread.Sleep(1000);
            }
            label3.Text = "finished";


            // Read the standard output of the app we called.  
            StreamReader myStreamReader = pythonProcess.StandardOutput;
            sln = myStreamReader.ReadLine();

            // wait exit signal from the app we called
            pythonProcess.WaitForExit();

            pythonProcess.Close();

            /*
            using (Process pythonProcess = new Process())
            {
                // assign start information to the process 
                pythonProcess.StartInfo = processStartInfo;

                // start process 
                pythonProcess.Start();

                // check for cancellation
                while (!pythonProcess.HasExited) // !pythonProcess.HasExited or worker.IsBusy
                {
                    if (worker.CancellationPending && !pythonProcess.HasExited) //  && !pythonProcess.HasExited
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
            */


            return sln;
        }
    }
}
