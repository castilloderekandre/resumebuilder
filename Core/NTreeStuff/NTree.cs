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

        public NTree(NTreeNode<T> rootNode)
        {
            root = rootNode;
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

            return AddChild(parent, child);
        }

        public int AddChild(NTreeNode<T> parent, NTreeNode<T> child)
        {
            child.Parent = parent;
            parent.Children.Add(child);

            AssignLevel(parent);

            Dictionary.Add(id_tracker, child);

            return id_tracker++;
        }

        void AssignLevel(NTreeNode<T> root)
        {
            NTreeNode<T>? previousNode = null;
            foreach (NTreeNode<T> node in TraverseBFS(root))
            {
                if (previousNode is null) 
                { 
                    node.Level = root.Level + 1;
                    previousNode = node;
                    continue;
                }
                else if (previousNode.Parent == node.Parent)
                {
                    node.Level = previousNode.Level;
                    continue;
                }
                else if (previousNode.Parent != node.Parent)
                    node.Level = previousNode.Level + 1;

                previousNode = node;
            }
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
            foreach(NTreeNode<T> node in TraverseDFS(root))
            {
                if (predicate(node))
                    return node;
            }

            return null;
        }

        IEnumerable<NTreeNode<T>> TraverseDFS(NTreeNode<T> root)
        {
            Stack<NTreeNode<T>> stack = new();
            stack.Push(root);

            while (stack.Count > 0)
            {
                NTreeNode<T> node = stack.Pop();
                yield return node;

                for (int i = node.Children.Count - 1; i >= 0; i--)
                {
                    stack.Push(node.Children[i]);
                }
            }
        }

        IEnumerable<NTreeNode<T>> TraverseBFS(NTreeNode<T> root)
        {
            Queue<NTreeNode<T>> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                NTreeNode<T> node = queue.Dequeue();
                yield return node;

                foreach (NTreeNode<T> child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public void ForEach(Action<NTreeNode<T>> action)
        {
            foreach(NTreeNode<T> node in TraverseDFS(root))
            {
                action(node);
            }
        }

        public List<NTreeNode<T>> ToList()
        {
            List<NTreeNode<T>> list = []; 

            foreach(NTreeNode<T> node in TraverseDFS(root))
                list.Add(node);

            return list;
        }
    }
}
