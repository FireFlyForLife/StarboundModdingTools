using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarboundModTools.UI.Designer
{
    public class UITreeView : TreeView
    {

        ContextMenuStrip menu;
        ToolStripMenuItem root;

        public UITreeView() {
            menu = new ContextMenuStrip();
            root = new ToolStripMenuItem("GUI");
            menu.Items.Add(root);
            menu.Opening += Menu_Opening;

            this.MouseClick += mouseClick;
            this.MouseDoubleClick += mouseDoubleClick;
        }

        private void mouseDoubleClick(object sender, MouseEventArgs e) {

        }

        private void mouseClick(object sender, MouseEventArgs e) {
            
        }

        private void Menu_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            UITreeNode node = (UITreeNode)sender;
            menu.Items.Clear();
            foreach(ToolStripMenuItem item in node.GetMenuItems())
                menu.Items.Add(item);
        }     
    }

   

    #region MenuItems
    
    #endregion
}
