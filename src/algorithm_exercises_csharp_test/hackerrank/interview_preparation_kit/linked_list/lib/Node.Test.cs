namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.linked_list.lib;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.linked_list.lib;

[TestClass]
public class NodeTest
{
  class NodeTestCase
  {
    public string title = "";
    public LinkedList<int>.Node? llist;
    public string separator = "";
    public string expected = "";
  }

  private static NodeTestCase[] tests = [];

  [TestInitialize]
  public void testInitialize()
  {
    // Linked list sample data:
    LinkedList<int>.Node ll1_1 = new(1);
    LinkedList<int>.Node ll1_2 = new(2);
    LinkedList<int>.Node ll1_3 = new(3);
    LinkedList<int>.Node ll1_4 = new(4);
    LinkedList<int>.Node ll1_5 = new(5);

    ll1_1.next = ll1_2;
    ll1_2.next = ll1_3;
    ll1_3.next = ll1_4;
    ll1_4.next = ll1_5;

    tests = [
      new()
      {
        title = "Sample Test case X",
        llist = ll1_1,
        separator = ", ",
        expected = "1, 2, 3, 4, 5"
      }
    ];
  }

  [TestMethod]
  public void testPrintLinkedList()
  {
    foreach (NodeTestCase test in tests)
    {
      StringWriter sw = new();

      LinkedList<int>.printSinglyLinkedList(test.llist, test.separator, sw);

      string result = sw.ToString();
      Assert.AreEqual(
        test.expected,
        result,
        String.Format(
          "{0} testPrintLinkedList<int>(<Node>, {1}, <Textwriter>) => must be: {2}",
          test.title,
          test.separator,
          test.expected
        )
      );
    }
  }
}
