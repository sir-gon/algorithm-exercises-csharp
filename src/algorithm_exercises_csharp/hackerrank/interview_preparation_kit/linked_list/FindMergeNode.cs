// @link Problem definition [[docs/hackerrank/interview_preparation_kit/linked_lists/find-the-merge-point-of-two-joined-linked-lists.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.linked_list;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.linked_list.common;

using System.Diagnostics.CodeAnalysis;

public static class FindMergeNode
{
  public static int? findMergeNode(LinkedList<int>.Node head1, LinkedList<int>.Node head2)
  {
    List<LinkedList<int>.Node> llindex = [];
    LinkedList<int>.Node? node = head1;
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
