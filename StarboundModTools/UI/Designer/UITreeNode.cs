using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarboundModTools.UI.Designer
{
    public class UITreeNode : TreeNode
    {
        string _value;
        string _type;

        public UITreeNode() : base() {
            _value = String.Empty;
            _type = String.Empty;
        }

        public UITreeNode(String name) : base(name) {
            _value = String.Empty;
            _type = String.Empty;
        }

        public virtual bool CanAdd { get { return true; } }
        public virtual bool CanRemove { get { return true; } }
        public virtual bool CanChange { get { return true; } }
        public virtual UITreeNode[] OnAdd() { return new UITreeNode[0]; }
        public virtual String Value { set { _value = value; } get { return _value; } }
        public virtual String Type { set { _type = value; } get { return _type; } }

        public virtual ToolStripMenuItem[] GetMenuItems() {
            //default items
            ToolStripMenuItem add = new ToolStripMenuItem("Add");
            ToolStripMenuItem delete = new ToolStripMenuItem("Delete");
            ToolStripMenuItem change = new ToolStripMenuItem("Change");

            return new ToolStripMenuItem[] { add, delete, change };
        }

        public class Root : UITreeNode
        {
            public Root() : base("GUI"){ }

            public override bool CanAdd
            {
                get
                {
                    return false;
                }
            }

            public override bool CanRemove
            {
                get
                {
                    return false;
                }
            }

            public override bool CanChange
            {
                get
                {
                    return false;
                }
            }
        }
        public class Label : UITreeNode
        {
            public Label(String name) : base(name) { }

            public override UITreeNode[] OnAdd() {
                return base.OnAdd();
            }
        }
    }

    
}
