namespace algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp;

using System.Reflection;
using System.Text;
using System;

using Newtonsoft.Json;

public static class JsonLoader
{
  public static T? resourceLoad<T>(string path)
  {
    ArgumentNullException.ThrowIfNull(path);

    path = path.Replace('/', '.');
    path = path.Replace('\\', '.');

    var info = Assembly.GetExecutingAssembly().GetName();
    var name = info.Name;

    path = $"{name}.Resources.{path}";
    Log.debug($"Loading JSON from: {path}");

    using var stream = Assembly
        .GetExecutingAssembly()
        .GetManifestResourceStream($"{path}")!;

    using var streamReader = new StreamReader(stream, Encoding.UTF8);

    return JsonConvert.DeserializeObject<T>(
      streamReader.ReadToEnd()
    );
  }

  public static T? stringLoad<T>(string json)
  {
    return JsonConvert.DeserializeObject<T>(json);
  }
}
