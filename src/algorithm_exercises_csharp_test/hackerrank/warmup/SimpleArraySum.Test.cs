namespace algorithm_exercises_csharp_test.hackerrank.warmup;

using algorithm_exercises_csharp.hackerrank.warmup;

using algorithm_exercises_csharp_test.common;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SimpleArraySumTest
{
  public class SimpleArraySumTestCase(List<int> input, int expected)
  {
    private readonly List<int> input = input;
    private readonly int expected = expected;

    public List<int> Input
    {
      get { return input; }
    }

    public int Expected
    {
      get { return expected; }
    }
  }

  private List<SimpleArraySumTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.stringLoad<List<SimpleArraySumTestCase>>(/*lang=json,strict*/ @"
      [
        {
          ""input"": [1, 2, 3, 4, 10, 11],
          ""expected"": 31
        }
      ]
      ") ?? [];
  }

  [TestMethod]
  public void testSimpleArraySum()
  {
    int? result;

    foreach (SimpleArraySumTestCase test in testCases)
    {
      result = SimpleArraySum.simpleArraySum(test.Input);
      Assert.AreEqual(test.Expected, result);
    }
  }
}

