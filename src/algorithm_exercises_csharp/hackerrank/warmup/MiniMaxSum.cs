// @link Problem definition [[docs/hackerrank/warmup/solve_me_first.md]]

namespace algorithm_exercises_csharp.hackerrank.warmup;

public static class MiniMaxSum
{
  public static string miniMaxSum(List<int> arr)
  {
    ArgumentNullException.ThrowIfNull(arr);

    if (arr.Count == 0)
    {
      throw new ArgumentException("Parameter cannot be empty", nameof(arr));
    }

    int tsum = 0;
    int tmin = arr[0];
    int tmax = arr[0];

    foreach (int value in arr)
    {
      tsum += value;

      tmin = Math.Min(tmin, value);
      tmax = Math.Max(tmax, value);
    }

    return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0} {1}", tsum - tmax, tsum - tmin);
  }
}
