namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

using algorithm_exercises_csharp_test.common;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.dictionaries_and_hashmaps;

[TestClass]
public class RansomNoteTest
{
  public class RansomNoteTestCase(string title, List<string> magazine, List<string> note, string expected)
  {
    private readonly string title = title;
    private readonly List<string> magazine = [.. magazine];
    private readonly List<string> note = [.. note];
    private readonly string expected = expected;

    public string Title
    {
      get { return title; }
    }

    public List<string> Magazine
    {
      get { return magazine; }
    }

    public List<string> Note
    {
      get { return note; }
    }

    public string Expected
    {
      get { return expected; }
    }
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
      result = RansomNote.checkMagazine(test.Magazine, test.Note);
      Assert.AreEqual(test.Expected, result);
    }
  }

  [TestMethod]
  public void testException()
  {
#pragma warning disable CA2201 // No provocar tipos de excepción reservados
    Assert.ThrowsExactly<RansomNote.InvalidValueException>(() => throw new RansomNote.InvalidValueException());

    Assert.ThrowsExactly<RansomNote.InvalidValueException>(() => throw new RansomNote.InvalidValueException("test exception", new Exception("test exception")));
#pragma warning restore CA2201 // No provocar tipos de excepción reservados
  }
}
