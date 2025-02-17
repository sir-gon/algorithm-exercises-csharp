// @link Problem definition [[docs/hackerrank/interview_preparation_kit/arrays/crush.md]]
// @link Solution notes [[docs/hackerrank/interview_preparation_kit/arrays/crush_optimized-solution-notes.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

using System.Diagnostics.CodeAnalysis;

public class CrushBruteForce
{
  [ExcludeFromCodeCoverage]
  protected CrushBruteForce() { }

  private const int INITIALIZER = 0;

  public static long arrayManipulation(int n, List<List<int>> queries)
  {
    // why adding 1?
    //   first slot to adjust 1-based index and
    int[] result = new int[n + 1];
    Array.Fill(result, INITIALIZER);
    int maximum = INITIALIZER;

    foreach (List<int> query in queries)
    {
      int start = query[0];
      int end = query[1];
      int value = query[2];

      for (int i = start; i < end + 1; i++)
      {
        result[i] += value;
      }

      foreach (int current in result)
      {
        maximum = Math.Max(current, maximum);
      }
    }

    return maximum;
  }
}
