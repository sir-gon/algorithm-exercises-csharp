// @link Problem definition [[docs/hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/frequency-queries.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

public class FrequencyQueries
{
  [ExcludeFromCodeCoverage]
  private FrequencyQueries() { }

  private static readonly long __INITIAL__ = 1L;

  private const int __INSERT__ = 1;
  private const int __DELETE__ = 2;
  private const int __SELECT__ = 3;

  private static readonly int __NOT_FOUND__ = 0;
  private static readonly int __FOUND__ = 1;

  readonly Dictionary<long, long> valueFreqs = [];
  readonly Dictionary<long, List<long>> freqDictionary = [];
  List<int> result = [];

  void insert(long value)
  {
    bool currentValueFreqCountExists = valueFreqs.TryGetValue(value, out long currentValueFreqCount);

    long newFreqCount;

    newFreqCount = !currentValueFreqCountExists ? __INITIAL__ : currentValueFreqCount + 1;
    valueFreqs[value] = newFreqCount;

    freqDictionary.TryGetValue(newFreqCount, out List<long>? newFreq);

    // delete current frequency
    if (currentValueFreqCountExists)
    {
      freqDictionary[currentValueFreqCount].Remove(value);
      if (freqDictionary[currentValueFreqCount].Count == 0)
      {
        freqDictionary.Remove(currentValueFreqCount);
      }
    }

    // add new frequency
    if (newFreq == null)
    {
      newFreq = [];
      newFreq.Add(value);
      freqDictionary[newFreqCount] = newFreq;
    }
    else
    {
      freqDictionary[newFreqCount].Add(value);
    }
  }

  void delete(long value)
  {
    bool currentValueFreqCountExists = valueFreqs.TryGetValue(value, out long currentValueFreqCount);

    long newFreqCount;

    newFreqCount = !currentValueFreqCountExists ? 0 : currentValueFreqCount - 1;
    if (newFreqCount > 0)
    {
      valueFreqs[value] = newFreqCount;

      freqDictionary.TryGetValue(newFreqCount, out List<long>? newFreq);

      // add new frequency
      if (newFreq == null)
      {
        newFreq = [];
        newFreq.Add(value);
        freqDictionary[newFreqCount] = newFreq;
      }
      else
      {
        freqDictionary[newFreqCount].Add(value);
      }
    }
    else
    {
      valueFreqs.Remove(value);
    }

    // delete current frequency
    if (currentValueFreqCountExists)
    {
      freqDictionary[currentValueFreqCount].Remove(value);
      if (freqDictionary[currentValueFreqCount].Count == 0)
      {
        freqDictionary.Remove(currentValueFreqCount);
      }
    }
  }

  void reset()
  {
    result = [];
  }

  void select(long value)
  {
    result.Add(freqDictionary.ContainsKey(value) ? __FOUND__ : __NOT_FOUND__);
  }

  static FrequencyQueries factory()
  {
    FrequencyQueries fq = new();
    fq.reset();

    return fq;
  }

  /**
   * FrequencyQueries.
   */
  public static List<int> freqQuery(List<List<int>> queries)
  {
    FrequencyQueries fq = factory();

    foreach (List<int> query in queries)
    {
      int operation = query[0];
      long value = query[1];

      switch (operation)
      {
        case __INSERT__:
          fq.insert(value);

          break;
        case __DELETE__:
          fq.delete(value);

          break;
        case __SELECT__:
          fq.select(value);
          break;
        default:
          throw new InvalidOperationException($"Operation {operation} not supported");
      }
    }

    return fq.result;
  }
}
