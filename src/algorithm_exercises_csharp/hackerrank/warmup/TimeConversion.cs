// @link Problem definition [[docs/hackerrank/warmup/time_conversion.md]]

namespace algorithm_exercises_csharp.hackerrank.warmup;

public static class TimeConversion
{
  public static string timeConversion(string _s)
  {
    ArgumentNullException.ThrowIfNull(_s);

    string meridian = _s[^2..];
    meridian = meridian.ToLowerInvariant();

    string time_str = _s[0..(_s.Length - 2)];
    List<string> time = [.. time_str.Split(":")];

    int hour = Int32.Parse(time[0], System.Globalization.CultureInfo.InvariantCulture);

    if (hour >= 12)
    {
      hour = 0;
    }
    if (meridian == "pm")
    {
      hour += 12;
    }

    time[0] = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:00}", hour);
    return string.Join(":", time);
  }
}
