namespace algorithm_exercises_csharp.hackerrank.prohecteuler;

[TestClass]
public class Euler002Test
{
  public class Euler002TestCase
  {
    public int n; public int answer;
  }

  // dotnet_style_readonly_field = true
  private static readonly Euler002TestCase[] tests = [
    new() { n = 10, answer = 10 },
    new() { n = 100, answer = 44 }
  ];

  [TestMethod]
  public void Euler002ProblemTest()
  {
    int result;

    foreach (Euler002TestCase test in tests)
    {
      result = Euler002Problem.Euler002(test.n);
      Assert.AreEqual(test.answer, result);
    }
  }
}

