namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit;

[TestClass]
public class RansomNoteTest
{
  public class RansomNoteTestCase
  {
    public string title = "";
    public List<string> magazine = [];
    public List<string> note = [];
    public string expected = "";
  }

  public class ArraysLeftRotationsTestCase
  {
    public List<int> input = []; public int d; public List<int> expected = [];
  }

  private static readonly RansomNoteTestCase[] tests = [
    new()
    {
      title = "Sample Test Case 0",
      magazine = ["give", "me", "one", "grand", "today", "night"],
      note = ["give", "one", "grand", "today"],
      expected = "Yes"
    },
    new()
    {
      title = "Sample Test Case 1",
      magazine = ["two", "times", "three", "is", "not", "four"],
      note = ["two", "times", "two", "is", "four"],
      expected = "No"
    },
    new()
    {
      title = "Sample Test",
      magazine = ["two", "two", "times", "three", "is", "not", "four"],
      note = ["two", "times", "two", "is", "four"],
      expected = "Yes"
    },
  ];

  [TestMethod]
  public void testCheckMagazine()
  {
    string result;

    foreach (RansomNoteTestCase test in tests)
    {
      result = RansomNote.checkMagazine(test.magazine, test.note);
      Assert.AreEqual(test.expected, result);
    }
  }
}
