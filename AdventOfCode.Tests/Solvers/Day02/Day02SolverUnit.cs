using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using AdventOfCode.Solvers;
using AdventOfCode.Solvers.Day02;

namespace AdventOfCode.Tests.Solvers.Day02
{
  [TestClass]
  public class Day02SolverUnit
  {
    [TestMethod]
    public void TestSolvePartA()
    {
      Solver s = new Day02Solver();
      IEnumerable<string> input = new List<string>
      {
        "1-3 a: abcde",
        "1-3 b: cdefg",
        "2-9 c: ccccccccc"
      };

      Assert.AreEqual("2", s.SolvePartA(input));
    }

    [TestMethod]
    public void TestSolvePartB()
    {
      Solver s = new Day02Solver();
      IEnumerable<string> input = new List<string>();
      Assert.AreEqual("B", s.SolvePartB(input));
    }
  }
}
