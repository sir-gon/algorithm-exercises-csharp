// @link Problem definition [[docs/hackerrank/interview_preparation_kit/greedy_algorithms/greedy-florist.md]]
// @link Solution notes [[docs/hackerrank/interview_preparation_kit/greedy_algorithms/greedy-florist-solution-notes.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.greedy_algorithms;

using System.Diagnostics.CodeAnalysis;


/**
 * GreedyFlorist.
 *
 */
public static class GreedyFlorist
{
  /**
   * getMinimumCost.
   */

  public static int getMinimumCost(int k, int[] c)
  {
    List<int> flowers = new List<int>(c);
    flowers.Sort();
    flowers.Reverse();

    int totalCost = 0;
    int i = 0;

    foreach (var flowerCost in flowers)
    {
      int position = i / k;
      totalCost += (position + 1) * flowerCost;

      i += 1;
    }

    return totalCost;
  }
}
