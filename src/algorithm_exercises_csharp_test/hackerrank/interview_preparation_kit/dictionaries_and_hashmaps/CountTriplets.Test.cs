namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;
using algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

[TestClass]
public class CountTripletsTest
{
  public class CountTripletsTestCase
  {
    public string title { get; set; } = default!;
    public List<long> input { get; set; } = default!;
    public int r { get; set; } = default!;
    public long expected { get; set; } = default!;
  }

  private List<CountTripletsTestCase> testCases { get; set; } = default!;
  private List<CountTripletsTestCase> bigTestCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<CountTripletsTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/count_triplets_1.small.testcases.json"
    ) ?? [];

    bigTestCases = JsonLoader.resourceLoad<List<CountTripletsTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/count_triplets_1.big.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testCountTriplets()
  {
    long result;

    foreach (CountTripletsTestCase test in testCases)
    {
      result = CountTriplets.countTriplets(test.input, test.r);
      Assert.AreEqual(test.expected, result);
    }

    foreach (CountTripletsTestCase test in bigTestCases)
    {
      result = CountTriplets.countTriplets(test.input, test.r);
      Assert.AreEqual(test.expected, result);
    }
  }
}
