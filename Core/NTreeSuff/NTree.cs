using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder.NTreeSuff
{
    public class NTree<T>
    {
        NTreeNode<T> root = new();

        public NTree()
        {

        }

        public NTree(List<NTreeNode<T>> list)
        {
            root.Children.AddRange(list);
        }

        public void AddChild(NTreeNode<T> parent, NTreeNode<T> child)
        {
            parent.Children.Add(child);
            child.Parent = parent;
        }

        public void AddRange(NTreeNode<T> parent, List<NTreeNode<T>> list)
        {
            parent.Children.AddRange(list);
        }

        public void ReplaceRange(NTreeNode<T> parent, List<NTreeNode<T>> list)
        {
            parent.Children.Clear();
            parent.Children.AddRange(list);
        }

        public void RemoveNode(NTreeNode<T> nodeToRemove)
        {
            foreach (NTreeNode<T> node in root.Children)
            {
                if (node.Equals(nodeToRemove))
                    node.Parent!.Children.Remove(nodeToRemove);
            }
        }

        public void RemoveNode(NTreeNode<T> parent, NTreeNode<T> node)
        {
            parent.Children.Remove(node);
        }

        public void RemoveNode(Predicate<NTreeNode<T>> predicate)
        {
            foreach(NTreeNode<T> node in root.Children)
            {
                if (predicate(node))
                    node.Parent!.Children.Remove(node);
            }
        }

        public NTreeNode<T>? FindNode(NTreeNode<T> sourceNode, NTreeNode<T> nodeToFind)
        {
            foreach(NTreeNode<T> node in root.Children)
            {
                if (node.Equals(nodeToFind))
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

            foreach(NTreeNode<T> node in root.Children)
                list.Add(node);

            return list;
        }
    }
}
