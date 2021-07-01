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



        public bool IsOpen {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(TreeListViewItem), new PropertyMetadata(false, OpenChanged));

        private static void OpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if(d is TreeListViewItem item) {
                item.OnOpenChanged();
            }
        }

        private void OnOpenChanged() {
            //if(Content is TreeListViewNode node) {
            //    node.IsExpanded
            //}
            if (Content is TreeListViewNode node) {
                node.IsExpanded = IsOpen;
            }
            if (ItemsControl.ItemsControlFromItemContainer(this) is TreeListView tree) {
                tree.Reload();
            }
        }

        static TreeListViewItem() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListViewItem), new FrameworkPropertyMetadata(typeof(TreeListViewItem)));
        }

        protected override void OnContentChanged(object oldContent, object newContent) {
            if(newContent is TreeListViewNode node) {
                node.ExpandedChanged += OnExpandedChanged;
            }
            if (newContent is TreeListViewNode n) {
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
