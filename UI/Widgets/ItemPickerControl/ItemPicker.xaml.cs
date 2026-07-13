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

namespace UI.Widgets.ItemPickerControl
{
    /// <summary>
    /// Interaction logic for ItemPicker.xaml
    /// </summary>
    public partial class ItemPicker : UserControl
    {
        public ItemPicker()
        {
            InitializeComponent();
            Widgets.TreeViewControl.TreeView treeViewReceiving = new("Receiving");
            Widgets.TreeViewControl.TreeView treeViewSending = new("Sending");

            Grid.SetColumn(treeViewReceiving, 0);
            Grid.SetColumn(treeViewSending, 2);


            ParentGrid.Children.Add(treeViewReceiving);
            ParentGrid.Children.Add(treeViewSending);
        }
    }
}
