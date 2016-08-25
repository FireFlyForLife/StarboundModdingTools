using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public class Packing : ICommand
    {
        public string Description
        {
            get
            {
                return "A wrapper for the starbound asset_packer and asset_unpacker.";
            }
        }

        public string Name
        {
            get
            {
                return "packing";//MAYBE: rename this. maybe 'packer'?
            }
        }

        public string Usage
        {
            get
            {
                return "Usage: packing pack <destination folder> <packed file> - packs all the contents in the folder to the output file." +
                    "\nOr: packing unpack <packed files> <destination folder> - unpacks all the contens of the file in the folder.";
            }
        }

        //TODO: Finish this
        public void Run(string[] args) {
            if(args.Length >= 2){
                if (args[1].Equals("pack")) {

                }else if (args[1].Equals("unpack")) {

                }
            }
        }
    }
}
