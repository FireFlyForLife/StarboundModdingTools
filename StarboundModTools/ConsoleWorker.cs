using StarboundModTools.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools
{
    public class ConsoleWorker
    {
        String exitString;
        CommandManager cm;

        public ConsoleWorker(String startString, String exitString) {
            Console.WriteLine(startString);
            this.exitString = exitString;
            this.cm = CommandManager.get;
            SVars.Register("exit", false);
        }

        public void Listen() {
            String line;
            do {
                Console.Write(">");
                line = Console.ReadLine();

                ICommand c = cm.Input(line);
                if (c == null && line != exitString) Console.WriteLine("Unknown command");

            } while (!SVars.getValue<bool>("exit") && !exitString.Equals(line));
            Console.WriteLine("Goodbye!");
        }

        public String[] splitArgs(String full) {
            //TODO: Add double quotationmark detection
            return full.Split(' ');
        }
    }
}
