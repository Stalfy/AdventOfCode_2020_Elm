using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using AdventOfCode.Solvers.Day09;

namespace AdventOfCode.Tests.Solvers.Day09
{
  [TestClass]
  public class SumsCheckerUnit
  {
    [TestMethod]
    public void TestContains()
    {
      SumsChecker tested = new SumsChecker(5);
      tested.AddNumber(1);
      tested.AddNumber(2);
      tested.AddNumber(3);
      tested.AddNumber(4);
      tested.AddNumber(5);
      tested.AddNumber(6);
      Assert.IsFalse(tested.Contains(1));
      Assert.IsFalse(tested.Contains(2));
      Assert.IsFalse(tested.Contains(3));
      Assert.IsFalse(tested.Contains(4));
      Assert.IsTrue(tested.Contains(5));
      Assert.IsTrue(tested.Contains(6));
      Assert.IsTrue(tested.Contains(7));
      Assert.IsTrue(tested.Contains(8));
      Assert.IsTrue(tested.Contains(9));
      Assert.IsTrue(tested.Contains(10));
      Assert.IsTrue(tested.Contains(11));
      Assert.IsFalse(tested.Contains(12));
    }
  }
}
