// @link Problem definition [[docs/hackerrank/interview_preparation_kit/greedy_algorithms/angry-children.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.greedy_algorithms;

using System.Diagnostics.CodeAnalysis;


/**
 * AngryFlorist.
 *
 */
public static class AngryFlorist
{
  /**
   * maxMin.
   */

  public static int maxMin(int k, List<int> arr)
  {
    List<int> sortedlist = new List<int>(arr);
    sortedlist.Sort();
    int result = sortedlist[sortedlist.Count - 1] - sortedlist[0];

    for (int i = 0; i < sortedlist.Count - k + 1; i++)
    {
      int tmin = sortedlist[i];
      int tmax = sortedlist[i + k - 1];
      result = Math.Min(result, tmax - tmin);
    }

    return result;
  }
}
