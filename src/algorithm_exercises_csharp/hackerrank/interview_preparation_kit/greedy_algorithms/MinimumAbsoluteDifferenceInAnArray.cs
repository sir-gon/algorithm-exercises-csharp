// @link Problem definition [[docs/hackerrank/interview_preparation_kit/greedy_algorithms/minimum-absolute-difference-in-an-array.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.greedy_algorithms;

using System.Diagnostics.CodeAnalysis;

public static class MinimumAbsoluteDifferenceInAnArray
{

  /**
   * minimumAbsoluteDifference.
   */
  public static int minimumAbsoluteDifference(List<int> arr)
  {
    ArgumentNullException.ThrowIfNull(arr);

    List<int> sortedNums = [.. arr.ConvertAll(x => x).OrderBy(x => x).ToList()];

    // Find the minimum absolute difference
    int result = 0;
    bool resultEmpty = true;

    for (int i = 0; i < sortedNums.Count - 1; i++)
    {
      int aValue = sortedNums[i];
      int bValue = sortedNums[i + 1];

      int diff = Math.Abs(aValue - bValue);

      if (resultEmpty)
      {
        result = diff;
        resultEmpty = false;
      }
      else
      {
        result = Math.Min(result, diff);
      }
    }

    return result;
  }
}
