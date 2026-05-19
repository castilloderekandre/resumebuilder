using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Core.NTreeStuff
{
    public class NTree<T>
    {
        NTreeNode<T> root = new();
        HashSet<NTreeNode<T>> nodes = new();
        public List<NTreeNode<T>> List { get; } = new();

        public NTree()
        {
            nodes.Add(root);
            List.Add(root);
        }

        public NTree(NTreeNode<T> rootNode)
        {
            root = rootNode;
            nodes.Add(root);
            List.Add(root);
        }

        public NTree(List<NTreeNode<T>> list)
        {
            root.Children.AddRange(list);
        }

        public int AddChild(NTreeNode<T> parent, NTreeNode<T> child)
        {
            if (!nodes.Contains(parent))
                throw new ArgumentException("Parent does not exist in tree");

            child.Parent = parent;
            parent.Children.Add(child);
            nodes.Add(child);

            AssignLevel(parent);

            int index = List.FindIndex(node => Object.ReferenceEquals(parent, node)) + parent.Children.Count;
            if (index > List.Count)
                List.Add(child);
            else
                List.Insert(index, child);

            return index;
        }

        void AssignLevel(NTreeNode<T> root)
        {
            NTreeNode<T>? previousNode = null;
            foreach (NTreeNode<T> node in TraverseBFS(root))
            {
                if (previousNode is null) 
                { 
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
    }
}
