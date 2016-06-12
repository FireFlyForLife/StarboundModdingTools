using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools
{
    class Program
    {
        static void Main(string[] args) {
            for (int i = 0; i < args.Length; i++) {
                Console.WriteLine(i.ToString() + ": " + args[i]);
                ProcessUtils.StartProcess(args[i]);
            }

            new MainManager();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
