using ListBoxDemo.Controls;
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

namespace ListBoxDemo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            var root = new TreeListViewNode("root");
            root.IsExpanded = true;
            root.Children.Add(new TreeListViewNode("children - 1", root));
            root.Children.Add(new TreeListViewNode("children - 2", root));
            var threed_node = new TreeListViewNode("children - 3", root);
            threed_node.Children.Add(new TreeListViewNode("children - 3 - 1", threed_node));
            threed_node.Children.Add(new TreeListViewNode("children - 3 - 2", threed_node));
            threed_node.Children.Add(new TreeListViewNode("children - 3 - 3", threed_node));
            threed_node.Children.Add(new TreeListViewNode("children - 3 - 4", threed_node));
            threed_node.IsExpanded = true;
            root.Children.Add(threed_node);
            root.Children.Add(new TreeListViewNode("children - 4", root));
            root.Children.Add(new TreeListViewNode("children - 5", root));
            root.Children.Add(new TreeListViewNode("children - 6", root));
            root.Children.Add(new TreeListViewNode("children - 7", root));
            root.Children.Add(new TreeListViewNode("children - 8", root));
            treeListView.Root = root;
        }
    }
}