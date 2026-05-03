using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ListExtensions
    {
        extension<T>(List<T> list)
        {
            public int MoveItemUp(int index)
            {
                if (index - 1 <= 0)
                    return index;
                    // throw new IndexOutOfRangeException();

                T auxiliary = list[index - 1];
                list[index - 1] = list[index];
                list[index] = auxiliary;

                return index - 1;
            }
            public int MoveItemDown(int index)
            {
                if (index + 1 >= list.Count)
                    return index;
                    // throw new IndexOutOfRangeException();

                T auxiliary = list[index + 1];
                list[index + 1] = list[index];
                list[index] = auxiliary;

                return index + 1;
            }
        }
    }
}
