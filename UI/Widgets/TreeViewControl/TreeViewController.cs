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
        NTree<object> _tree;
        List<NTreeNode<object>> _list;

        public TreeViewController(ListBox listBox, NTree<object> tree)
        {
            _listBox = listBox;
            _tree = tree;

            _list = _tree.List;
            AddNodeList();
        }


        public void MoveSelectedItemUp()
        {
            object selectedItem = GetSelectedItem();
            _tree.MoveUp((NTreeNode<object>)selectedItem);
            _listBox.Items.Clear();
            AddNodeList();
            _listBox.SelectedItem = selectedItem;
            _listBox.Focus();
        }

        public void MoveSelectedItemDown()
        {
            object selectedItem = GetSelectedItem();
            _tree.MoveDown((NTreeNode<object>)selectedItem);
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

        public void AddItem(object item)
        {
            _listBox.Items.Add(item);
        }

        // [TODO] Implement custom ObservableCollection<T> to suppress UI refreshes
        // by manually raising NotifyCollectionChangedAction.Reset
        public void AddNodeList(bool skipFirstNode = true)
        {
            foreach (NTreeNode<object> node in _list)
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
