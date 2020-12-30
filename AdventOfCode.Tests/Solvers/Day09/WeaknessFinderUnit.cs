using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using AdventOfCode.Solvers.Day09;

namespace AdventOfCode.Tests.Solvers.Day09
{
  [TestClass]
  public class WeaknessFinderUnit
  {
    [TestMethod]
    public void TestFindWeaknessSet()
    {
      WeaknessFinder tested = new WeaknessFinder();

      List<long> numbers = new List<long> { 6, 5, 4, 3, 2, 1 };
      IEnumerable<long> values = tested.FindWeaknessSet(numbers, 15);
      HashSet<long> hs = new HashSet<long>(values);

      Assert.AreEqual(3, hs.Count);
      Assert.IsTrue(hs.Contains(6));
      Assert.IsTrue(hs.Contains(5));
      Assert.IsTrue(hs.Contains(4));
      Assert.IsFalse(hs.Contains(3));
      Assert.IsFalse(hs.Contains(2));
      Assert.IsFalse(hs.Contains(1));
    }
  }
}
