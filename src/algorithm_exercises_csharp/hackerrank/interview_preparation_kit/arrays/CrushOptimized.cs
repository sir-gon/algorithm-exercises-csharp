// @link Problem definition [[docs/hackerrank/interview_preparation_kit/arrays/crush.md]]
// @link Solution notes [[docs/hackerrank/interview_preparation_kit/arrays/crush_optimized-solution-notes.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

using System.Diagnostics.CodeAnalysis;

public static class CrushOptimized
{

  /**
  // arrayManipulation.
   */
  public static long arrayManipulation(int n, List<List<int>> queries)
  {
    ArgumentNullException.ThrowIfNull(queries);

    // why adding 2?
    //   first slot to adjust 1-based index and
    //   last slot for storing accumSum result
    int[] result = new int[n + 2];
    Array.Fill(result, 0);
    int maximum = 0;

    foreach (List<int> query in queries)
    {
      int a = query[0];
      int b = query[1];
      int k = query[2];

      // Prefix
      result[a] += k;
      result[b + 1] -= k;

      int accumSum = 0;
      foreach (int value in result)
      {
        accumSum += value;
        maximum = Math.Max(maximum, accumSum);
      }
    }

    return maximum;
  }
}
