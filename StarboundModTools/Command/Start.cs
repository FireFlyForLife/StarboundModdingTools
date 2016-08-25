using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public class Start : ICommand
    {
        List<Process> runningGames;
        List<Process> runningConsoles;

        public Start() {
            runningGames = new List<Process>();
            runningConsoles = new List<Process>();
        }

        public Process[] GetOpenedGames() 
        { 
            return runningGames.ToArray(); 
        }

        public Process[] GetOpenedConsoles() 
        {
            return runningConsoles.ToArray();
        }

        public string Description
        {
            get
            {
                return "Starts a process, of which the executable is defined in the 'game' variable or first argument." +
                    "\nAfter starting, the console output is captured and outputs in this command prompt.";
            }
        }

        public string Name { get { return "start"; } }

        public string Usage
        {
            get
            {
                return "Usage: start [filePath] - Starts a process of an executable, if [filePath] is not given, then the 'game' variable will be used." +
                    "\nTo set the filepath to the executable use: var set game <filePath>." +
                    "\nYou should surround your file path in quotes if it contains spaces";
            }
        }

        public void Run(string[] args) {
            String path = null;
            if (args.Length == 1) {
                path = SVars.getValue<String>("game");

            } else if (args.Length > 1) {
                path = args[1];
            }

            if (!File.Exists(path)) {
                Console.WriteLine("The executable was not found in path: " + path);
                return;
            }

            ProcessStartInfo gameStart = new ProcessStartInfo();
            gameStart.FileName = Path.GetFileName(path);
            gameStart.WorkingDirectory = Path.GetDirectoryName(path);

            Console.WriteLine("Starting process at: \"" + path + "\"");
            Process game = Process.Start(gameStart);
            game.EnableRaisingEvents = true;
            game.Exited += GameClosed;
            runningGames.Add(game);

            String storrageDir = "giraffe_storage"; //MAYBE: make this configurable
            String logfile = "starbound.log";
            String logPath = Directory.GetParent(Path.GetDirectoryName(path)).FullName + Path.DirectorySeparatorChar + storrageDir +
                Path.DirectorySeparatorChar + logfile;

            ProcessStartInfo consoleStart = new ProcessStartInfo();
            consoleStart.Arguments = "\"" + logPath + "\"";
            consoleStart.FileName = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + 
                Path.DirectorySeparatorChar + "FileListener.exe";

            Process externConsole = Process.Start(consoleStart);
            externConsole.EnableRaisingEvents = true;
            externConsole.Exited += ConsoleClosed;
            runningConsoles.Add(externConsole);
        }

        private void GameClosed(object sender, EventArgs e) {
            Process toRemove = (Process)sender;
            if (runningGames.Remove(toRemove))
                Console.WriteLine("The game just closed.");
            else
                Console.WriteLine("Is there some way a process is already removed???");
        }

        private void ConsoleClosed(object sender, EventArgs e) {
            Process toRemove = (Process)sender;
            if (runningConsoles.Remove(toRemove))
                Console.WriteLine("File Listener just exited.");
            else
                Console.WriteLine("Is there some way a process is already removed???");
        }
    }
}
