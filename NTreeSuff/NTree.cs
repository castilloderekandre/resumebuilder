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

        public NTreeNode<T>? FindNode(NTreeNode<T> sourceNode, T dataToFind, Predicate<object> predicate)
        {
            if (sourceNode.Data is not null)
            {
                if (predicate(sourceNode.Data))
                    return sourceNode;
            }

            if (sourceNode.Children is null)
                return null;

            foreach(NTreeNode<T> node in sourceNode.Children)
            {
                if (node.Children is not null)
                {
                    NTreeNode<T>? result = FindNode(node, dataToFind, predicate);
                    if (result is not null)
                        return result;
                }
            }

            return null;
        }
    }
}
