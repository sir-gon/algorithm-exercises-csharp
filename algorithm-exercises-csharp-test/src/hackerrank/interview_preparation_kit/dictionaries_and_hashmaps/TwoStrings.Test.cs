namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit;

[TestClass]
public class TwoStringsTest
{
  public class TwoStringsTestCase
  {
    public string title = "";
    public string s1 = "";
    public string s2 = "";
    public string expected = "Yes";
  }

  private static readonly TwoStringsTestCase[] tests = [
    new()
    {
      title = "Example 1",
      s1 = "and",
      s2 = "art",
      expected = "Yes"
    },
    new()
    {
      title = "Example 2",
      s1 = "be",
      s2 = "cat",
      expected = "No"
    },
    new()
    {
      title = "Sample Test Case 0",
      s1 = "hello",
      s2 = "world",
      expected = "Yes"
    },
  ];

  [TestMethod]
  public void testTwoStrings()
  {
    string result;

    foreach (TwoStringsTestCase test in tests)
    {
      result = TwoStrings.twoStrings(test.s1, test.s2);
      Assert.AreEqual(test.expected, result);
    }
  }
}
