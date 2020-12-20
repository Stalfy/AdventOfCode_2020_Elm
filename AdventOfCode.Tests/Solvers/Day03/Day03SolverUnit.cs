using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using AdventOfCode.Solvers;
using AdventOfCode.Solvers.Day03;

namespace AdventOfCode.Tests.Solvers.Day03
{
  [TestClass]
  public class Day03SolverUnit
  {
    [TestMethod]
    public void TestSolvePartA()
    {
      Solver s = new Day03Solver();
      IEnumerable<string> input = new List<string>
      {
        "..##.......",
        "#...#...#..",
        ".#....#..#.",
        "..#.#...#.#",
        ".#...##..#.",
        "..#.##.....",
        ".#.#.#....#",
        ".#........#",
        "#.##...#...",
        "#...##....#",
        ".#..#...#.#",
      };

      Assert.AreEqual("7", s.SolvePartA(input));
    }

    [TestMethod]
    public void TestSolvePartB()
    {
      Solver s = new Day03Solver();
      IEnumerable<string> input = new List<string>
      {
        "..##.......",
        "#...#...#..",
        ".#....#..#.",
        "..#.#...#.#",
        ".#...##..#.",
        "..#.##.....",
        ".#.#.#....#",
        ".#........#",
        "#.##...#...",
        "#...##....#",
        ".#..#...#.#",
      };

      Assert.AreEqual("336", s.SolvePartB(input));
    }
  }
}
