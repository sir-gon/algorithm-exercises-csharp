namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.arrays;
using algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

[TestClass]
public class NewYearChaosTest
{
  public class NewYearChaosTestCase
  {
    public string title { get; set; } = default!;
    public List<int> input { get; set; } = default!;
    public string expected { get; set; } = default!;
  }

  private List<NewYearChaosTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<NewYearChaosTestCase>>(
      "hackerrank/interview_preparation_kit/arrays/new_year_chaos.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testMinimumBribesText()
  {
    string result;

    foreach (NewYearChaosTestCase test in testCases)
    {
      result = NewYearChaos.minimumBribesText(test.input);
      NewYearChaos.minimumBribes(test.input);

      Assert.AreEqual(test.expected, result);
    }
  }
}

