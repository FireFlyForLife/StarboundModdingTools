using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.UI.Designer.Nodes
{
    public abstract class Node
    {
        public List<Node> Children;
        
        public Dictionary<String, Object> Values;
        
        public String Name;

        public Node(String name) {
            Children = new List<Node>();
            Values = new Dictionary<String, Object>();
            Name = name;
        }

        public Node Clone() {
            return (Node)this.MemberwiseClone();
        }
    }
}
