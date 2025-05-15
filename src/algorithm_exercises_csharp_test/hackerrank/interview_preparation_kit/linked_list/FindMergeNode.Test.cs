namespace algorithm_exercises_csharp_test.hackerrank.interview_preparation_kit.linked_list;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.linked_list;
using algorithm_exercises_csharp.hackerrank.interview_preparation_kit.linked_list.common;

[TestClass]
public class FindMergeNodeTest
{
  private sealed class FindMergeNodeTestCase()
  {
    public string title = "";
    public LinkedList<int>.Node llist1 = new(0);
    public LinkedList<int>.Node llist2 = new(0);
    public int expected;
  }

  private static FindMergeNodeTestCase[] tests = [];

  [TestInitialize]
  public void testInitialize()
  {
    // Test Case 0
    //
    //  1
    //   \
    //    2--->3--->NULL
    //   /
    //  1
    //
    LinkedList<int>.Node tc0_ll1_1 = new(1);
    LinkedList<int>.Node tc0_ll1_2 = new(2);
    LinkedList<int>.Node tc0_ll1_3 = new(3);
    tc0_ll1_1.next = tc0_ll1_2;
    tc0_ll1_2.next = tc0_ll1_3;

    LinkedList<int>.Node tc0_ll2_1 = new(1);
    tc0_ll2_1.next = tc0_ll1_2;

    // Test Case 1
    //
    // 1--->2
    //       \
    //        3--->Null
    //       /
    //      1
    //
    LinkedList<int>.Node tc1_ll1_1 = new(1);
    LinkedList<int>.Node tc1_ll1_2 = new(2);
    LinkedList<int>.Node tc1_ll1_3 = new(3);
    tc1_ll1_1.next = tc1_ll1_2;
    tc1_ll1_2.next = tc1_ll1_3;

    LinkedList<int>.Node tc1_ll2_1 = new(1);
    tc1_ll2_1.next = tc1_ll1_3;

    tests = [
      new()
      {
        title = "Sample Test case 0",
        llist1 = tc0_ll1_1,
        llist2 = tc0_ll2_1,
        expected = 2
      },
      new()
      {
        title = "Sample Test case 1",
        llist1 = tc1_ll1_1,
        llist2 = tc1_ll2_1,
        expected = 3
      }
    ];
  }

  [TestMethod]
  public void testLinkedListCycle()
  {
    int? result;

    foreach (FindMergeNodeTestCase test in tests)
    {
      result = FindMergeNode.findMergeNode(test.llist1, test.llist2);
      Assert.AreEqual(
        test.expected,
        result,
        string.Format(
          System.Globalization.CultureInfo.InvariantCulture,
          "{0} findMergeNode({1}, {2}) => must be: {3}",
          test.title,
          test.llist1,
          test.llist2,
          test.expected
        )
      );
    }
  }
}
