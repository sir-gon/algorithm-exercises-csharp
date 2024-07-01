// @link Problem definition [[docs/hackerrank/interview_preparation_kit/linked_lists/ctci_linked_list_cycle.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit;

using System.Diagnostics.CodeAnalysis;

public class LinkedListCycle
{
  [ExcludeFromCodeCoverage]
  protected LinkedListCycle() { }

  public static bool hasCycle(LinkedList<int>.Node? head)
  {
    List<LinkedList<int>.Node> llindex = [];

    LinkedList<int>.Node? node = head;

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
