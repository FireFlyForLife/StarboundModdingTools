using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public class Help : ICommand
    {
        CommandManager cm;
        Dictionary<String, String> additionalInfo;

        public Help(Dictionary<String, String> moreInfo = null) {
            cm = CommandManager.get;
            additionalInfo = moreInfo == null ? defaults() : moreInfo;
        }

        public String Name { get { return "help"; } }

        public String Description
        {
            get
            {
                return "Helps you with all the commands in this program.";
            }
        }

        public string Usage
        {
            get
            {
                return "Usage: help - Lists all programs.\n" +
                    "Or: help <command name> - Gives info about the command";
            }
        }

        public void Run(String[] args) {
            bool specific = args.Length > 1;
            if (!specific)
                Console.WriteLine();
            foreach (ICommand c in cm.list) {
                if (specific) {
                    if (c.Name.Equals(args[1])) {
                        Console.WriteLine(c.Name + " - " + c.Description + "\n" + c.Usage);
                        String text;
                        if (additionalInfo.TryGetValue(c.Name, out text))
                            Console.WriteLine("\n" + text);
                    }
                } else {
                    if (cm.list.ElementAt(0) != c) ;
                        //Console.WriteLine(" -# -----------------");
                    Console.WriteLine(c.Name + " - " + c.Description);
                    Console.WriteLine();
                }
            }
        }

        static Dictionary<String, String> defaults() {
            Dictionary<String, String> d = new Dictionary<string, string>();
            d.Add("help", "Some extra info about the help command");

            return d;
        }
    }
}
