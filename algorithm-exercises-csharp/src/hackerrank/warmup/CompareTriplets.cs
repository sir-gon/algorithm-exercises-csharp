// @link Problem definition [[docs/hackerrank/warmup/compare_triplets.md]]

namespace algorithm_exercises_csharp.hackerrank;

using System.Diagnostics.CodeAnalysis;

public class CompareTriplets
{
  [ExcludeFromCodeCoverage]
  protected CompareTriplets() { }

  public static List<int> compareTriplets(List<int> _a, List<int> _b)
  {
    List<int> awards = [0, 0];

    for (int i = 0; i < _a.Count; i++)
    {
      if (_a[i] > _b[i])
      {
        awards[0] = awards[0] + 1;
      }
      if (_a[i] < _b[i])
      {
        awards[1] = awards[1] + 1;
      }
    }

    return awards;
  }
}
