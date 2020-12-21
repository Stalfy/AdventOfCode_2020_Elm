using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using AdventOfCode.Solvers;
using AdventOfCode.Solvers.Day04;

namespace AdventOfCode.Tests.Solvers.Day04
{
  [TestClass]
  public class Day04SolverUnit
  {
    [TestMethod]
    public void TestSolvePartA()
    {
      Solver s = new Day04Solver();
      IEnumerable<string> input = new List<string>
      {
        "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
        "byr:1937 iyr:2017 cid:147 hgt:183cm",
        "",
        "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
        "hcl:#cfa07d byr:1929",
        "",
        "hcl:#ae17e1 iyr:2013",
        "eyr:2024",
        "ecl:brn pid:760753108 byr:1931",
        "hgt:179cm",
        "",
        "hcl:#cfa07d eyr:2025 pid:166559648",
        "iyr:2011 ecl:brn hgt:59in"
      };

      Assert.AreEqual("2", s.SolvePartA(input));
    }

    [TestMethod]
    public void TestSolvePartB()
    {
      Solver s = new Day04Solver();
      IEnumerable<string> input = new List<string>();
      Assert.AreEqual("B", s.SolvePartB(input));
    }
  }
}
