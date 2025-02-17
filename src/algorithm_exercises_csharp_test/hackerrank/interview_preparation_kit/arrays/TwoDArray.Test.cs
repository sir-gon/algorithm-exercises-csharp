namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit;

[TestClass]
public class TwoDArrayTest
{
  public class TwoDArrayTestCase
  {
    public string title { get; set; } = default!;
    public List<List<int>> input { get; set; } = default!;
    public long expected { get; set; } = default!;
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
      result = TwoDArray.hourglassSum(test.input);
      Assert.AreEqual(test.expected, result);
    }
  }
}

