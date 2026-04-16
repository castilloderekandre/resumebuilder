using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder.NTreeSuff
{
    internal class NTreeNode<T>
    {
        public NTreeNode<T>? Parent;
        public T? Data;
        public List<NTreeNode<T>>? Children;

        public NTreeNode()
        {

        }
    }
}
