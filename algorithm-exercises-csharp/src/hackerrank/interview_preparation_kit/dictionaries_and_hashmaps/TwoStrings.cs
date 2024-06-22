// @link Problem definition [[docs/hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/ctci-ransom-note.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit;

using System.Diagnostics.CodeAnalysis;

public class TwoStrings
{
  [ExcludeFromCodeCoverage]
  protected TwoStrings() { }

  private static readonly string __YES__ = "Yes";
  private static readonly string __NO__ = "No";
  private static readonly char __EMPTY_CHAR__ = '\0';

  public static bool twoStringsCompute(string s1, string s2)
  {
    char occurrence = s1.FirstOrDefault(c => s2.Contains(c), __EMPTY_CHAR__);

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
