// @link Problem definition [[docs/hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/ctci-ransom-note.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit;

using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

public class RansomNote
{
  [ExcludeFromCodeCoverage]
  protected RansomNote() { }

  private static readonly string __YES__ = "Yes";
  private static readonly string __NO__ = "No";

  public static bool checkMagazineCompute(List<string> magazine, List<string> note)
  {
    Dictionary<string, int?> dictionary = [];

    foreach (string word in magazine)
    {
      if (dictionary.TryGetValue(word, out int? value))
      {
        dictionary[word] += 1;
      }
      else
      {
        dictionary[word] = 1;
      }
    }

    foreach (string word in note)
    {
      if (dictionary.TryGetValue(word, out int? value) && value > 0)
      {
        dictionary[word] -= 1;
      }
      else
      {
        return false;
      }
    }

    return true;
  }

  public static string checkMagazine(List<string> magazine, List<string> note)
  {
    return checkMagazineCompute(magazine, note) ? __YES__ : __NO__;
  }
}
