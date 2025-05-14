namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.linked_list.lib;

public static class LinkedListPrinter
{
  public static void printSinglyLinkedList<T>(LinkedList<T>.Node? node, string sep, TextWriter textWriter)
  {
    ArgumentNullException.ThrowIfNull(textWriter);

    var pointTo = node;

    while (pointTo != null)
    {
      textWriter.Write(pointTo.data);

      pointTo = pointTo.next;

      if (pointTo != null)
      {
        textWriter.Write(sep);
      }
    }
  }
}
