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


            var book = new Book("book name1", "123");
            book.Children.Add(new Book("book name12", "12123", book));
            var book2 = new Book("book name13", "13123", book);

            book2.Children.Add(new Book("book name13-2", "13123-2", book2));
            book2.Children.Add(new Book("book name13-2", "13123-2", book2));
            book2.Children.Add(new Book("book name13-2", "13123-2", book2));
            book2.Children.Add(new Book("book name13-2", "13123-2", book2));
            book2.Children.Add(new Book("book name13-2", "13123-2", book2));
            book2.Children.Add(new Book("book name13-2", "13123-2", book2));

            book.Children.Add(book2);
            book.Children.Add(new Book("book name14", "14123", book));
            book.Children.Add(new Book("book name15", "15123", book));
            book.Children.Add(new Book("book name16", "16123", book));
            book.IsExpanded = true;
            treeGridView.Root = book;
        }
    }


    public class Book : TreeListViewNode {
        private string orderNumber;
        public Book(string text, string orderNumber, Book parent = null) : base(text, parent) {
            this.orderNumber = orderNumber;
        }

        public string OrderNumber {
            get {
                return orderNumber;
            }

            set {
                orderNumber = value;
            }
        }
    }

}