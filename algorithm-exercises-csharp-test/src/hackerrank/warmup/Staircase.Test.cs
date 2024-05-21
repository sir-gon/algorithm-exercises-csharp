namespace algorithm_exercises_csharp.hackerrank;

[TestClass]
public class StaircaseTest
{
  [TestMethod]
  public void testStaircase()
  {
    int input = 6;
    string expectedAnswer = String.Join("\n",
      "     #",
      "    ##",
      "   ###",
      "  ####",
      " #####",
      "######"
    );

    string result = Staircase.staircase(input);

    Assert.AreEqual(expectedAnswer, result);
  }
}

