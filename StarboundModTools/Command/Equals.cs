using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public class Equals : ICommand
    {
        public string Description
        {
            get
            {
                return "A utility command used to see if a variable has a certain value";
            }
        }

        public string Name
        {
            get
            {
                return "equals";
            }
        }

        public string Usage
        {
            get
            {
                return "Usage: equals <var name> <expected value> - where var name is the key of the variable and value the value.";
            }
        }

        public void Run(string[] args) {
            if(args.Length == 3) {
                String key = args[1];
                String realValue = SVars.getValue<String>(key);
                String expectedValue = args[2];

                if(realValue == null) {
                    Console.WriteLine("The value of key: '" + key + "'  has not been set, or is not a String.");
                    return;
                }
                bool eq = expectedValue.Equals(realValue);
                if (eq)
                    Console.WriteLine("Yes, the value:'" + realValue + " of key: '" + key + "' is equal to the given value: '" + expectedValue + "'.");
                else
                    Console.WriteLine("No, the value:'" + realValue + " of key: '" + key + "' is not equal to the given value: '" + expectedValue + "'.");
                
            } else {
                Console.WriteLine("{0} arguments expected, only {1} was/were given", 2, args.Length - 1);
            }
        }
    }
}
