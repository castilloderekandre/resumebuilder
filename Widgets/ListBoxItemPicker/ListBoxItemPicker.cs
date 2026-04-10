using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder.Widgets.ListBoxItemPicker
{
    internal class ListBoxItemPicker() : Panel
    {
        Resume? _resume;
        ListBox sourceListBox;
        ListBox destinationListBox;
        Button moveInButton;
        Button moveOutButton;
        Button moveUpButton;
        Button moveDownButton;

        public ListBoxItemPicker(Resume? resume) : this()
        {
            _resume = resume;
            sourceListBox = new ListBox();
            destinationListBox = new ListBox();
            moveInButton = new Button();
            moveOutButton = new Button();
            moveUpButton = new Button();
            moveDownButton = new Button();

            // GUI creation goes here...
        }
    }
}
