using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using AdventOfCode.Solvers;
using AdventOfCode.Solvers.Day10;

namespace AdventOfCode.Tests.Solvers.Day10
{
  [TestClass]
  public class Day10SolverUnit
  {
    [TestMethod]
    public void TestSolvePartA()
    {
      Solver s = new Day10Solver();
      IEnumerable<string> input = new List<string>
      {
        "28",
        "33",
        "18",
        "42",
        "31",
        "14",
        "46",
        "20",
        "48",
        "47",
        "24",
        "23",
        "49",
        "45",
        "19",
        "38",
        "39",
        "11",
        "1",
        "32",
        "25",
        "35",
        "8",
        "17",
        "7",
        "9",
        "4",
        "2",
        "34",
        "10",
        "3"
      };

      Assert.AreEqual("220", s.SolvePartA(input));
    }

    [TestMethod]
    public void TestSolvePartB()
    {
      Solver s = new Day10Solver();
      IEnumerable<string> input = new List<string>
      {
        "28",
        "33",
        "18",
        "42",
        "31",
        "14",
        "46",
        "20",
        "48",
        "47",
        "24",
        "23",
        "49",
        "45",
        "19",
        "38",
        "39",
        "11",
        "1",
        "32",
        "25",
        "35",
        "8",
        "17",
        "7",
        "9",
        "4",
        "2",
        "34",
        "10",
        "3"
      };

      Assert.AreEqual("19208", s.SolvePartB(input));
    }
  }
}
