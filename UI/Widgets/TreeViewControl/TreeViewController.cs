using ResumeBuilder.Core.NTreeSuff;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace ResumeBuilder.UI.Widgets.TreeViewControl
{
    internal class TreeViewController
    {
        ListBox _listBox;
        NTree<object> _tree;
        List<object> _flatTree;

        private TreeViewController(ListBox listBox, NTree<object> tree)
        {
            _listBox = listBox;
            _tree = tree;

            _flatTree = _tree.ToList();
            AddRange(_flatTree);
        }

        //public Resume? Resume { 
        //    get;
        //    set
        //    {
        //        ArgumentNullException.ThrowIfNull(value);
        //        field = value;


        //    }
        //} = resume;

        //void DisplayResume(Resume resume)
        //{
        //    string[] resumeStructure = FlattenByTitle(resume);
        //    DisplayText(resumeStructure);
        //}

        ///*  [TODO] Place method in Resume class. Make all implement FlattenByTitle...?
        // * 
        // */
        //string[] FlattenByTitle(Resume resume)
        //{
        //    List<string> flattenedItems = [];
        //    string tree_level = "";
        //    //string[] strings = [];
        //    foreach (Section section in resume.Sections)
        //    {
        //        flattenedItems.Add(section.Title);

        //        tree_level = "\t";
        //        foreach (Entry entry in section.Entries)
        //        {
        //            flattenedItems.Add($"{tree_level}entry.Title");
        //            //strings = [.. strings, section.Title, entry.Title];
        //        }
        //        tree_level = "";
        //    }


        //    return [.. flattenedItems];
        //}

        void DisplayText(object[] items)
        {
            _listBox.Items.Clear();
            _listBox.Items.AddRange(items);
        }

        void FormatText()
        {
            
        }

        public void MoveSelectedItemUp()
        {
            MoveSelectedItemUpInListBox();
        }

        public void MoveSelectedItemDown()
        {
            MoveSelectedItemDownInListBox();
        }

        private void MoveSelectedItemUpInListBox()
        {
            int index = _listBox.SelectedIndex;
            object? item = _listBox.SelectedItem;

            if (item is null)
                return;

            //When an item is removed is it disposed too or left for garbage collection?
            _listBox.Items.RemoveAt(index);

            index = --index < 0 ? 
                _listBox.Items.Count : index;
            _listBox.Items.Insert(index, item);
            _listBox.SelectedItem = item;
        }

        private void MoveSelectedItemDownInListBox()
        {

            int index = _listBox.SelectedIndex;
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

        public void AddItem(object item)
        {
            _listBox.Items.Add(item);
        }

        public void AddRange(params object[] items)
        {
            _listBox.Items.AddRange(items);
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
