namespace algorithm_exercises_csharp_test.hackerrank.projecteuler;
using algorithm_exercises_csharp.hackerrank.projecteuler;

[TestClass]
public class Euler003Test
{
  public class Euler003TestCase
  {
    public int n; public int? answer;
  }

  // dotnet_style_readonly_field = true
  private static readonly Euler003TestCase[] tests = [
    new() { n = 1, answer = null },
    new() { n = 10, answer = 5 },
    new() { n = 17, answer = 17 }
  ];

  [TestMethod]
  public void euler003Test()
  {
    int? result;

    foreach (Euler003TestCase test in tests)
    {
      result = Euler003.euler003(test.n);
      Assert.AreEqual(test.answer, result);
    }
  }
}

