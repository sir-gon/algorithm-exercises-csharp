namespace algorithm_exercises_csharp_test.hackerrank.warmup;

using algorithm_exercises_csharp.hackerrank.warmup;

using algorithm_exercises_csharp_test.common;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CompareTripletsTest
{
  public class CompareTripletsTestCase(List<int> a, List<int> b, List<int> expected)
  {
    private readonly List<int> a = a;
    private readonly List<int> b = b;
    private readonly List<int> expected = expected;

    public List<int> A
    {
      get { return a; }
    }

    public List<int> B
    {
      get { return b; }
    }

    public List<int> Expected
    {
      get { return expected; }
    }
  }

  private List<CompareTripletsTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.stringLoad<List<CompareTripletsTestCase>>(/*lang=json,strict*/ @"
      [
        {
          ""a"": [5, 6, 7],
          ""b"": [3, 6, 10],
          ""expected"": [1, 1]
        }
      ]
      ") ?? [];
  }

  [TestMethod]
  public void testSimpleArraySum()
  {
    List<int> result;

    foreach (CompareTripletsTestCase test in testCases)
    {
      result = CompareTriplets.compareTriplets(test.A, test.B);
      CollectionAssert.AreEquivalent(test.Expected, result);
    }
  }
}

