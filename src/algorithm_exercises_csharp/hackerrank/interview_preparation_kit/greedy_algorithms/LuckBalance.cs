// @link Problem definition [[docs/hackerrank/interview_preparation_kit/greedy_algorithms/luck-balance.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.greedy_algorithms;

using System.Diagnostics.CodeAnalysis;

public static class LuckBalance
{
  public class Competition(int _luck, int _important)
  {
    public int luck => _luck;
    public int important => _important;
  }

  public static int luckBalance(int k, List<List<int>> contests)
  {
    ArgumentNullException.ThrowIfNull(contests);

    List<Competition> important_competitions = [];
    List<Competition> nonimportant_competitions = [];

    foreach (var x in contests)
    {
      var luck = x[0];
      var important = x[1];

      if (important == 1)
      {
        important_competitions.Add(new Competition(luck, important));
      }
      else
      {
        nonimportant_competitions.Add(new Competition(luck, important));
      }
    }

    important_competitions = [.. important_competitions
      .OrderByDescending(s => s.important)
      .ThenByDescending(s => s.luck)];

    int total = 0;
    int size = important_competitions.Count;

    for (int i = 0; i < Math.Min(k, size); i++)
    {
      total += important_competitions[i].luck;
    }

    for (int i = Math.Min(k, size); i < size; i++)
    {
      total -= important_competitions[i].luck;
    }

    foreach (Competition x in nonimportant_competitions)
    {
      total += x.luck;
    }

    return total;
  }
}
