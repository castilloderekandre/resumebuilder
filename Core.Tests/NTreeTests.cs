using Core.NTreeStuff;

namespace Core.Tests;

public class NTreeTests
{
    [Fact]
    public void AddChild_AfterAddingNode_GetNodeReturnsSameInstance()
    {
        NTree<string> tree = new();
        NTreeNode<string> node = new("Hello World");

        int id = tree.AddChild(0, node);

        NTreeNode<string>? result = tree.GetNode(id);

        Assert.NotNull(result);
        Assert.Same(node, result);
    }

    [Fact]
    public void AddChild_AfterAddingNode_FindNodeReturnsSameInstance()
    {
        NTree<string> tree = new();
        string nodeData = "Hello World";
        NTreeNode<string> node = new(nodeData);

        int id = tree.AddChild(0, node);

        NTreeNode<string>? result = tree.FindNode((strNode) =>
        {
            if (strNode.Data is null)
                return false;

            if (strNode.Data.Equals(nodeData))
                return true;
            return false;
        });

        Assert.NotNull(result);
        Assert.Same(node, result);
    }

    [Fact]
    public void ToList_NTree_ReturnsExpectedOrder()
    {
        NTree<string> tree = new();
        NTreeNode<string> node1 = new("node1");
        NTreeNode<string> node2 = new("node2");
        NTreeNode<string> node3 = new("node3");
        NTreeNode<string> node4 = new("node4");
        NTreeNode<string> node5 = new("node5");
        NTreeNode<string> node6 = new("node6");
        NTreeNode<string> node7 = new("node7");
        NTreeNode<string> node8 = new("node8");

        tree.AddChild(0, node1);
        tree.AddChild(0, node2);

        tree.AddChild(node1, node3);
        tree.AddChild(node1, node4);

        tree.AddChild(node3, node5);

        tree.AddChild(node5, node6);

        tree.AddChild(node2, node7);

        tree.AddChild(node7, node8);

        List<NTreeNode<string>> flatTree = tree.ToList();

        List<NTreeNode<string>> expectedOrder = new()
        {
            tree.GetNode(0)!,
            node1,
            node3,
            node5,
            node6,
            node4,
            node2,
            node7,
            node8
        };

        Assert.Equal(expectedOrder, flatTree);
    }

    [Fact]
    public void ToList_NTree_IndexMapsToExpectedNode()
    {
        NTree<string> tree = new();
        NTreeNode<string> node1 = new("node1");
        NTreeNode<string> node2 = new("node2");
        NTreeNode<string> node3 = new("node3");
        NTreeNode<string> node4 = new("node4");
        NTreeNode<string> node5 = new("node5");
        NTreeNode<string> node6 = new("node6");
        NTreeNode<string> node7 = new("node7");
        NTreeNode<string> node8 = new("node8");

        tree.AddChild(0, node1);
        tree.AddChild(0, node2);

        tree.AddChild(node1, node3);
        tree.AddChild(node1, node4);

        tree.AddChild(node3, node5);

        tree.AddChild(node5, node6);

        tree.AddChild(node2, node7);

        tree.AddChild(node7, node8);

        List<NTreeNode<string>> flatTree = tree.ToList();

        Assert.Same(node4, flatTree[5]);
    }
}
