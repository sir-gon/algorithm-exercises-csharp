// @link Problem definition [[docs/hackerrank/interview_preparation_kit/linked_lists/ctci_linked_list_cycle.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.linked_list;

using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.linked_list.common;

using System.Diagnostics.CodeAnalysis;

public static class LinkedListCycle
{
  public static bool hasCycle<T>(LinkedList<T>.Node? head)
  {
    List<LinkedList<T>.Node> llindex = [];

    LinkedList<T>.Node? node = head;

    while (node != null)
    {
      if (llindex.Contains(node))
      {
        return true;
      }

      llindex.Add(node);
      node = node.next;
    }

    return false;
  }
}
