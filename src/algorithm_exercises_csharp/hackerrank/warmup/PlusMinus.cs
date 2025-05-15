// @link Problem definition [[docs/hackerrank/warmup/plus_minus.md]]

namespace algorithm_exercises_csharp.hackerrank.warmup;

using System.Globalization;

public static class PlusMinus
{
  public static string plusMinus(List<int> arr)
  {
    ArgumentNullException.ThrowIfNull(arr);

    int positives = 0;
    int negatives = 0;
    int zeros = 0;

    foreach (int value in arr)
    {
      if (value > 0)
      {
        positives += 1;
      }
      if (value < 0)
      {
        negatives += 1;
      }
      if (value == 0)
      {
        zeros += 1;
      }
    }

    List<string> result = [];
    var nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };

    result.Add(String.Format(nfi, "{0:F6}", (double)positives / arr.Count));
    result.Add(String.Format(nfi, "{0:F6}", (double)negatives / arr.Count));
    result.Add(String.Format(nfi, "{0:F6}", (double)zeros / arr.Count));

    return String.Join("\n", result);
  }
}
