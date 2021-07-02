﻿using System.Windows;
using System.Windows.Controls;

namespace TreeListView.Controls {
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
            if (newContent is TreeListViewNode node) {
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
