// @link Problem definition [[docs/hackerrank/warmup/simple_array_sum.md]]

namespace algorithm_exercises_csharp.hackerrank.warmup;

using System.Diagnostics.CodeAnalysis;

public static class SimpleArraySum
{
  public static int simpleArraySum(List<int> ar)
  {
    ArgumentNullException.ThrowIfNull(ar);

    var total = 0;

    foreach (int i in ar)
    {
      total += i;
    }

    return total;
  }
}
