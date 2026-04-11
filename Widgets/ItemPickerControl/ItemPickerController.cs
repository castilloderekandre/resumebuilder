using ResumeBuilder.Widgets.TreeViewControl;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ResumeBuilder.Widgets.ItemPickerControl
{
    internal class ItemPickerController(TreeViewController sourceTreeController, TreeViewController destinationTreeController)
    {
        TreeViewController _sourceTreeController = sourceTreeController;
        TreeViewController _destinationTreeController = destinationTreeController;
        List<object> _destinationCollection = [];

        void MoveItemIn(object item)
        {
            
        }

        void MoveItemOut(object item)
        {

        }
    }
}
