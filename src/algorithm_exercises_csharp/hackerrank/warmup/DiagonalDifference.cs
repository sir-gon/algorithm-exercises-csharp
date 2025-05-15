// @link Problem definition [[docs/hackerrank/warmup/diagonal_difference.md]]

namespace algorithm_exercises_csharp.hackerrank.warmup;

using System.Diagnostics.CodeAnalysis;

public static class DiagonalDifference
{
  public static int diagonalDifference(List<List<int>> _arr)
  {
    ArgumentNullException.ThrowIfNull(_arr);

    int diag1 = 0;
    int diag2 = 0;
    int last = _arr.Count - 1;

    for (int i = 0; i < _arr.Count; i++)
    {
      diag1 += _arr[i][i];
      diag2 += _arr[last - i][i];
    }

    int result = Math.Abs(diag1 - diag2);
    return result;
  }
}
