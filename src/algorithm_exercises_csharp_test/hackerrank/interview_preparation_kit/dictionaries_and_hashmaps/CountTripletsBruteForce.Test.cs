namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;
using algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

[TestClass]
public class CountTripletsBruteForceTest
{
  public class CountTripletsBruteForceTestCase
  {
    public string title { get; set; } = default!;
    public List<long> input { get; set; } = default!;
    public int r { get; set; } = default!;
    public int expected { get; set; } = default!;
  }

  private List<CountTripletsBruteForceTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<CountTripletsBruteForceTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/count_triplets_1.small.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testCountTriplets()
  {
    long result;

    foreach (CountTripletsBruteForceTestCase test in testCases)
    {
      result = CountTripletsBruteForce.countTriplets(test.input, test.r);
      Assert.AreEqual(test.expected, result);
    }
  }
}
