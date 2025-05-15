// @link Problem definition [[docs/hackerrank/warmup/staircase.md]]

namespace algorithm_exercises_csharp.hackerrank.warmup;

using System.Text;

public static class Staircase
{
  public static string staircase(int _n)
  {
    List<string> result = [];

    for (int i = 1; i < _n + 1; i++)
    {
      StringBuilder line = new();

      for (int j = 1; j < _n + 1; j++)
      {
        if (j <= _n - i)
        {
          line.Append(' ');
        }
        else
        {
          line.Append('#');
        }
      }

      result.Add(line.ToString());
    }
    return string.Join("\n", result);
  }
}
