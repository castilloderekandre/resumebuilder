using Core.NTreeStuff;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

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

        extension<T>(List<NTreeNode<T>> list)
        {
            public int MoveItemUp(int index)
            {
                if (index - 1 <= 0)
                    return index;

                NTreeNode<T> previousNode = list[index - 1];
                NTreeNode<T> node = list[index];
                if (previousNode.Parent is null || node.Parent is null || previousNode.Parent != node.Parent)
                    return index;

                list[index - 1] = node;
                list[index] = previousNode;

                return index - 1;
            }
            public int MoveItemDown(int index)
            {
                if (index + 1 >= list.Count)
                    return index;

                NTreeNode<T> nextNode = list[index + 1];
                NTreeNode<T> node = list[index];
                if (nextNode.Parent is null || node.Parent is null || nextNode.Parent != node.Parent)
                    return index;

                list[index + 1] = node;
                list[index] = nextNode;

                return index + 1;
            }
        }
    }
}
