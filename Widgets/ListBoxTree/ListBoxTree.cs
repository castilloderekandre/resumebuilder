using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder.Widgets.ListBoxTree
{
    internal class ListBoxTree
    {
        // #####
        // GUI
        Label listBoxTitleLabel = new()
        {
            Location = new Point(120, 3),
        };
        ListBox listBox = new()
        {
            Location = new Point(120, 21),
            Size = new Size(120, 199),
        };
        Button upButton = new()
        {
            Text = "Move Up",
            Location = new Point(3, 21),
            Size = new Size(75, 23),
        };
        Button downButton = new()
        {
            Text = "Move Down",
            Location = new Point(3, 47),
            Size = new Size(75, 23),
        };
        // ###

        TreeController treeController;

        private ListBoxTree(string listBoxTitle, LinkedList<object> tree)
        {
            listBoxTitleLabel.Text = listBoxTitle;
            treeController = new(listBox, tree);

            upButton.Click += upButton_Click;
            downButton.Click += downButton_Click;
        }

        void upButton_Click(object? sender, EventArgs e)
        {
            treeController.MoveSelectedItemUp();
        }

        void downButton_Click(object? sender, EventArgs e)
        {
            treeController.MoveSelectedItemDown();
        }
    }
}
