using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ListExtensions
    {
        extension<T>(List<T> list)
        {
            public void MoveItemUp(int index)
            {
                if (index - 1 < 0)
                    throw new IndexOutOfRangeException();

                T auxiliary = list[index - 1];
                list[index - 1] = list[index];
                list[index] = auxiliary;
            }
            public void MoveItemDown(int index)
            {
                if (index >= list.Count)
                    throw new IndexOutOfRangeException();

                T auxiliary = list[index + 1];
                list[index + 1] = list[index];
                list[index] = auxiliary;
            }
        }
    }
}
