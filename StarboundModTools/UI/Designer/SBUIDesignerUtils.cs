using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.UI.Designer
{
    public static class SBUIDesignerUtils
    {

    }

    public  class ComboBoxItem <T>
    {
        T item;
        GetString gs;

        public ComboBoxItem(T item, GetString toString) {
            InternalItem = item;
            gs = toString;
        }
        
        public T InternalItem { set { item = value; } get { return item; } }

        public delegate String GetString(T item);

        public override string ToString() {
            return gs(item);
        }
    }
}
