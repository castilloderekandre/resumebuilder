using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ResumeBuilder.Widgets.ListBoxItemPicker
{
    internal class ItemPickerController(ListBoxTreeController sourceTreeController, ListBoxTreeController destinationTreeController)
    {
        ListBoxTreeController _sourceTreeController = sourceTreeController;
        ListBoxTreeController _destinationTreeController = destinationTreeController;
        List<object> _destinationCollection = [];

        void MoveItemIn(object item)
        {
            
        }

        void MoveItemOut(object item)
        {

        }
    }
}
