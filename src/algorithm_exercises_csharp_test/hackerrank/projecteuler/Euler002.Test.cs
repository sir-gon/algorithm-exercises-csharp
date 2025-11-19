namespace algorithm_exercises_csharp_test.hackerrank.projecteuler;

using algorithm_exercises_csharp.hackerrank.projecteuler;

[TestClass]
public class Euler002Test
{
  public class Euler002TestCase
  {
    public int N { get; set; }
    public int Answer { get; set; }
  }

  private static readonly Euler002TestCase[] tests = [
    new() { N = 10, Answer = 10 },
    new() { N = 100, Answer = 44 }
  ];

  [TestMethod]
  public void euler002Test()
  {
    int result;
    foreach (Euler002TestCase test in tests)
    {
      result = Euler002.euler002(test.N);
      Assert.AreEqual(test.Answer, result);
    }
  }
}


