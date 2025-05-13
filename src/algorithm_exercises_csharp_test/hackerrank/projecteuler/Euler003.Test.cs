namespace algorithm_exercises_csharp_test.hackerrank.projecteuler;
using algorithm_exercises_csharp.hackerrank.projecteuler;

[TestClass]
public class Euler003Test
{
  public class Euler003TestCase
  {
    public int N { get; set; }
    public int? Answer { get; set; }
  }

  private static readonly Euler003TestCase[] tests = [
    new() { N = 1, Answer = null },
    new() { N = 10, Answer = 5 },
    new() { N = 17, Answer = 17 }
  ];

  [TestMethod]
  public void euler003Test()
  {
    int? result;
    foreach (Euler003TestCase test in tests)
    {
      result = Euler003.euler003(test.N);
      Assert.AreEqual(test.Answer, result);
    }
  }
}

