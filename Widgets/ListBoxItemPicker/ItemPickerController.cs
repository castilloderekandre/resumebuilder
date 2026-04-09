using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ResumeBuilder.Widgets.ListBoxItemPicker
{
    internal class ItemPickerController(TreeController sourceTreeController, TreeController destinationTreeController)
    {
        TreeController _sourceTreeController = sourceTreeController;
        TreeController _destinationTreeController = destinationTreeController;
        List<object> _destinationCollection = [];

        void MoveItemIn(object item)
        {
            
        }

        void MoveItemOut(object item)
        {

        }
    }
}
