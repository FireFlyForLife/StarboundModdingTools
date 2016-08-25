using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public class Close : ICommand
    {
        Start start;

        public Close(Start StartCommand) {
            start = StartCommand;
        }

        public string Description
        {
            get
            {
                return "Closes processes started by the 'start' command.";
            }
        }

        public string Name
        {
            get
            {
                return "close";
            }
        }

        public string Usage
        {
            get
            {
                return "Usage: close [amount/'all'] - closes the opened game and console from the 'start' command" + 
                    "\nstarting from the oldest opened games. If amount is specified multiple games+consoles will be closed." +
                    "\nIf all games+consoles need to be closed give 'all' as the first argument.";
            }
        }

        public void Run(string[] args) {
            if(args.Length >= 2 && !String.IsNullOrEmpty(args[1])) {
                int amount;
                if (int.TryParse(args[1], out amount)) {
                    killProcesses(amount);
                } else if (args[1].Equals("all")) {
                    killProcesses(int.MaxValue);
                } else {
                    Console.WriteLine("ERROR: First argument is not a number nor is it 'all'.");
                }
            } else {
                killProcesses(1);
            }
        }

        void killProcesses(int amount) {
            Process[] games = start.GetOpenedGames();
            for(int i = 0; i < games.Length && i < amount; i++) {
                games[i]?.CloseMainWindow();
            }

            Process[] consoles = start.GetOpenedConsoles();
            for (int i = 0; i < consoles.Length && i < amount; i++) {
                consoles[i]?.CloseMainWindow();
            }
        }
    }
}
