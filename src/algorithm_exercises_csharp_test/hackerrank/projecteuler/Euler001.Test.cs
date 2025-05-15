namespace algorithm_exercises_csharp_test.hackerrank.projecteuler;
using algorithm_exercises_csharp.hackerrank.projecteuler;

[TestClass]
public class Euler001Test
{
  public class Euler001TestCase
  {
    public int A { get; set; }
    public int B { get; set; }
    public int N { get; set; }
    public int Answer { get; set; }
  }

  private static readonly Euler001TestCase[] tests = [
    new() { A = 3, B = 5, N = 10, Answer = 23 },
    new() { A = 3, B = 5, N = 100, Answer = 2318 },
    new() { A = 3, B = 5, N = 1000, Answer = 233168 }
  ];

  [TestMethod]
  public void euler001Test()
  {
    int result;

    foreach (Euler001TestCase test in tests)
    {
      result = Euler001.euler001(test.A, test.B, test.N);
      Assert.AreEqual(test.Answer, result);
    }
  }
}

