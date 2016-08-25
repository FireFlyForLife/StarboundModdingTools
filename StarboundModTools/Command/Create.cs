using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public class Create : ICommand
    {


        public Create() {

        }

        public string Description
        {
            get
            {
                return "Create a file from one of several templates.";
            }
        }

        public string Name
        {
            get
            {
                return "create";
            }
        }

        public string Usage
        {
            get
            {//LOOKAT: does this command need more uses? maybe another command, Template?
                return "Usage: create <type> <file name> - ";//TODO: Add actual usage description.
            }
        }

        public void Run(string[] args) {

        }
    }
}
