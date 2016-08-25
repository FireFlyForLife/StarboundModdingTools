using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace StarboundModTools
{
    public class ConsoleListener : IDisposable
    {
        Process target;
        bool running;
        Timer timer;

        public ConsoleListener() {
            this.target = null;
            this.running = false;
            this.timer = new Timer();
            this.timer.Elapsed += update;
        }

        public ConsoleListener(Process target) {
            this.target = target;
            this.running = false;
            this.timer = new Timer();
        }

        public Process TargetProcess
        {
            set { target = value; }
            get { return target; }
        }

        public void Start() {
            if(target == null) {
                running = false;
                timer.Enabled = false;
                return;//MAYBE: Throw exception?
            }

            running = true;
            timer.Enabled = true;

            if (!WinApi.FreeConsole())
                Console.WriteLine("Could not free console! because: " + Marshal.GetLastWin32Error());
            
        }

        public void Stop() {
            running = false;
            timer.Enabled = false;

            WinApi.FreeConsole();
        }

        public bool IsListening() {
            return running && timer.Enabled;
        }

        public void Dispose() {
            Stop();
        }

        void update(object sender, ElapsedEventArgs e) {
            Console.WriteLine("Updating ConsoleListener...");
        }

        #region Event
        public event LineIn OnOutput;
        public delegate void LineIn(Object sender, String line);

        protected void sendEvent(params String[] lines) {
            if (OnOutput != null) {
                foreach (String s in lines) {
                    OnOutput(this, s);
                }
            }
        }

        public struct ConsoleLine
        {
            public String line;
        }
        #endregion
    }

    public static partial class WinApi
    {
        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeConsole();

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AttachConsole(int dwProcess);


    }

}
