using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder.Widgets.ListBoxTree
{
    internal class ListBoxTree : Control
    {
        // #####
        // GUI
        Label listBoxTitleLabel = new()
        {
            Location = new Point(81, 3),
            AutoSize = true,
        };
        ListBox listBox = new()
        {
            Location = new Point(81, 21),
            Size = new Size(200, 199),
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

        public ListBoxTree(string listBoxTitle, LinkedList<object> tree)
        {
            Size = new Size(300, 250);
            listBoxTitleLabel.Text = listBoxTitle;
            treeController = new(listBox, tree);

            upButton.Click += upButton_Click;
            downButton.Click += downButton_Click;

            Controls.Add(listBoxTitleLabel);
            Controls.Add(listBox);
            Controls.Add(upButton);
            Controls.Add(downButton);

            DisplayItems([.. tree]);
        }

        void upButton_Click(object? sender, EventArgs e)
        {
            treeController.MoveSelectedItemUp();
        }

        void downButton_Click(object? sender, EventArgs e)
        {
            treeController.MoveSelectedItemDown();
        }

        void DisplayItems(object[] items)
        {
            listBox.Items.AddRange(items);
        }
    }
}
