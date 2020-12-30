using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using AdventOfCode.Solvers;
using AdventOfCode.Solvers.Day09;

namespace AdventOfCode.Tests.Solvers.Day09
{
  [TestClass]
  public class Day09SolverUnit
  {
    [TestMethod]
    public void TestSolvePartA()
    {
      Day09Solver s = new Day09Solver();
      IEnumerable<string> input = new List<string>
      {
        "35",
        "20",
        "15",
        "25",
        "47",
        "40",
        "62",
        "55",
        "65",
        "95",
        "102",
        "117",
        "150",
        "182",
        "127",
        "219",
        "299",
        "277",
        "309",
        "576"
      };

      Assert.AreEqual("127", s.SolvePartA(input, 5, 5));
    }

    [TestMethod]
    public void TestSolvePartB()
    {
      Day09Solver s = new Day09Solver();
      IEnumerable<string> input = new List<string>
      {
        "35",
        "20",
        "15",
        "25",
        "47",
        "40",
        "62",
        "55",
        "65",
        "95",
        "102",
        "117",
        "150",
        "182",
        "127",
        "219",
        "299",
        "277",
        "309",
        "576"
      };

      Assert.AreEqual("62", s.SolvePartB(input, 127));
    }
  }
}
