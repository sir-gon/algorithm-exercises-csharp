namespace algorithm_exercises_csharp.hackerrank.projecteuler;

[TestClass]
public class Euler001Test
{
  public class Euler001TestCase
  {
    public int a; public int b; public int n; public int answer;
  }

  // dotnet_style_readonly_field = true
  private static readonly Euler001TestCase[] tests = [
    new() { a = 3, b = 5, n = 10, answer = 23 },
    new() { a = 3, b = 5, n = 100, answer = 2318 },
    new() { a = 3, b = 5, n = 1000, answer = 233168 },

  ];

  [TestMethod]
  public void euler001Test()
  {
    int result;

    foreach (Euler001TestCase test in tests)
    {
      result = Euler001.euler001(test.a, test.b, test.n);
      Assert.AreEqual(test.answer, result);
    }
  }
}

