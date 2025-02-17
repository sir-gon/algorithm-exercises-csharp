namespace algorithm_exercises_csharp.hackerrank;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class AVeryBigSumTest
{
  public class AVeryBigSumTestCase
  {
    public List<long> ar = [];
    public long expected = 0;
  }

  private static readonly AVeryBigSumTestCase[] tests = [
    new()
    {
      ar = [1000000001, 1000000002, 1000000003, 1000000004, 1000000005],
      expected = 5000000015
    }
  ];

  [TestMethod]
  public void testSimpleArraySum()
  {
    long result;

    foreach (AVeryBigSumTestCase test in tests)
    {
      result = AVeryBigSum.aVeryBigSum(test.ar);
      Assert.AreEqual(test.expected, result);
    }
  }
}

