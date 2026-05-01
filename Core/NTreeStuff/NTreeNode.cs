using System;
using System.Collections.Generic;
using System.Text;

namespace Core.NTreeStuff
{
    public class NTreeNode<T>
    {
        public NTreeNode<T>? Parent;
        public T? Data;
        public List<NTreeNode<T>> Children = new();

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
