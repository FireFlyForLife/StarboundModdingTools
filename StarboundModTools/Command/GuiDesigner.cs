
using StarboundModTools.UI.Designer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarboundModTools.Command
{
    public class GuiDesigner : ICommand
    {
        public GuiDesigner() {

        }

        public string Description
        {
            get
            {
                return "A Utility for designing UI's in Starbound.";
            }
        }

        public string Name
        {
            get
            {
                return "guidesigner";
            }
        }

        public string Usage
        {
            get
            {
                return "Usage: guidesigner - To open the designer Form.";
            }
        }

        public void Run(string[] args) {
            Thread thread = new Thread(startDesigner);
            thread.Start();
        }

        void startDesigner() {
            SBUIDesigner designer = new SBUIDesigner();
            Application.Run(designer);
        }
    }
}
