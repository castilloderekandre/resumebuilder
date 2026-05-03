using Core.NTreeStuff;
using UI.Widgets.TreeViewControl;
using System;
using System.Collections.Generic;
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

namespace UI.Widgets.TreeViewControl
{
    /// <summary>
    /// Interaction logic for TreeView.xaml
    /// </summary>
    public partial class TreeView : UserControl
    {
        TreeViewController treeViewController;
        public TreeView(string title, NTree<object> treeItems)
        {
            InitializeComponent();
            titleLabel.Content = title;
            treeViewController = new(listBox, treeItems);
        }

        private void Up_Button_Click(object sender, RoutedEventArgs e)
        {
            treeViewController.MoveSelectedItemUp();
        }

        private void Down_Button_Click(object sender, RoutedEventArgs e)
        {
            treeViewController.MoveSelectedItemDown();
        }

        private void Item_Collection_Source_Change_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
