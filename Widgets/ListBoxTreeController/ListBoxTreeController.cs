using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace ResumeBuilder.Widgets
{
    internal class ListBoxTreeController(ListBox listBox, List<int> order, Resume resume)
    {
        ListBox _listBox = listBox;
        List<int> _order = order;
        public Resume? Resume { 
            get;
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                field = value;


            }
        } = resume;

        void DisplayResume(Resume resume)
        {
            string[] resumeStructure = FlattenByTitle(resume);
            DisplayText(resumeStructure);
        }

        /*  [TODO] Place method in Resume class. Make all implement FlattenByTitle...?
         * 
         */
        string[] FlattenByTitle(Resume resume)
        {
            List<string> flattenedItems = [];
            string tree_level = "";
            //string[] strings = [];
            foreach (Section section in resume.Sections)
            {
                flattenedItems.Add(section.Title);

                tree_level = "\t";
                foreach (Entry entry in section.Entries)
                {
                    flattenedItems.Add($"{tree_level}entry.Title");
                    //strings = [.. strings, section.Title, entry.Title];
                }
                tree_level = "";
            }


            return [.. flattenedItems];
        }

        void DisplayText(object[] items)
        {
            _listBox.Items.Clear();
            _listBox.Items.AddRange(items);
        }

        void FormatText()
        {
            
        }

        void MoveItemUp(object item)
        {
           
        }

        void MoveItemDown(object item)
        {

        }

        void AddItem(object item)
        {

        }

        void RemoveItem(object item)
        {
            
        }
    }
}
