namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.arrays;
using algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

[TestClass]
public class ArraysLeftRotationTest
{
  public class ArraysLeftRotationsTestCase
  {
    public List<int> input { get; } = default!;
    public int d { get; set; }
    public List<int> expected { get; } = default!;
  }

  private List<ArraysLeftRotationsTestCase> testCases = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<ArraysLeftRotationsTestCase>>(
      "hackerrank/interview_preparation_kit/arrays/ctci_array_left_rotation.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testRotLeft()
  {
    List<int> result;

    foreach (ArraysLeftRotationsTestCase test in testCases)
    {
      result = ArraysLeftRotation.rotLeft(test.input, test.d);
      CollectionAssert.AreEquivalent(test.expected, result);
    }
  }
}

