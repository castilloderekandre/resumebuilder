using Core.NTreeStuff;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        NTree<object> tree = new();
        NTreeNode<object> node1 = new("section");
        NTreeNode<object> node2 = new("section");
        NTreeNode<object> node3 = new("entry a");
        NTreeNode<object> node4 = new("entry b");
        NTreeNode<object> node5 = new("entry c");
        NTreeNode<object> node6 = new("entry d");
        NTreeNode<object> node7 = new("entry e");
        NTreeNode<object> node8 = new("entry f");

        tree.AddChild(0, node1);
        tree.AddChild(0, node2);

        tree.AddChild(node1, node3);
        tree.AddChild(node1, node4);

        tree.AddChild(node3, node5);

        tree.AddChild(node5, node6);

        tree.AddChild(node2, node7);

        tree.AddChild(node7, node8);

        Widgets.TreeViewControl.TreeView treeView = new("World", tree);

        ParentGrid.Children.Add(treeView);
    }
}