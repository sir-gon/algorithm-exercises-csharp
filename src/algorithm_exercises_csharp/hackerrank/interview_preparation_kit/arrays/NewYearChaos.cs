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

      foreach (int k in fragment)
      {
        if (k > value)
        {
          bribes += 1;
        }
      }
      i += 1;
    }

    return bribes;
  }

  /**
   * minimumBribes.
   */
  public static String minimumBribesText(List<int> q)
  {
    try
    {
      int bribes = minimumBribesCalculate(q);
      return String.Format("{0}", bribes);
    }
    catch (InvalidOperationException e)
    {
      return String.Format(e.Message);
    }
  }

  /**
   * minimumBribesText.
   */
  public static void minimumBribes(List<int> q)
  {
    Console.WriteLine("{0}", minimumBribesText(q));
  }
}
