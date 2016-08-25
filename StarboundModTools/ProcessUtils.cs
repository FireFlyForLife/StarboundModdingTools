using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools
{
    public static class ProcessUtils
    {
        //MAYBE: Remove this class or make it a extension class.
        public static Process StartProcess(String exePath) {

            ProcessStartInfo start = new ProcessStartInfo(exePath);
            //start.UseShellExecute = false;
            //start.RedirectStandardError = true;
            //start.RedirectStandardOutput = true;
            
            Process process = new Process();
            process.StartInfo = start;
            //process.OutputDataReceived += OnOutput;
            //process.ErrorDataReceived += OnOutput;
            try {
                process = process.Start() ? process : null;
            }catch(Win32Exception ex) {
                Console.WriteLine(ex);
                return null;
            }
            
            //if (process == null)
            //    return null;

            //process.BeginOutputReadLine();
            //process.BeginErrorReadLine();

            return process;
        }

        public static void OnOutput(Object sender, DataReceivedEventArgs args) {
            Console.WriteLine((sender as Process)?.ProcessName + ": " + args.Data);
        }
    }
}
