using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using AdventOfCode.Solvers;
using AdventOfCode.Solvers.Day06;

namespace AdventOfCode.Tests.Solvers.Day06
{
  [TestClass]
  public class Day06SolverUnit
  {
    [TestMethod]
    public void TestSolvePartA()
    {
      Solver s = new Day06Solver();
      IEnumerable<string> input = new List<string>
      {
        "abc",
        "",
        "a",
        "b",
        "c",
        "",
        "ab",
        "ac",
        "",
        "a",
        "a",
        "a",
        "a",
        "",
        "b",
      };

      Assert.AreEqual("11", s.SolvePartA(input));
    }

    [TestMethod]
    public void TestSolvePartB()
    {
      Solver s = new Day06Solver();
      IEnumerable<string> input = new List<string>
      {
        "abc",
        "",
        "a",
        "b",
        "c",
        "",
        "ab",
        "ac",
        "",
        "a",
        "a",
        "a",
        "a",
        "",
        "b",
      };
      Assert.AreEqual("6", s.SolvePartB(input));
    }
  }
}
