// @link Problem definition [[docs/hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/two-strings.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

using System.Diagnostics.CodeAnalysis;

public static class TwoStrings
{
  private const string __YES__ = "Yes";
  private const string __NO__ = "No";
  private const char __EMPTY_CHAR__ = '\0';

  public static bool twoStringsCompute(string s1, string s2)
  {
    ArgumentException.ThrowIfNullOrEmpty(s1);
    ArgumentException.ThrowIfNullOrEmpty(s2);

    char occurrence = s1.FirstOrDefault(s2.Contains, __EMPTY_CHAR__);

    if (occurrence != __EMPTY_CHAR__)
    {
      return true;
    }

    return false;
  }

  public static string twoStrings(string s1, string s2)
  {
    return twoStringsCompute(s1, s2) ? __YES__ : __NO__;
  }
}
