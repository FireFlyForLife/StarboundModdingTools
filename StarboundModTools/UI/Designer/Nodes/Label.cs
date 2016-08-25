using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.UI.Designer.Nodes
{
    public class Label : Node
    {
        public Label(String name) : base(name) {
            Values.Add("type", "label");
            Values.Add("value", name);
            Values.Add("position", new Point());
            /*
              Other values:
                "hAnchor" : "mid","left","right"
                "minSize" : [48,48]
                "description" : "-todo-"
                "icon" : "/file.png"
                "wrapWidth" : 126
            */
        }
    }
}
