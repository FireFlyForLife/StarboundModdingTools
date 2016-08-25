using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public class Vars : ICommand
    {


        public Vars() {

        }

        public string Description
        {
            get
            {
                return "Used for setting and getting internal variables.";
            }
        }

        public string Name { get { return "var"; } }

        public string Usage
        {
            get
            {
                return "Usage: var set <key> <value> - Sets the current variable named <key> to the <value> value.\n" +
                    "Or: var get <key> - Get the variable named <key>.";
            }
        }

        public void Run(string[] args) {
            if (args.Length == 1) {
                Console.WriteLine(Name + " - " + Description);
                return;
            }
            if(args.Length > 2 && args[1].Equals("get"))
                Console.WriteLine(SVars.getValue<Object>(args[2])?.ToString());
            if (args.Length > 3 && args[1].Equals("set"))//LOOKAT: add solution of other types, ex: Booleans
                if (SVars.getValue<object>(args[2]) != null) {
                    SVars.Change(args[2], args[3]);
                } else {
                    SVars.Register(args[2], args[3]);
                }
        }
    }
}