namespace algorithm_exercises_csharp.hackerrank.interview_preparation_kit;

[TestClass]
public class LinkedListCycleTest
{
  class LinkedListCycleTestCase
  {
    public string title = "";
    public LinkedList<string>.Node? llist;
    public bool expected;
  }

  private static LinkedListCycleTestCase[] tests = [];

  [TestInitialize]
  public void testInitialize()
  {
    // Linked list sample data:
    LinkedList<string>.Node ll1_1 = new("a");
    LinkedList<string>.Node ll1_2 = new("b");
    LinkedList<string>.Node ll1_3 = new("c");
    LinkedList<string>.Node ll1_4 = new("d");
    LinkedList<string>.Node ll1_5 = new("e");

    ll1_1.next = ll1_2;
    ll1_2.next = ll1_3;
    ll1_3.next = ll1_4;
    ll1_4.next = ll1_5;
    ll1_4.next = ll1_3; // <- cycle

    LinkedList<string>.Node ll2_1 = new("a");
    LinkedList<string>.Node ll2_2 = new("b");
    LinkedList<string>.Node ll2_3 = new("c");

    ll2_1.next = ll2_2;
    ll2_2.next = ll2_3;

    tests = [
      new()
      {
        title = "Sample Test case X",
        llist = ll1_1,
        expected = true
      },
      new()
      {
        title = "Sample Test case Y",
        llist = ll2_1,
        expected = false
      }
    ];
  }

  [TestMethod]
  public void testLinkedListCycle()
  {
    bool result;

    foreach (LinkedListCycleTestCase test in tests)
    {
      result = LinkedListCycle.hasCycle(test.llist);
      Assert.AreEqual(
        test.expected,
        result,
        String.Format(
          "{0} testLinkedListCycle({1}) => must be: {2}",
          test.title,
          test.llist,
          test.expected
        )
      );
    }
  }
}
