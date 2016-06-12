using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public class Start : ICommand
    {
        public Start() {

        }

        public string Description
        {
            get
            {
                return "Starts a process, of which the executable is defined in the 'game' variable." + 
                    "\nAfter starting, the console output is captured and outputs in this command prompt.";
            }
        }

        public string Name { get { return "start"; } }

        public string Usage
        {
            get
            {
                return "Usage: start - Starts a process of which the executable is defined in the 'game' variable." +
                    "\nTo set the filepath to the executable use: var set game <filePath>";
            }
        }

        public void Run(string[] args) {
            String path = SVars.getValue<String>("game");
            Console.WriteLine("Starting process at: \"" + path + "\"");
        }
    }
}
