// @link Problem definition [[docs/hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/ctci-ransom-note.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

using System.Diagnostics.CodeAnalysis;
using System.Numerics;

public static class SherlockAndAnagrams
{

  /**
   * factorial().
   */
  public static BigInteger factorial(int number)
  {
    BigInteger result = BigInteger.One;
    for (int i = 1; i <= number; i++)
    {
      result *= i;
    }

    return result;
  }

  public static int sherlockAndAnagrams(string s)
  {
    ArgumentException.ThrowIfNullOrEmpty(s);

    Dictionary<string, List<string>> candidates = [];

    int size = s.Length;
    for (int i = 0; i < size; i++)
    {
      for (int j = 0; j < size - i; j++)
      {
        string word = s[i..(size - j)];
        char[] wordArray = word.ToCharArray();
        Array.Sort(wordArray);
        string anagramCandidate = new(wordArray);

        if (candidates.TryGetValue(anagramCandidate, out List<string>? value))
        {
          value.Add(word);
        }
        else
        {
          candidates[anagramCandidate] = [word];
        }
      }
    }

    int k = 2;

    int total = candidates
    .Select(x => x.Value.Count)
    .Where(count => count > 1)
    .Sum(quantityOfAnagrams =>
        // Binomial coefficient: https://en.wikipedia.org/wiki/Binomial_coefficient
        (int)(factorial(quantityOfAnagrams) / factorial(k) / factorial(quantityOfAnagrams - k)));

    return total;
  }
}
