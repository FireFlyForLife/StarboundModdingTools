using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public class Echo : ICommand
    {
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
                return "Usage: echo <message>... - Echo's all the messages in the command prompt.";
            }
        }

        public void Run(string[] args) {
            for(int i = 1; i < args.Length; i++) {
                Console.Write(args[i]);
                if (i != args.Length)
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
