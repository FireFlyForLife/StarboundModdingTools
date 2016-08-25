using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.UI.Designer.Nodes
{
    public class Image : Node
    {
        public Image(String name) : base(name) {
            Values.Add("type", "image");
            Values.Add("position", new Point());
            Values.Add("file", "/interface/inventory/empty.png");
            Values.Add("dimensions", new Point(1, 1));

            /*
            Other values:
                "centered" : true
                "maxSize" : [40, 40]
                "minSize" : [40, 40]
                "zlevel" : -1
            */
        }
    }
}
