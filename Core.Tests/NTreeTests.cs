using Core.Extensions;
using Core.NTreeStuff;
using System.Diagnostics;

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

    [Fact]
    public void MoveItemUp_ListOfNTreeNodes_NodesStayWithinParentBoundaries()
    {
        NTree<string> tree = new();
        NTreeNode<string> node1 = new("(node1) child 1 of root");
        NTreeNode<string> node2 = new("(node2) child 2 of root");
        NTreeNode<string> node3 = new("(node3) child 1 of 1");
        NTreeNode<string> node4 = new("(node4) child 2 of 1");
        NTreeNode<string> node5 = new("(node5) child 1 of 3");
        NTreeNode<string> node6 = new("(node6) child 1 of 5");
        NTreeNode<string> node7 = new("(node7) child 1 of 2");
        NTreeNode<string> node8 = new("(node8) child 1 of 7");

        tree.AddChild(0, node1);
        tree.AddChild(0, node2);

        tree.AddChild(node1, node3);
        tree.AddChild(node1, node4);

        tree.AddChild(node3, node5);

        tree.AddChild(node5, node6);

        tree.AddChild(node2, node7);

        tree.AddChild(node7, node8);

        List<NTreeNode<string>> flatTree = tree.ToList();

        foreach(string value in tree.DataToList())
            Debug.WriteLine(value);

        int index = flatTree.MoveItemUp(2);

        Assert.True(index == 2);
        Assert.Same(node3, flatTree[2]);
    }

    [Fact]
    public void MoveItemDown_ListOfNTreeNodes_NodesStayWithinParentBoundaries()
    {
        NTree<string> tree = new();
        NTreeNode<string> node1 = new("(node1) child 1 of root");
        NTreeNode<string> node2 = new("(node2) child 2 of root");
        NTreeNode<string> node3 = new("(node3) child 1 of 1");
        NTreeNode<string> node4 = new("(node4) child 2 of 1");
        NTreeNode<string> node5 = new("(node5) child 1 of 3");
        NTreeNode<string> node6 = new("(node6) child 1 of 5");
        NTreeNode<string> node7 = new("(node7) child 1 of 2");
        NTreeNode<string> node8 = new("(node8) child 1 of 7");

        tree.AddChild(0, node1);
        tree.AddChild(0, node2);

        tree.AddChild(node1, node3);
        tree.AddChild(node1, node4);

        tree.AddChild(node3, node5);

        tree.AddChild(node5, node6);

        tree.AddChild(node2, node7);

        tree.AddChild(node2, node8);

        List<NTreeNode<string>> flatTree = tree.ToList();

        foreach(string value in tree.DataToList())
            Debug.WriteLine(value);

        int index = flatTree.MoveItemDown(7);

        Assert.True(index == 8);
        Assert.Same(node7, flatTree[8]);
    }

     [Fact]
    public void Level_NTreeNode_LevelValueIsCorrect()
    {
        NTreeNode<string> root = new NTreeNode<string>("root");
        NTree<string> tree = new(root);
        NTreeNode<string> node1 = new("node1");
        NTreeNode<string> node2 = new("node2");
        NTreeNode<string> node3 = new("node3");
        NTreeNode<string> node4 = new("node4");
        NTreeNode<string> node5 = new("node5");
        NTreeNode<string> node6 = new("node6");
        NTreeNode<string> node7 = new("node7");
        NTreeNode<string> node8 = new("node8");

        tree.AddChild(root, node1);
        tree.AddChild(root, node2);

        tree.AddChild(node1, node3);
        tree.AddChild(node1, node4);

        tree.AddChild(node3, node5);

        tree.AddChild(node5, node6);

        tree.AddChild(node2, node7);

        tree.AddChild(node7, node8);

        List<NTreeNode<string>> flatTree = tree.ToList();

        foreach (NTreeNode<string> node in flatTree)
        {
            Debug.WriteLine(node.Data);
            Debug.WriteLine(node.Level);
        }

        Assert.Equal(0, root.Level);
        Assert.Equal(1, node1.Level);
        Assert.Equal(1, node2.Level);
        Assert.Equal(2, node3.Level);
        Assert.Equal(2, node4.Level);
        Assert.Equal(3, node5.Level);
        Assert.Equal(4, node6.Level);
        Assert.Equal(2, node7.Level);
        Assert.Equal(3, node8.Level);
    }
}

