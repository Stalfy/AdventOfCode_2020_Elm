using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using AdventOfCode.Solvers;
using AdventOfCode.Solvers.Day01;

namespace AdventOfCode.Tests.Solvers.Day01
{
  [TestClass]
  public class Day01SolverUnit
  {
    [TestMethod]
    public void TestSolvePartA()
    {
      Solver s = new Day01Solver();
      IEnumerable<string> input = new List<string>
      {
        "1721",
        "979",
        "366",
        "299",
        "675",
        "1456"
      };

      Assert.AreEqual("514579", s.SolvePartA(input));
    }

    [TestMethod]
    public void TestSolvePartB()
    {
      Solver s = new Day01Solver();
      IEnumerable<string> input = new List<string>
      {
        "1721",
        "979",
        "366",
        "299",
        "675",
        "1456"
      };

      Assert.AreEqual("241861950", s.SolvePartB(input));
    }
  }
}
