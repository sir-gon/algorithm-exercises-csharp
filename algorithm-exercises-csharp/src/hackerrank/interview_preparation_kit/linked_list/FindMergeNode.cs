// @link Problem definition [[docs/hackerrank/interview_preparation_kit/linked_lists/find-the-merge-point-of-two-joined-linked-lists.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit;

using System.Diagnostics.CodeAnalysis;

public class FindMergeNode
{
  [ExcludeFromCodeCoverage]
  protected FindMergeNode() { }

  public static int? findMergeNode(LinkedList.Node head1, LinkedList.Node head2)
  {
    List<LinkedList.Node> llindex = [];
    LinkedList.Node? node = head1;
    int? result = null;

    while (node != null)
    {
      llindex.Add(node);
      node = node.next;
    }

    node = head2;
    bool resume = true;
    while (node != null && resume)
    {
      if (llindex.Contains(node))
      {
        result = node.data;
        resume = false;
      }
      llindex.Add(node);
      node = node.next;
    }

    return result;
  }
}
