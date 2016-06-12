using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public class Exit : ICommand
    {
        public string Description
        {
            get
            {
                return "Stops the program, or more specificaly this console worker.";
            }
        }

        public string Name
        {
            get
            {
                return "exit";
            }
        }

        public string Usage
        {
            get
            {
                return "Usage: exit - stops the program.";
            }
        }

        public void Run(string[] args) {
            SVars.Change("exit", true);
        }
    }
}
