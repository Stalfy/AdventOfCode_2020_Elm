using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using AdventOfCode.Solvers;
using AdventOfCode.Solvers.Day11;

namespace AdventOfCode.Tests.Solvers.Day11
{
  [TestClass]
  public class Day11SolverUnit
  {
    [TestMethod]
    public void TestSolvePartA()
    {
      Solver s = new Day11Solver();
      IEnumerable<string> input = new List<string>
      {
        "L.LL.LL.LL",
        "LLLLLLL.LL",
        "L.L.L..L..",
        "LLLL.LL.LL",
        "L.LL.LL.LL",
        "L.LLLLL.LL",
        "..L.L.....",
        "LLLLLLLLLL",
        "L.LLLLLL.L",
        "L.LLLLL.LL "
      };

      Assert.AreEqual("37", s.SolvePartA(input));
    }

    [TestMethod]
    public void TestSolvePartB()
    {
      Solver s = new Day11Solver();
      IEnumerable<string> input = new List<string>
      {
        "L.LL.LL.LL",
        "LLLLLLL.LL",
        "L.L.L..L..",
        "LLLL.LL.LL",
        "L.LL.LL.LL",
        "L.LLLLL.LL",
        "..L.L.....",
        "LLLLLLLLLL",
        "L.LLLLLL.L",
        "L.LLLLL.LL "
      };

      Assert.AreEqual("26", s.SolvePartB(input));
    }
  }
}
