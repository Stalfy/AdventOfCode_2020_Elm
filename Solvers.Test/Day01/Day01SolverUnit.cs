using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using Solvers;

namespace Solvers.Test
{
  [TestClass]
  public class Day01SolverUnit
  {
    [TestMethod]
    public void TestSolvePartA()
    {
      Solver s = new Day01Solver();
      IEnumerable<string> input = new List<string>();
      Assert.AreEqual("A", s.SolvePartA(input));
    }

    [TestMethod]
    public void TestSolvePartB()
    {
      Solver s = new Day01Solver();
      IEnumerable<string> input = new List<string>();
      Assert.AreEqual("B", s.SolvePartB(input));
    }
  }
}
