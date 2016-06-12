using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public class AliasProvider : ICommand
    {
        CommandManager cm;

        public AliasProvider() {
            cm = CommandManager.get;
        }

        public string Description
        {
            get
            {
                return "Redirects a command call from a word to a command," + 
                    "\ngenerally used to avoid long command names.";
            }
        }

        public string Name
        {
            get
            {
                return "alias";
            }
        }

        public string Usage
        {
            get
            {
                return "Usage: alias set <input> <output> - Adds a alias so you can type <input> which runs command <output>." +
                    "\nOr: alias add <input> <output> - Adds a alias so you can type <input> which runs command <output>." +
                    "\nOr: alias del <input> <output> - Deletes an alias which redirected a call from <input> to <output>.";
            }
        }

        public void Run(string[] args) {
            if(args.Length == 1) {
                return;
            }
            if(args.Length > 3) {
                if(args[1].Equals("set") || args[1].Equals("add")) {
                    String input = args[2];
                    String output = args[3];
                    ICommand outCom = cm.GetByName(output);
                    if (outCom != null)
                        AddAlias(input, outCom);
                }else if (args[1].Equals("del")) {
                    String input = args[2];
                    String output = args[3];
                    foreach(ICommand c in cm.list) {
                        Alias a = c as Alias;
                        if (a != null && a.Name.Equals(input) && a.target.Equals(output)) {
                            RemoveAlias(a);
                            return;
                        }
                    }
                }
            }
        }

        public void AddAlias(String alias, ICommand command) {
            Alias a = new Alias(alias, command);
            cm.Add(a);
            Console.WriteLine("Succesfully created alias: '" + alias + "' of command: '" + command.Name + "'.");
        }

        public void RemoveAlias(Alias alias) {
            cm.list.Remove(alias);
            Console.WriteLine("Succesfully deleted alias: '" + alias.Name + "' of command: '" + alias.target + "'.");
        }
    }

    public class Alias : ICommand
    {
        String name;
        ICommand redirect;

        public Alias(String name, ICommand com) {
            if (name == null || com == null)
                throw new ArgumentNullException();

            this.name = name;
            this.redirect = com;
        }

        public String target { get { return redirect.Name; } }

        public string Description
        {
            get
            {
                return "This alias redirects to the command: " + redirect.Name;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Usage
        {
            get
            {
                return "To use simply call this command with the correct arguments\nand it will be executed.";
            }
        }

        public void Run(string[] args) {
            args[0] = redirect.Name;
            redirect.Run(args);
        }
    }
}
