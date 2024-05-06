namespace algorithm_exercises_csharp;

using System.Diagnostics.CodeAnalysis;

public class HelloWorld
{
  [ExcludeFromCodeCoverage]
  protected HelloWorld() {}

  public static string Hello()
  {
    return "Hello World!";
  }
}
