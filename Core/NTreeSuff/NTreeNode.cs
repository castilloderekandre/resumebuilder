using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder.NTreeSuff
{
    public class NTreeNode<T>
    {
        public NTreeNode<T>? Parent;
        public T? Data;
        public List<NTreeNode<T>> Children = new();

        public NTreeNode()
        {

        }

        public NTreeNode(NTreeNode<T> parent)
        {
            Parent = parent;
        }
    }
}
