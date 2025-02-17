namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.arrays;
using algorithm_exercises_csharp_test.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.arrays;

[TestClass]
public class ArraysLeftRotationTest
{
  public class ArraysLeftRotationTestCase
  {
    public List<int> input { get; set; } = default!;
    public List<int> expected { get; set; } = default!;
  }

  public class ArraysLeftRotationsTestCase
  {
    public List<int> input { get; set; } = default!;
    public int d { get; set; }
    public List<int> expected { get; set; } = default!;
  }

  private List<ArraysLeftRotationTestCase> testCases { get; set; } = default!;

  private static readonly ArraysLeftRotationsTestCase[] testRotationsCases = [
    new() { input = [1, 2, 3, 4, 5], d = 4, expected = [5, 1, 2, 3, 4] }
  ];

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<ArraysLeftRotationTestCase>>(
      "hackerrank/interview_preparation_kit/arrays/ctci_array_left_rotation.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testRotLeftOne()
  {
    List<int> result;

    foreach (ArraysLeftRotationTestCase test in testCases)
    {
      result = ArraysLeftRotation.rotLeftOne(test.input);
      CollectionAssert.AreEquivalent(test.expected, result);
    }
  }

  [TestMethod]
  public void testRotLeft()
  {
    List<int> result;

    foreach (ArraysLeftRotationsTestCase test in testRotationsCases)
    {
      result = ArraysLeftRotation.rotLeft(test.input, test.d);
      CollectionAssert.AreEquivalent(test.expected, result);
    }
  }
}

