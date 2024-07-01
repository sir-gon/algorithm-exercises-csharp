namespace algorithm_exercises_csharp.hackerrank;

[TestClass]
public class SolveMeFirstTest
{
  [TestMethod]
  public void testSolveMeFirst()
  {
    int expectedAnswer = 5;
    int a = 2;
    int b = 3;
    int result = SolveMeFirst.solveMeFirst(a, b);

    Assert.AreEqual(expectedAnswer, result);
  }
}

