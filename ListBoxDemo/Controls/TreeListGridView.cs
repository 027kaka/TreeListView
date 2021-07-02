using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListBoxDemo.Controls {
    public class TreeListGridView : GridView {
        public static ResourceKey ItemContainerStyle { get; private set; }
        static TreeListGridView() {
            ItemContainerStyle = new ComponentResourceKey(typeof(TreeListView), "TreeListGridViewItemContainerStyleKey");
        }

        protected override object ItemContainerDefaultStyleKey {
            get {
                return ItemContainerStyle;
            }
        }
    }
}
