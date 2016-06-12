using StarboundModTools.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools
{
    public class CommandManager
    {
        #region Singleton
        static CommandManager instance;
        public static CommandManager get{
            get {
                if (instance == null)
                    instance = new CommandManager();
                return instance;
            }
        }
        #endregion
        List<ICommand> commands;

        CommandManager() {
            commands = new List<ICommand>();
        }

        public List<ICommand> list { get { return commands; } }

        public void Add(ICommand command) {
            if (!commands.Contains(command)) {
                commands.Add(command);
            }
        }

        public void AddAll(ICollection<ICommand> coms) {
            foreach (ICommand c in coms)
                Add(c);
        }

        public ICommand GetByName(String name) {
            foreach(ICommand c in commands) {
                if (c.Name.Equals(name))
                    return c;
            }
            return null;
        }

        public ICommand Input(String str) {
            String[] args = str.Split(' ');
            foreach(ICommand c in commands) {
                if (c.Name.Equals(args[0])) {

                    c.Run(args);
                    return c;
                }
            }
            return null;
        }
    }
}
