using StarboundModTools.UI.Designer.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.UI.Designer.Nodes
{
    //TODO: Populate this
    public class NodeManager
    {
        List<Node> nodes;

        public NodeManager() {
            nodes = new List<Node>();
        }

        public List<Node> Nodes
        {
            set { nodes = value; }
            get { return nodes; }
        }

        /// <summary>
        /// Gets a 1d list of all nodes, using the GetAllChildren() method.
        /// </summary>
        /// <returns>A 1d list of all nodes</returns>
        public List<Node> GetAll() {
            List<Node> nodes = new List<Node>();
            foreach (Node node in this.nodes) {
                nodes.AddRange(GetAllChildren(node));
            }

            return nodes;
        }

        /// <summary>
        /// Recusively get all the children of a Node
        /// </summary>
        /// <param name="node">The node which is used as the root.</param>
        /// <returns>A List of itself and all children of that node.</returns>
        public List<Node> GetAllChildren(Node node) {
            List<Node> nodes = new List<Node>();
            nodes.Add(node);
            foreach(Node subNode in node.Children) {
                nodes.Add(subNode);
                nodes.AddRange(GetAllChildren(subNode));
            }

            return nodes;
        }

        public Node GetNodeByName(String name) {
            foreach(Node node in GetAll()) {
                if (node.Name.Equals(name))
                    return node;
            }

            return null;
        }
    }
}
