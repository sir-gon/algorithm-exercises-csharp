// @link Problem definition [[docs/hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/count_triplets_1.md]]

// @link Solution notes [[docs/hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/count_triplets_1-solution-notes.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

using System.Collections.Generic;

public class CountTriplets
{
  public static long countTriplets(List<long> arr, long r)
  {
    Dictionary<long, long> aCounter = [];
    Dictionary<long, long> bCounter = [];
    long triplets = 0L;

    foreach (long item in arr)
    {
      aCounter[item] = aCounter.TryGetValue(item, out long value) ? value + 1L : 1L;
    }

    long prevItemCount;
    long nextItemCount;

    foreach (long item in arr)
    {
      long j = item / r;
      long k = item * r;

      aCounter[item] = aCounter[item] - 1L;

      prevItemCount = bCounter.TryGetValue(j, out long bItem) ? bItem : 0L;
      nextItemCount = aCounter.TryGetValue(k, out long aItem) ? aItem : 0L;
      if (item % r == 0)
      {
        triplets += prevItemCount * nextItemCount;
      }

      bCounter[item] = bCounter.TryGetValue(item, out long currentItemCount) ? currentItemCount + 1L : 1L;
    }

    return triplets;
  }
}
