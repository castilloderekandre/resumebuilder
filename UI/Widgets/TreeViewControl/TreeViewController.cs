using Core.Extensions;
using Core.NTreeStuff;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using System.Windows.Controls;

namespace UI.Widgets.TreeViewControl
{
    // [TODO] Move items directly in NTree instead of flatTree. Clear items in ListBox and add new flatTree.
    internal class TreeViewController
    {
        ListBox _listBox;
        NTree<object>? Tree { get; set
            {
                field = value;

                if (value is null)
                    return;

                _listBox.Items.Clear();
                AddNodeList();
            } }

        public TreeViewController(ListBox listBox)
        {
            _listBox = listBox;
        }

        public TreeViewController(ListBox listBox, NTree<object> tree)
        {
            _listBox = listBox;
            Tree = tree;
        }


        public void MoveSelectedItemUp()
        {
            object selectedItem = GetSelectedItem();
            Tree!.MoveUp((NTreeNode<object>)selectedItem);
            _listBox.Items.Clear();
            AddNodeList();
            _listBox.SelectedItem = selectedItem;
            _listBox.Focus();
        }

        public void MoveSelectedItemDown()
        {
            object selectedItem = GetSelectedItem();
            Tree!.MoveDown((NTreeNode<object>)selectedItem);
            _listBox.Items.Clear();
            AddNodeList();
            _listBox.SelectedItem = selectedItem;
            _listBox.Focus();
        }

        private int GetSelectedIndex()
        {
            return _listBox.SelectedIndex;
        }

        object GetSelectedItem()
        {
            return _listBox.SelectedItem;
        }

        public void AddChild(NTreeNode<object> parent, NTreeNode<object> child)
        {
            Tree!.AddChild(parent, child);
        }

        // [TODO] Implement custom ObservableCollection<T> to suppress UI refreshes
        // by manually raising NotifyCollectionChangedAction.Reset
        public void AddNodeList(bool skipFirstNode = true)
        {
            foreach (NTreeNode<object> node in Tree!.List)
            {
                if (skipFirstNode)
                {
                    skipFirstNode = false;
                    continue;
                }
                _listBox.Items.Add(node); // UI is refreshed for each Add() call
            }
        }

        public void RemoveItem(object item)
        {
            _listBox.Items.Remove(item); 
        }

        public void ClearItems()
        {
            _listBox.Items.Clear();
        }
    }
}
