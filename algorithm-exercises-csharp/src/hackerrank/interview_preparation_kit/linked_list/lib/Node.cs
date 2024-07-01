namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit;

public class LinkedList<T>
{
  public class Node(T nodeData)
  {
    public T data { get; set; } = nodeData;
    public Node? next { get; set; } = null;
  }

  public static void printSinglyLinkedList(Node? node, string sep, TextWriter textWriter)
  {
    Node? pointTo = node;

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
