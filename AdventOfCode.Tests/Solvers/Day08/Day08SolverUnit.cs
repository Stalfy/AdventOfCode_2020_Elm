using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using AdventOfCode.Solvers;
using AdventOfCode.Solvers.Day08;

namespace AdventOfCode.Tests.Solvers.Day08
{
  [TestClass]
  public class Day08SolverUnit
  {
    [TestMethod]
    public void TestSolvePartA()
    {
      Solver s = new Day08Solver();
      IEnumerable<string> input = new List<string>
      {
        "nop +0",
        "acc +1",
        "jmp +4",
        "acc +3",
        "jmp -3",
        "acc -99",
        "acc +1",
        "jmp -4",
        "acc +6"
      };

      Assert.AreEqual("5", s.SolvePartA(input));
    }

    [TestMethod]
    public void TestSolvePartB()
    {
      Solver s = new Day08Solver();
      IEnumerable<string> input = new List<string>
      {
        "nop +0",
        "acc +1",
        "jmp +4",
        "acc +3",
        "jmp -3",
        "acc -99",
        "acc +1",
        "jmp -4",
        "acc +6"
      };

      Assert.AreEqual("8", s.SolvePartB(input));
    }
  }
}
