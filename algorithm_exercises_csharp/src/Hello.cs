namespace algorithm_exercises_csharp;

using System.Diagnostics.CodeAnalysis;

public class HelloWorld
{
  const string __message = "Hello World!";

  [ExcludeFromCodeCoverage]
  protected HelloWorld() { }

  public static string hello()
  {
    return __message;
  }

  public static HelloWorld create()
  {
    return new HelloWorld();
  }
}
