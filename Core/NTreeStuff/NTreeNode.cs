using System;
using System.Collections.Generic;
using System.Text;

namespace Core.NTreeStuff
{
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
    }
}
