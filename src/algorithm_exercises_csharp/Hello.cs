namespace algorithm_exercises_csharp;

using System.Diagnostics.CodeAnalysis;

public class HelloWorld
{
  private readonly string __message = "Hello World!";

  public string hello()
  {
    return __message;
  }

  public static HelloWorld create()
  {
    return new HelloWorld();
  }
}
