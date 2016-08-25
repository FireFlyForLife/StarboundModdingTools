using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public class Test : ICommand
    {
        public string Description
        {
            get
            {
                return "If you see this please tell me to remove it for the final release.";
            }
        }

        public string Name
        {
            get
            {
                return "test";
            }
        }

        public string Usage
        {
            get
            {
                return "";
            }
        }

        public void Run(string[] args) {
            String path = @"C:\Program Files (x86)\Steam\steamapps\common\Starbound\win64\starbound.exe";
            String other = @"..\..\";
            Console.WriteLine(Path.GetFullPath(Path.Combine(path, other)));
        }
    }
}
