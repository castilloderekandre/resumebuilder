using System;
using System.Collections.Generic;
using System.Text;

namespace Core.NTreeStuff
{
    public class NTree<T>
    {
        NTreeNode<T> root = new();
        public Dictionary<int, NTreeNode<T>> Dictionary = new();
        int id_tracker = 0;

        public NTree()
        {
            Dictionary.Add(id_tracker++, root);
        }

        public NTree(List<NTreeNode<T>> list)
        {
            root.Children.AddRange(list);
        }

        public int AddChild(int id, T data)
        {
            return AddChild(id, new NTreeNode<T>(data));
        }

        public int AddChild(int id, NTreeNode<T> child)
        {
            if (!Dictionary.TryGetValue(id, out NTreeNode<T>? parent))
                throw new KeyNotFoundException();

            parent.Children.Add(child);

            Dictionary.Add(id_tracker, child);

            return id_tracker++;
        }

        public int AddChild(NTreeNode<T> parent, NTreeNode<T> child)
        {
            parent.Children.Add(child);

            Dictionary.Add(id_tracker, child);

            return id_tracker++;
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

        public NTreeNode<T>? GetNode(int id)
        {
            if (Dictionary.ContainsKey(id))
                return Dictionary[id];

            return null;
        }

        public NTreeNode<T>? FindNode(Predicate<NTreeNode<T>> predicate)
        {
            foreach (NTreeNode<T> node in Traverse(root))
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

        public List<NTreeNode<T>> ToList()
        {
            List<NTreeNode<T>> list = []; 

            foreach(NTreeNode<T> node in Traverse(root))
                list.Add(node);

            return list;
        }
    }
}
