using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools
{
    public static class ProcessUtils
    {
        public static Process StartProcess(String exePath) {
            ProcessStartInfo start = new ProcessStartInfo(exePath);
            start.UseShellExecute = false;
            start.RedirectStandardError = true;
            start.RedirectStandardOutput = true;

            Process process = new Process();
            process.StartInfo = start;
            process.OutputDataReceived += OnOutput;
            process.ErrorDataReceived += OnOutput;

            Process ret = process.Start() ? process : null;

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            return ret;
        }

        public static void OnOutput(Object sender, DataReceivedEventArgs args) {
            Console.WriteLine(sender.ToString() + ": " + args.Data);
        }
    }
}
