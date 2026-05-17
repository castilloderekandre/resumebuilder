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
            int index = GetSelectedIndex();
            index = _flatTree.MoveItemUp(index);
            _listBox.Items.Clear();
            AddRange(_flatTree);
            _listBox.SelectedIndex = index;
            _listBox.Focus();
            // MoveSelectedItemUpInListBox();
        }

        public void MoveSelectedItemDown()
        {
            int index = GetSelectedIndex();
            index = _flatTree.MoveItemDown(GetSelectedIndex());
            _listBox.Items.Clear();
            AddRange(_flatTree);
            _listBox.SelectedIndex = index;
            _listBox.Focus();
            // MoveSelectedItemDownInListBox();
        }

        private void MoveSelectedItemUpInListBox()
        {
            int index = GetSelectedIndex();
            object? item = _listBox.SelectedItem;

            if (item is null)
                return;

            _listBox.Items.RemoveAt(index);

            index = --index < 0 ? 
                _listBox.Items.Count : index;
            _listBox.Items.Insert(index, item);
            _listBox.SelectedItem = item;
        }

        private void MoveSelectedItemDownInListBox()
        {

            int index = GetSelectedIndex();
            object? item = _listBox.SelectedItem;

            if (item is null)
                return;

            _listBox.Items.RemoveAt(index);

            index = ++index >= _listBox.Items.Count + 1 ? 
                0 : index;
            _listBox.Items.Insert(index, item);
            _listBox.SelectedItem = item;
        }

        private int GetSelectedIndex()
        {
            return _listBox.SelectedIndex;
        }

        public void AddItem<T>(NTreeNode<T> item)
        {
            _listBox.Items.Add(item.Data);
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
