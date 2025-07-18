// @link Problem definition [[docs/hackerrank/interview_preparation_kit/arrays/new_year_chaos.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

public static class NewYearChaos
{
  public const string TOO_CHAOTIC_ERROR = "Too chaotic";

  /**
   * minimumBribesCalculate.
   */
  public static int minimumBribesCalculate(List<int> q)
  {
    ArgumentNullException.ThrowIfNull(q);

    int bribes = 0;
    int i = 0;

    foreach (int value in q)
    {
      int position = i + 1;

      if (value - position > 2)
      {
        throw new InvalidOperationException(TOO_CHAOTIC_ERROR);
      }

      List<int> fragment = q[Math.Min(Math.Max(value - 2, 0), i)..i];

      bribes += fragment.Count(k => k > value);

      i += 1;
    }

    return bribes;
  }

  /**
   * minimumBribes.
   */
  public static string minimumBribesText(List<int> q)
  {
    try
    {
      int bribes = minimumBribesCalculate(q);
      return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", bribes);
    }
    catch (InvalidOperationException e)
    {
      return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", e.Message);
    }
  }

  /**
   * minimumBribesText.
   */
  public static void minimumBribes(List<int> q)
  {
    Console.WriteLine(minimumBribesText(q));
  }
}
