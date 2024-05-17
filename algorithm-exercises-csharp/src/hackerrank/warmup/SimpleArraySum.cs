// @link Problem definition [[docs/hackerrank/warmup/simple_array_sum.md]]

namespace algorithm_exercises_csharp;

using System.Diagnostics.CodeAnalysis;

public class SimpleArraySum
{
  [ExcludeFromCodeCoverage]
  protected SimpleArraySum() { }

  public static int simpleArraySum(int[] inputs)
  {
    var total = 0;

    foreach (int i in inputs)
    {
      total += i;
    }

    return total;
  }
}
