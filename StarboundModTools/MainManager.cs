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
            Start start = new Start();
            ret.Add(start);
            ret.Add(new Close(start));
            ret.Add(new AliasProvider() );
            ret.Add(new Echo());
            ret.Add(new Config());
            Exit exit = new Exit();
            ret.Add(exit);
            ret.Add(new Alias("stop", exit));
            ret.Add(new Equals());
            Packing packer = new Packing();
            ret.Add(packer);
            ret.Add(new Alias("pack", new String[] { "pack" }, packer));
            ret.Add(new Alias("unpack", new String[] { "unpack" }, packer));
            ret.Add(new Test());
            GuiDesigner designer = new GuiDesigner();
            ret.Add(designer);
            ret.Add(new Alias("ui", designer));

            return ret;
        }
    }
}
