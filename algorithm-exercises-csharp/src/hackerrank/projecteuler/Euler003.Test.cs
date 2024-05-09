// @link Problem definition [[docs/hackerrank/projecteuler/euler003.md]]
// Notes about final solution please see:
// @link [[docs/hackerrank/projecteuler/euler003-solution-notes.md]]


namespace algorithm_exercises_csharp.hackerrank.prohecteuler;

[TestClass]
public class Euler003Test
{
  public class Euler003TestCase {
    public int n; public int? answer;
  }

  // dotnet_style_readonly_field = true
  private static readonly Euler003TestCase[] tests = [
    new() { n = 1, answer = null},
    new() { n = 10, answer = 5},
    new() { n = 17, answer = 17}
  ];

  [TestMethod]
  public void Euler003ProblemTest()
  {
    int? result;

    foreach (Euler003TestCase test in tests) {
      result = Euler003Problem.Euler003(test.n);
      Assert.AreEqual(test.answer, result);
    }
  }
}

