using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listener = FileListener.Utilities.FileListener;

namespace FileListener
{
    //TODO: Change title to: [exename] log, press enter to exit.
    class Program
    {
        static void Main(string[] args) {
            String path = null;
            if(args.Length == 0) {
                Console.WriteLine("No program arguments, please enter path to file manually.");
                path = askPath();
            }

            if(args.Length > 0) {
                if (args.Length > 1)
                    Console.WriteLine("Listening for multiple files from one program instance is not supported yet, " +
                        "only tracking first argument");

                if (File.Exists(args[0]))
                    path = args[0];
                else {
                    Console.WriteLine("The first argument does not lead to a file, please enter a valid one now:");
                    path = askPath();
                }

            }

            Console.Title = "FileListener - " + Path.GetFileName(path) + "; Press Enter to close";

            Console.WriteLine("Listening for changes of file '" + Path.GetFileName(path) + "', press enter to stop.");

            Listener l = new Listener(path);
            l.OnOutput += OnOutputLine;
            l.Start();

            Console.ReadLine();
            Console.WriteLine("\nExiting...");
            l.Dispose();

            //Console.WriteLine("Press any key to continue...");
            //Console.ReadKey();
        }

        private static void OnOutputLine(object sender, string line) {
            Console.WriteLine(line);
        }

        static String askPath() {
            for(int i = 0; i < 3; i++) {
                String line = Console.ReadLine();

                if (File.Exists(line))
                    return line;

                Console.WriteLine("the given path does not lead to a file, please enter again");
            }
            return String.Empty;
        }
    }
}
