namespace algorithm_exercises_csharp_test.hackerrank.warmup;

using algorithm_exercises_csharp.hackerrank.warmup;

using algorithm_exercises_csharp_test.common;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class AVeryBigSumTest
{
  public class AVeryBigSumTestCase(List<long> ar, long expected)
  {
    private readonly List<long> ar = ar;
    private readonly long expected = expected;

    public List<long> Ar
    {
      get { return ar; }
    }

    public long Expected
    {
      get { return expected; }
    }
  }

  private List<AVeryBigSumTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.stringLoad<List<AVeryBigSumTestCase>>(/*lang=json,strict*/ @"
      [
        {
          ""ar"": [1000000001, 1000000002, 1000000003, 1000000004, 1000000005],
          ""expected"": 5000000015
        }
      ]
      ") ?? [];
  }

  [TestMethod]
  public void testSimpleArraySum()
  {
    long result;

    foreach (AVeryBigSumTestCase test in testCases)
    {
      result = AVeryBigSum.aVeryBigSum(test.Ar);
      Assert.AreEqual(test.Expected, result);
    }
  }
}

