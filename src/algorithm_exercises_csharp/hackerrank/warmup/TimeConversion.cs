// @link Problem definition [[docs/hackerrank/warmup/time_conversion.md]]

namespace algorithm_exercises_csharp.hackerrank.warmup;

using System.Diagnostics.CodeAnalysis;

public class TimeConversion
{
  [ExcludeFromCodeCoverage]
  protected TimeConversion() { }

  public static string timeConversion(string _s)
  {
    string meridian = _s[^2..];
    meridian = meridian.ToLower();

    string time_str = _s[0..(_s.Length - 2)];
    List<string> time = [.. time_str.Split(":")];

    int hour = Int32.Parse(time[0]);

    if (hour >= 12)
    {
      hour = 0;
    }
    if (meridian == "pm")
    {
      hour += 12;
    }

    time[0] = String.Format("{0:00}", hour);
    return String.Join(":", time);
  }
}
