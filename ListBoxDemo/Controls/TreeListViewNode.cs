using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ListBoxDemo.Controls {
    public class TreeListViewNode : Control {
        //public static readonly DependencyProperty IsExpandedProperty;
        public static readonly RoutedEvent ExpandedChangedEvent;
        private string text;
        private TreeListViewCollection<TreeListViewNode> children;
        private TreeListViewNode nodeParent;

        public TreeListViewCollection<TreeListViewNode> Children {
            get {
                return children;
            }

            set {
                children = value;
            }
        }
        public string Text {
            get {
                return text;
            }

            set {
                text = value;
            }
        }

        public bool HasItem => this.Children.Any();

        private bool isExpanded;

        public event RoutedEventHandler ExpandedChanged {
            add {
                AddHandler(ExpandedChangedEvent, value);
            }
            remove {
                RemoveHandler(ExpandedChangedEvent, value);
            }
        }


        public TreeListViewNode NodeParent {
            get {
                return nodeParent;
            }

            set {
                nodeParent = value;
            }
        }

        public int Level {
            get {
                if (NodeParent is null)
                    return 0;
                return NodeParent.Level + 1;
            }
        }

        public Thickness LevelPadding {
            get { 
                return new Thickness(15 * Level, 0, 0, 0); 
            }
        }

        public bool IsExpanded {
            get {
                return isExpanded;
            }

            set {
                if(isExpanded != value) {
                    isExpanded = value;
                    if (isExpanded) {
                        LoadingChildren();
                    } else {
                        CollapsingChildren();
                    }
                    OnExpandedChanged();
                }
            }
        }

        static TreeListViewNode() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListViewNode), new FrameworkPropertyMetadata(typeof(TreeListViewNode)));
            ExpandedChangedEvent = EventManager.RegisterRoutedEvent(nameof(ExpandedChanged), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TreeListViewNode));
        }

        private static void OnExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is TreeListViewNode node) {
                node.OnExpandedChanged();
            }
        }

        private void OnExpandedChanged() {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ExpandedChangedEvent, this);
            RaiseEvent(newEventArgs);
        }

        public TreeListViewNode(string text, TreeListViewNode parent = null) {
            this.text = text;
            nodeParent = parent;
            children = new TreeListViewCollection<TreeListViewNode>();
        }

        internal IEnumerable<TreeListViewNode> ToList() {
            var ret = new List<TreeListViewNode>();
            ret.Add(this);
            if (IsExpanded && Children != null && Children.Any()) {
                foreach (var child in this.Children) {
                    var data = child.ToList();
                    ret.AddRange(data);
                }
            }
            return ret;
        }


        protected virtual void LoadingChildren() {

        }

        protected virtual void CollapsingChildren() {

        }
    }
}
