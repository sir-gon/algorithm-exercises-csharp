namespace algorithm_exercises_csharp;

using System.Diagnostics.CodeAnalysis;

public class HelloWorld
{
  const string message = "Hello World!";

  [ExcludeFromCodeCoverage]
  protected HelloWorld() { }

  public static string Hello()
  {
    return HelloWorld.message;
  }

  public static HelloWorld Create()
  {
    return new HelloWorld();
  }
}
