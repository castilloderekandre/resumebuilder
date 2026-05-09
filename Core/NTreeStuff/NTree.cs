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

            child.Parent = parent;
            parent.Children.Add(child);

            Dictionary.Add(id_tracker, child);

            return id_tracker++;
        }

        public int AddChild(NTreeNode<T> parent, NTreeNode<T> child)
        {
            child.Parent = parent;
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

        public void RemoveNode(NTreeNode<T> node)
        {
            if (node.Parent is null)
                return;

            node.Parent.Children.Remove(node);
        }

        public void RemoveNodesWhere(Predicate<NTreeNode<T>> predicate)
        {
            ForEach((node) =>
            {
                if (predicate(node))
                    node.Parent!.Children.Remove(node);
            });
        }

        public NTreeNode<T>? GetNode(int id)
        {
            if (Dictionary.TryGetValue(id, out NTreeNode<T>? node))
                return node;

            return null;
        }

        public NTreeNode<T>? FindNode(Predicate<NTreeNode<T>> predicate)
        {
            foreach(NTreeNode<T> node in Traverse(root))
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

        public void ForEach(Action<NTreeNode<T>> action)
        {
            foreach(NTreeNode<T> node in Traverse(root))
            {
                action(node);
            }
        }

        public List<NTreeNode<T>> ToList()
        {
            List<NTreeNode<T>> list = []; 

            foreach(NTreeNode<T> node in Traverse(root))
                list.Add(node);

            return list;
        }

        public List<T> DataToList()
        {
            List<T> list = [];

            foreach(NTreeNode<T> node in Traverse(root))
            {
                if (node.Data is not null)
                list.Add(node.Data);
            }

            return list;
        }
    }
}
