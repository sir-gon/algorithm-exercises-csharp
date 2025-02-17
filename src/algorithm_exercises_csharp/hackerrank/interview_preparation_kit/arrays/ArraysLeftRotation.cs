// @link Problem definition [[docs/hackerrank/interview_preparation_kit/arrays/ctci_array_left_rotation.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

using System.Diagnostics.CodeAnalysis;

public class ArraysLeftRotation
{
  [ExcludeFromCodeCoverage]
  protected ArraysLeftRotation() { }

  public const int FIRST_POSITION = 0;

  /**
   * In favor of increasing performance, this implementation mutates the input list.
   */
  public static List<int> rotLeftOne(List<int> input)
  {
    int first = input[FIRST_POSITION];
    input.RemoveAt(FIRST_POSITION);
    input.Add(first);

    return input;
  }

  /**
   * This implementation does not mutate the input list.
   */
  public static List<int> rotLeft(List<int> input, int d)
  {
    // Clone the list
    List<int> output = input.GetRange(FIRST_POSITION, input.Count);

    int i = 1;
    while (i <= d)
    {
      output = rotLeftOne(output);
      i += 1;
    }

    return output;
  }
}
