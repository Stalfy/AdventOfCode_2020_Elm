using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using AdventOfCode.Solvers;
using AdventOfCode.Solvers.Day05;

namespace AdventOfCode.Tests.Solvers.Day05
{
  [TestClass]
  public class Day05SolverUnit
  {
    [TestMethod]
    public void TestSolvePartA()
    {
      Solver s = new Day05Solver();
      IEnumerable<string> input = new List<string>
      {
        "BFFFBBFRRR",
        "FFFBBBFRRR",
        "BBFFBBFRLL"
      };

      Assert.AreEqual("820", s.SolvePartA(input));
    }

    [TestMethod]
    public void TestSolvePartB()
    {
      // No Tests provided.
    }
  }
}
