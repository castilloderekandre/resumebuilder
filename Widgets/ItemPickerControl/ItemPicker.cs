using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder.Widgets.ItemPickerControl
{
    internal class ItemPicker : Control
    {
        TreeView receivingTreeView = new TreeView()
        {

        };
        TreeView sourceTreeView = new TreeView()
        {

        };

        Button moveInButton = new Button()
        {

        };
        Button moveOutButton = new Button()
        {

        };
        Button moveUpButton = new Button()
        {

        };
        Button moveDownButton = new Button()
        {

        };

        public ItemPicker(LinkedList<object> tree)
        {

        }
    }
}
