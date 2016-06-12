using StarboundModTools.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools
{
    public class MainManager
    {
        CommandManager cm;
        ConsoleWorker cw;

        public MainManager() {
            cm = CommandManager.get;
            cm.AddAll(getCommands());

            cw = new ConsoleWorker("Welcome to Starbound Modding Utilities! Enter 'help' to learn more.", "exit");
            cw.Listen();
        }

        static List<ICommand> getCommands() {
            List<ICommand> ret = new List<ICommand>();
            ret.Add(new Help());
            ret.Add(new Vars());
            ret.Add(new Start());
            ret.Add(new AliasProvider() );
            ret.Add(new Echo());
            ret.Add(new Config());
            Exit exit = new Exit(); ret.Add(exit);
            ret.Add(new Alias("stop", exit));

            return ret;
        }
    }
}
