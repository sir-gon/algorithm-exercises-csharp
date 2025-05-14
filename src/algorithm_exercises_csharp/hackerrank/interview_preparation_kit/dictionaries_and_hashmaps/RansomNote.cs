// @link Problem definition [[docs/hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/ctci-ransom-note.md]]

namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

public static class RansomNote
{
  public class InvalidValueException : Exception
  {
    // constructor for the InvalidAgeException class
    public InvalidValueException(string msg)
    {
      Console.WriteLine(msg);
    }

    public InvalidValueException()
    {
    }

    public InvalidValueException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }

  private const string __YES__ = "Yes";
  private const string __NO__ = "No";

  public static bool checkMagazineCompute(List<string> magazine, List<string> note)
  {
    ArgumentNullException.ThrowIfNull(magazine);
    ArgumentNullException.ThrowIfNull(note);

    Dictionary<string, int> dictionary = [];

    foreach (string word in magazine)
    {
      if (!dictionary.TryAdd(word, 1))
      {
        int currentValue = dictionary[word];
        dictionary[word] = currentValue + 1;
      }
    }

    foreach (string word in note)
    {
      try
      {
        dictionary[word] -= 1;
        if (dictionary[word] < 0)
        {
          throw new InvalidValueException("Value can't go below 0");
        }
      }
      catch (InvalidValueException)
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
