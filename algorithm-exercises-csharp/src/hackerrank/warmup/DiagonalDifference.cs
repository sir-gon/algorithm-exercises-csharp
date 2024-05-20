// @link Problem definition [[docs/hackerrank/warmup/diagonal_difference.md]]

namespace algorithm_exercises_csharp.hackerrank;

using System.Diagnostics.CodeAnalysis;

public class DiagonalDifference
{
  [ExcludeFromCodeCoverage]
  protected DiagonalDifference() { }

  public static int diagonalDifference(List<List<int>> _arr)
  {
    int diag1 = 0;
    int diag2 = 0;
    int last = _arr.Count - 1;

    int i = 0;
    foreach (List<int> line in _arr)
    {
      int j = 0;
      foreach (int cell in line)
      {
        if (i == j)
        {
          diag1 += cell;
          diag2 += _arr[last - i][j];
        }

        j += 1;
      }

      i += 1;
    }

    int result = Math.Abs(diag1 - diag2);
    return result;
  }

}
