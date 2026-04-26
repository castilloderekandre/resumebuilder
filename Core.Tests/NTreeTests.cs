using ResumeBuilder.NTreeSuff;

namespace Core.Tests;

public class NTreeTests
{
    [Fact]
    public void AddNode_ValidNode_NodeIsAddedToTree()
    {
        NTree<string> tree = new();
        NTreeNode<string> node = new("Hello World");

        int id = tree.AddChild(0, node);

        NTreeNode<string>? result = tree.GetNode(id);

        Assert.NotNull(result);
        Assert.Equal(node.Data, result.Data);
    }
}
