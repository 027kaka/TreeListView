using System.Windows;
using System.Windows.Controls;

namespace ListBoxDemo.Controls {
    public class TreeListView : ListView {

        public static readonly DependencyProperty RootProperty;

        public TreeListViewNode Root {
            get { return (TreeListViewNode)GetValue(RootProperty); }
            set { SetValue(RootProperty, value); }
        }


        static TreeListView() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListView), new FrameworkPropertyMetadata(typeof(TreeListView)));
            RootProperty = DependencyProperty.Register("Root", typeof(TreeListViewNode), typeof(TreeListView), new PropertyMetadata(null, OnRootChanged));
        }

        protected override DependencyObject GetContainerForItemOverride() {
            return new TreeListViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item) {
            return item is TreeListViewItem;
        }

        private static void OnRootChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if(d is TreeListView tree) {
                tree.ItemsSource = tree.Root.ToList();
            }
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item) {
            if(element is TreeListViewItem treeItem) {
                treeItem.Content = item;
            }
            base.PrepareContainerForItemOverride(element, item);
        }

        public void Reload() {
            ItemsSource = Root.ToList();
        }
    }
}
