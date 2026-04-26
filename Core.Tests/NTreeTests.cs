using ResumeBuilder.NTreeSuff;

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
}
