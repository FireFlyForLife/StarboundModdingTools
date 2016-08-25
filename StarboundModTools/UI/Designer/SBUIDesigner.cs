using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema.Generation;
using StarboundModTools.UI.Designer.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CBI = StarboundModTools.UI.Designer.ComboBoxItem<StarboundModTools.UI.Designer.Nodes.Node>;

namespace StarboundModTools.UI.Designer
{
    public partial class SBUIDesigner : Form
    {
        //List<Node> gui;
        ContextMenuStrip uiAddMenu;
        SBUINodeManager nodeManager;

        public SBUIDesigner() {
            InitializeComponent();

            treeView.HideSelection = false;

            nodeManager = new SBUINodeManager();

            //uiAddMenu = new ContextMenuStrip();
            //ToolStripMenuItem addItem = new ToolStripMenuItem("Add");
            //uiAddMenu.Items.Add(addItem);

            //root = new TreeNode("GUI");
            //treeView.Nodes.Add(root);
            //treeView.MouseClick += TreeView_MouseClick;
            //treeView.MouseDoubleClick += TreeView_MouseDoubleClick;

            List<Node> gui = new List<Node>();
            Node rootNode = new DefaultNode("GUI");
            gui.Add(rootNode);
            rootNode.Children.Add(new DefaultNode("Some test"));
            Node childNode = new DefaultNode("Another one");
            rootNode.Children.Add(childNode);
            childNode.Children.Add(new DefaultNode("LOLOL"));

            nodeManager.Nodes = gui;

            JsonSerializer serializer = JsonSerializer.CreateDefault();
            serializer.Formatting = Formatting.Indented;
            serializer.MetadataPropertyHandling = MetadataPropertyHandling.Default;
            serializer.TypeNameHandling = TypeNameHandling.Auto;

            //Code = serializer.Serialize()
            //Code = JsonConvert.SerializeObject(gui);

            UpdateUI();

            nodeChooser.Items.AddRange(new CBI[] {
                new CBI(new Nodes.Label("Label"), NodeToString),
                new CBI(new Nodes.Image("Image"), NodeToString)
            });
            nodeChooser.SelectedIndex = 0;
        }

        String NodeToString(Node node) {
            return node.Name;
        }

        public String Code
        {
            set { jsonOutput.Text = value; }
            get { return jsonOutput.Text; }
        }

        public void UpdateUI() {
            UpdateJson();
            UpdateTreeView();
        }

        public void UpdateJson() {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using(JsonTextWriterThing writer = new JsonTextWriterThing(sw)) {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 2;
                
                writer.WriteStartObject();
                foreach(Node node in nodeManager.Nodes) {
                    WriteSubNode(writer, node);
                }
                writer.WriteEndObject();
            }

            Code = sb.ToString();
        }

        void WriteSubNode(JsonTextWriterThing writer, Node node) {
            writer.WritePropertyName(node.Name);
            writer.WriteStartObject();
            foreach (KeyValuePair<String, Object> pair in node.Values)
                writer.WriteProperty(pair);

            foreach (Node subNode in node.Children) {
                WriteSubNode(writer, subNode);
            }

            writer.WriteEndObject();
        }

        public void UpdateTreeView() {
            treeView.Nodes.Clear();
            treeView.Nodes.AddRange(nodeManager.GetTreeNodeList().ToArray());
        }

        private void TreeView_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (e.Button.Equals(MouseButtons.Left)) {
                TreeNode node = treeView.GetNodeAt(e.Location);
                if(node != null) {

                }
            }
        }

        private void TreeView_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button.Equals(MouseButtons.Right)) {

            }
        }

        private void addButton_Click(object sender, EventArgs e) {
            TreeNode treeNode = treeView.SelectedNode;
            if (treeNode != null) {
                Node toAdd = ((CBI)nodeChooser.SelectedItem).InternalItem.Clone();
                Node clicked = nodeManager.GetNode(treeNode);
                clicked?.Children.Add(toAdd);
                UpdateUI();
            } else
                Console.WriteLine("Please Select a node from the TreeView.");
        }

        private void removeButton_Click(object sender, EventArgs e) {
            TreeNode treeNode = treeView.SelectedNode;
            if (treeNode != null) {
                Node clicked = nodeManager.GetNode(treeNode);
                Node parentClicked = nodeManager.GetNode(treeNode.Parent);
                if (clicked != null && parentClicked != null) {
                    parentClicked.Children.Remove(clicked);
                    UpdateUI();
                }
            } else
                Console.WriteLine("Please Select a node from the TreeView.");
        }

        private void changeButton_Click(object sender, EventArgs e) {

        }
    }
}

