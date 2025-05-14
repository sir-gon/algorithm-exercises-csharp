namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.linked_list.common;

public static class LinkedList<T>
{
  public class Node(T nodeData)
  {
    public T data { get; set; } = nodeData;
    public Node? next { get; set; } = default!;
  }
}
