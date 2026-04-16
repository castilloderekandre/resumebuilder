using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder.NTreeSuff
{
    internal class NTree<T>
    {
        public List<NTreeNode<T>> Nodes = new();

        public NTree()
        {

        }

        public NTree(List<NTreeNode<T>> list)
        {
            AddRange(list);
        }

        public void AddFirst(NTreeNode<T> node)
        {
            Nodes.Insert(0, node);
        }

        public void AddLast(NTreeNode<T> node)
        {
            Nodes.Add(node);
        }

        public void AddBefore(int index, NTreeNode<T> node)
        {
            Nodes.Insert(index, node);
        }
        public void AddAfter(int index, NTreeNode<T> node)
        {
            Nodes.Insert(index + 1, node);
        }

        public void InsertNode(int index, NTreeNode<T> node)
        {
            Nodes.Insert(index, node);
        }

        public void AddRange(List<NTreeNode<T>> list)
        {
            Nodes.AddRange(list);
        }

        public void ReplaceRange(List<NTreeNode<T>> list)
        {
            Nodes.Clear();
            Nodes.AddRange(list);
        }

        public void RemoveNode(NTreeNode<T> node)
        {

        }

        public NTreeNode<T>? FindNode(NTreeNode<T> sourceNode, T dataToFind, Predicate<NTreeNode<T>> predicate)
        {
            foreach(NTreeNode<T> node in Nodes)
            {
                if (predicate(node))
                    return node;
            }

            return null;
        }
        IEnumerable<NTreeNode<T>> Traverse(NTreeNode<T> node)
        {
            yield return node;

            foreach (NTreeNode<T> child in node.Children)
            {
                foreach (NTreeNode<T> descendant in Traverse(child))
                    yield return descendant;
            }
        }

        public List<object> ToList()
        {
            List<object> list = []; 

            foreach(NTreeNode<T> node in Nodes)
                list.Add(node);

            return list;
        }
    }
}
