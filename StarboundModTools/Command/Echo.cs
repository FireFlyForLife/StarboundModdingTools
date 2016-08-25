using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public class Echo : ICommand
    {
        public Echo() {
            SVars.Register("echo_axis", "horizontal");
        }

        public string Description
        {
            get
            {
                return "Echo's the message in the console.";
            }
        }

        public string Name
        {
            get
            {
                return "echo";
            }
        }

        public string Usage
        {
            get
            {
                return "Usage: echo <message>... - Echo's all the messages in the command prompt." +
                    "\nIf you want the words to be echoed vertically, set the variable 'echo_axis' to vertical." +
                    "\nEnter: help var - for more information.";
            }
        }

        public void Run(string[] args) {
            String axis = SVars.getValue<String>("echo_axis");
            if (axis.Equals("vertical")) {
                for(int i = 1; i < args.Length; i++) {
                    Console.WriteLine(args[i]);
                }
            } else {
                for (int i = 1; i < args.Length; i++) {
                    Console.Write(args[i]);
                    if (i < args.Length - 1)
                        Console.Write(" ");
                }
                Console.WriteLine();
                if (!axis.Equals("horizontal"))
                    Console.WriteLine("Variable 'echo_axis' is not a known value, known values are: horizontal, vertical." + 
                        "\nResorting to defualt value: horizontal.");
            }
        }
    }
}
