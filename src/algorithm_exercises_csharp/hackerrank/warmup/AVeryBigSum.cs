// @link Problem definition [[docs/hackerrank/warmup/a_very_big_sum.md]]

namespace algorithm_exercises_csharp.hackerrank.warmup;

public static class AVeryBigSum
{
  public static long aVeryBigSum(List<long> ar)
  {
    ArgumentNullException.ThrowIfNull(ar);

    var total = 0L;

    foreach (long x in ar)
    {
      total += x;
    }

    return total;
  }
}
