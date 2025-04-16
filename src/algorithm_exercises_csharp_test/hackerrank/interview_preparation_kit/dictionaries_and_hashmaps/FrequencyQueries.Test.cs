namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;
using algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

[TestClass]
public class FrequencyQueriesTest
{
  public class FrequencyQueriesTestCase
  {
    public string title { get; set; } = default!;
    public List<List<int>> input { get; set; } = default!;
    public List<int> expected { get; set; } = default!;
  }

  List<FrequencyQueriesTestCase> testCases { get; set; } = default!;
  List<FrequencyQueriesTestCase> testCase6 { get; set; } = default!;
  List<FrequencyQueriesTestCase> testCaseBorderCases { get; set; } = default!;
  List<FrequencyQueriesTestCase> testCaseBorderCaseException { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<FrequencyQueriesTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/frequency_queries.testcases.json"
    ) ?? [];

    testCase6 = JsonLoader.resourceLoad<List<FrequencyQueriesTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/frequency_queries.testcase6.json"
    ) ?? [];

    testCaseBorderCases = JsonLoader.resourceLoad<List<FrequencyQueriesTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/frequency_queries.testcase_border_cases.json"
    ) ?? [];

    testCaseBorderCaseException = JsonLoader.resourceLoad<List<FrequencyQueriesTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/frequency_queries.testcase_border_case_exception.json"
    ) ?? [];
  }

  [TestMethod]
  public void testFrequencyQueries()
  {
    List<int> solutionFound;

    foreach (FrequencyQueriesTestCase test in testCases)
    {
      solutionFound = FrequencyQueries.freqQuery(test.input);
      CollectionAssert.AreEqual(test.expected, solutionFound);
    }
  }

  [TestMethod]
  public void testFrequencyQueriesBigCases()
  {
    List<int> solutionFound;

    foreach (FrequencyQueriesTestCase test in testCase6)
    {
      solutionFound = FrequencyQueries.freqQuery(test.input);
      CollectionAssert.AreEqual(test.expected, solutionFound, String.Format("%s(%s) answer must be: %s" +
              "FrequencyQueriesTest.freqQuery",
              test.input.ToString(),
              test.expected.ToString()));
    }
  }

  [TestMethod]
  public void testFrequencyQueriesBorderCases()
  {
    List<int> solutionFound;

    foreach (FrequencyQueriesTestCase test in testCaseBorderCases)
    {
      solutionFound = FrequencyQueries.freqQuery(test.input);
      CollectionAssert.AreEqual(test.expected, solutionFound, String.Format("%s(%s) answer must be: %s" +
              "FrequencyQueriesTest.freqQuery",
              test.input.ToString(),
              test.expected.ToString()));
    }
  }

  [TestMethod]
  public void testFrequencyQueriesBorderCaseException()
  {
    foreach (FrequencyQueriesTestCase test in testCaseBorderCaseException)
    {
      Assert.ThrowsExactly<InvalidOperationException>(() => _ = FrequencyQueries.freqQuery(test.input));
    }
  }
}
