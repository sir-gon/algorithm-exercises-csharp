// @link Problem definition [[docs/hackerrank/warmup/a_very_big_sum.md]]

namespace algorithm_exercises_csharp.hackerrank;

using System.Diagnostics.CodeAnalysis;

public class AVeryBigSum
{
  [ExcludeFromCodeCoverage]
  protected AVeryBigSum() { }

  public static long aVeryBigSum(List<long> _ar)
  {
    var total = 0L;

    foreach (long x in _ar)
    {
      total += x;
    }

    return total;
  }
}
