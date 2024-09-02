namespace algorithm_exercises_csharp.hackerrank.projecteuler;

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
  public void euler002Test()
  {
    int result;

    foreach (Euler002TestCase test in tests)
    {
      result = Euler002.euler002(test.n);
      Assert.AreEqual(test.answer, result);
    }
  }
}

