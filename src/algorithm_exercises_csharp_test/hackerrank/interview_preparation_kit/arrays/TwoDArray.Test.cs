namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.arrays;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

[TestClass]
public class TwoDArrayTest
{
  public class TwoDArrayTestCase(string title, List<List<int>> input, long expected)
  {
    public string Title { get; } = title;
    public List<List<int>> Input { get; } = input;
    public long Expected { get; } = expected;
  }

  private List<TwoDArrayTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<TwoDArrayTestCase>>(
      "hackerrank/interview_preparation_kit/arrays/2d_array.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testHourglassSum()
  {
    long result;

    foreach (TwoDArrayTestCase test in testCases)
    {
      result = TwoDArray.hourglassSum(test.Input);
      Assert.AreEqual(test.Expected, result);
    }
  }


  [TestMethod]
  public void testHourglassSumEdgeCases()
  {
    List<List<int>> input = [];
    int expected = 0;
    int result = TwoDArray.hourglassSum(input);

    Assert.AreEqual(expected, result);
  }
}

