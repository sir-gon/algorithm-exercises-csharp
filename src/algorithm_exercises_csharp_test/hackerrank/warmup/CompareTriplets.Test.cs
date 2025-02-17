namespace algorithm_exercises_csharp_test.hackerrank.warmup;
using algorithm_exercises_csharp.hackerrank.warmup;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CompareTripletsTest
{
  public class CompareTripletsTestCase
  {
    public List<int> a = [];
    public List<int> b = [];
    public List<int> expected = [];
  }

  // dotnet_style_readonly_field = true
  private static readonly CompareTripletsTestCase[] tests = [
    new()
    {
      a = [5, 6, 7],
      b = [3, 6, 10],
      expected = [1, 1]
    }
  ];

  [TestMethod]
  public void testSimpleArraySum()
  {
    List<int> result;

    foreach (CompareTripletsTestCase test in tests)
    {
      result = CompareTriplets.compareTriplets(test.a, test.b);
      CollectionAssert.AreEquivalent(test.expected, result);
    }
  }
}

