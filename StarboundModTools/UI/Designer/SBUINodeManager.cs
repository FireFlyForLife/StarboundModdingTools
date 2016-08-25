using StarboundModTools.UI.Designer.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarboundModTools.UI.Designer
{
    public class SBUINodeManager : NodeManager
    {
        public SBUINodeManager() {

        }

        public List<TreeNode> GetTreeNodeList() {
            List<TreeNode> treeNodes = new List<TreeNode>();
            foreach (Node node in Nodes) {
                treeNodes.AddRange(GetTreeNodes(node));
            }
            return treeNodes;
        }

        List<TreeNode> GetTreeNodes(Node node) {
            List<TreeNode> list = new List<TreeNode>();
            TreeNode root = new TreeNode(node.Name);
            list.Add(root);
            foreach (Node n in node.Children) {
                TreeNode treeNode = new TreeNode(n.Name);
                root.Nodes.Add(treeNode);
                foreach (Node subNode in n.Children) {
                    List<TreeNode> childNodes = GetTreeNodes(subNode);
                    treeNode.Nodes.AddRange(childNodes.ToArray());
                }
            }

            return list;
        }

        public Node GetNode(TreeNode treeNode) {
            return this.GetNodeByName(treeNode.Text);
        }
    }
}
