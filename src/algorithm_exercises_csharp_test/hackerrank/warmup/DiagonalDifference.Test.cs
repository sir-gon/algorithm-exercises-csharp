namespace algorithm_exercises_csharp_test.hackerrank.warmup;
using algorithm_exercises_csharp.hackerrank.warmup;

[TestClass]
public class DiagonalDifferenceTest
{
  [TestMethod]
  public void testDiagonalDifference()
  {
    List<List<int>> arr = [
      [11, 2, 4],
      [4, 5, 6],
      [10, 8, -12]
    ];
    int expectedAnswer = 15;
    int result = DiagonalDifference.diagonalDifference(arr);

    Assert.AreEqual(expectedAnswer, result,
      String.Format("DiagonalDifference.diagonalDifference answer must be: {0}", expectedAnswer)
    );
  }
}

