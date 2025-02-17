namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;
using algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

[TestClass]
public class TwoStringsTest
{
  public class TwoStringsTestCase
  {
    public string title { get; set; } = default!;

    public string s1 { get; set; } = default!;

    public string s2 { get; set; } = default!;

    public string expected { get; set; } = default!;
  }

  private List<TwoStringsTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<TwoStringsTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/two_strings.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testTwoStrings()
  {
    string result;

    foreach (TwoStringsTestCase test in testCases)
    {
      result = TwoStrings.twoStrings(test.s1, test.s2);
      Assert.AreEqual(test.expected, result);
    }
  }
}
