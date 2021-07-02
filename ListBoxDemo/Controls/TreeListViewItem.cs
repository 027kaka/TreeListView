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
    public class TreeListViewItem : ListViewItem {

        private TreeListView tree;

        public TreeListView Tree {
            get {
                return tree;
            }

            set {
                tree = value;
            }
        }


        static TreeListViewItem() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListViewItem), new FrameworkPropertyMetadata(typeof(TreeListViewItem)));
        }

        protected override void OnContentChanged(object oldContent, object newContent) {
            if(newContent is TreeListViewNode node) {
                node.ExpandedChanged += OnExpandedChanged;
            }
            if (oldContent is TreeListViewNode n) {
                n.ExpandedChanged -= OnExpandedChanged;
            }
            base.OnContentChanged(oldContent, newContent);
        }

        private void OnExpandedChanged(object sender, RoutedEventArgs e) {
            if (ItemsControl.ItemsControlFromItemContainer(this) is TreeListView tree) {
                tree.Reload();
            }
        }
    }
}
