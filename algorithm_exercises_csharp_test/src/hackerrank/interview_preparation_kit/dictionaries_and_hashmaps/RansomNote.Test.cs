namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit;

[TestClass]
public class RansomNoteTest
{
  public class RansomNoteTestCase
  {
    public string title { get; set; } = default!;
    public List<string> magazine { get; set; } = default!;
    public List<string> note { get; set; } = default!;
    public string expected { get; set; } = default!;
  }

  private List<RansomNoteTestCase> testCases { get; set; } = default!;

  [TestInitialize]
  public void testInitialize()
  {
    testCases = JsonLoader.resourceLoad<List<RansomNoteTestCase>>(
      "hackerrank/interview_preparation_kit/dictionaries_and_hashmaps/ctci_ransom_note.testcases.json"
    ) ?? [];
  }

  [TestMethod]
  public void testCheckMagazine()
  {
    string result;

    foreach (RansomNoteTestCase test in testCases)
    {
      result = RansomNote.checkMagazine(test.magazine, test.note);
      Assert.AreEqual(test.expected, result);
    }
  }
}
