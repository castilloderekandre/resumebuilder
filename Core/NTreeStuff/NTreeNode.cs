using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.NTreeStuff
{
    // Implement FindIndex with finding object reference predicate
    public class NTreeNode<T>
    {
        public NTreeNode<T>? Parent = null;
        public T? Data = default;
        public List<NTreeNode<T>> Children = new();
        public int Level = 0;

        public NTreeNode()
        {

        }

        public NTreeNode(T data)
        {
            Data = data;
        }

        public NTreeNode(NTreeNode<T> parent)
        {
            Parent = parent;
        }

        // [TODO] Move item in NTree class List variable as well

        public override string? ToString()
        {
            if (Data is null)
                return null;

            return Data.ToString();
        }
    }
}
