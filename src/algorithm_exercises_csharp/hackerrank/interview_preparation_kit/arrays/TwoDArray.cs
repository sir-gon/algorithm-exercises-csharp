// @link Problem definition [[docs/hackerrank/interview_preparation_kit/arrays/2d_array.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

using System.Diagnostics.CodeAnalysis;

public static class TwoDArray
{
  private static List<int> getHourGlass(List<List<int>> arr, int positionX, int positionY)
  {
    List<int> result = [];

    // top
    result.Add(arr[positionX - 1][positionY - 1]);
    result.Add(arr[positionX - 1][positionY]);
    result.Add(arr[positionX - 1][positionY + 1]);

    // middle
    result.Add(arr[positionX][positionY]);

    // bottom
    result.Add(arr[positionX + 1][positionY - 1]);
    result.Add(arr[positionX + 1][positionY]);
    result.Add(arr[positionX + 1][positionY + 1]);

    return result;
  }

  public static int hourglassSum(List<List<int>> arr)
  {
    ArgumentNullException.ThrowIfNull(arr);

    int matrixSize = arr.Count;

    int matrixStartIndex = 1;
    int matrixEndIndex = matrixSize - 2;

    int? maxHourGlassSum = null;

    for (int i = matrixStartIndex; i <= matrixEndIndex; i++)
    {
      for (int j = matrixStartIndex; j <= matrixEndIndex; j++)
      {
        int hourGlassSum = getHourGlass(arr, i, j).Sum();

        if (maxHourGlassSum == null || hourGlassSum > maxHourGlassSum)
        {
          maxHourGlassSum = hourGlassSum;
        }
      }
    }

    return maxHourGlassSum ?? 0;
  }
}
