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
                return "Usage: alias set <input> <output> [args...] - Adds a alias so you can type <input> which runs command <output>. " +
                    "\nThe amount of [args] is unlimmited and also optional." +
                    "\nOr: alias add <input> <output> [args...] - Adds a alias so you can type <input> which runs command <output>. " +
                    "\nThe amount of [args] is unlimmited and also optional." +
                    "\nOr: alias del <input> <output> - Deletes an alias which redirected a call from <input> to <output>. " +
                    "\nArguments do not have to be specified";
            }
        }

        public void Run(string[] args) {
            if(args.Length == 1) {
                return;
            }
            if(args.Length > 3) {
                if(args[1].Equals("set") || args[1].Equals("add")) {
                    String input = args[2];
                    String[] a = args.Skip(4).ToArray();
                    String output = args[3];
                    ICommand outCom = cm.GetByName(output);
                    if (outCom != null)
                        AddAlias(input, a, outCom);
                }else if (args[1].Equals("del")) {
                    String input = args[2];
                    String output = args[3];
                    foreach(ICommand c in cm.list) {
                        Alias a = c as Alias;
                        if (a != null && a.Name.Equals(input) && a.Target.Equals(output)) {
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

        public void AddAlias(String alias, String[] args, ICommand command) {
            Alias a = new Alias(alias, args, command);
            cm.Add(a);
            Console.WriteLine("Succesfully created alias: '" + alias + "' of command: '" + command.Name + "'.");
        }

        public void RemoveAlias(Alias alias) {
            cm.list.Remove(alias);
            Console.WriteLine("Succesfully deleted alias: '" + alias.Name + "' of command: '" + alias.Target + "'.");
        }
    }

    public class Alias : ICommand
    {
        String name;
        String[] args;
        ICommand redirect;

        public Alias(String name, String[] args, ICommand com) {
            if (name == null || com == null)
                throw new ArgumentNullException();

            this.name = name;
            this.args = args;
            this.redirect = com;
        }

        public Alias(String name, ICommand com) {
            if (name == null || com == null)
                throw new ArgumentNullException();

            this.name = name;
            this.args = null;
            this.redirect = com;
        }

        public String Target { get { return redirect.Name; } }

        public bool HasArgs { get { return args != null; } }

        public string Description
        {
            get
            {
                if(args == null)
                    return "This alias redirects to the command: " + redirect.Name;

                String arglist = String.Empty;
                for(int i = 0; i < args.Length; i++) {
                    arglist += args[i];
                    if (i < args.Length - 1)
                        arglist += ",";
                }

                return "This alias redirects to the command: " + redirect.Name + " with the arguments: " + arglist;
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
                return "To use simply call this command with the correct arguments and it will be executed." +
                    "\nThe usage of " + redirect.Name + " is: " + redirect.Usage;
            }
        }

        public void Run(string[] args) {
            if (HasArgs) {
                String[] newArgs = new String[args.Length + this.args.Length + 1];
                this.args.CopyTo(newArgs, 1);
                newArgs[0] = redirect.Name;
                args.Skip(1).ToArray().CopyTo(newArgs, this.args.Length + 1);
                redirect.Run(newArgs);
            } else {
                args[0] = redirect.Name;
                redirect.Run(args);
            }
        }
    }
}
