// @link Problem definition [[docs/hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/count_triplets_1.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

public class CountTripletsBruteForce
{
  [ExcludeFromCodeCoverage]
  protected CountTripletsBruteForce() { }

  public static long countTriplets(List<long> arr, long r)
  {
    long size = arr.Count;
    long counter = 0L;

    for (int i = 0; i < size - 2; i++)
    {
      for (int j = i + 1; j < size - 1; j++)
      {
        for (int k = j + 1; k < size; k++)
        {
          if (r * arr[i] == arr[j] && r * arr[j] == arr[k])
          {
            counter += 1;
          }
        }
      }
    }

    return counter;
  }
}
