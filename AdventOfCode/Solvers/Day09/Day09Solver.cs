using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day09
{
  public class Day09Solver : Solver
  {
    public string SolvePartA(IEnumerable<string> input)
    {
      return SolvePartA(input, 25, 25);
    }

    public string SolvePartA(IEnumerable<string> input, int capacity, int preamble)
    {
      SumsChecker sc = new SumsChecker(capacity);

      IEnumerable<long> numbers = input
        .Select<string, long?>(line => long.TryParse(line, out long n) ? n : null)
        .Where(maybeInt => maybeInt.HasValue)
        .Select(maybeInt => maybeInt.Value);

      return FindInvalidNumber(numbers, sc, preamble).ToString();
    }

    public string SolvePartB(IEnumerable<string> input)
    {
      return SolvePartB(input, 675280050);
    }

    public string SolvePartB(IEnumerable<string> input, long invalidNumber)
    {
      string result = "Not Found.";

      IEnumerable<long> numbers = input
        .Select<string, long?>(line => long.TryParse(line, out long n) ? n : null)
        .Where(maybeInt => maybeInt.HasValue)
        .Select(maybeInt => maybeInt.Value);

      WeaknessFinder wf = new WeaknessFinder();
      if (wf.FindWeaknessSet(numbers, invalidNumber) is IEnumerable<long> ws)
      {
        long max = long.MinValue;
        long min = long.MaxValue;

        foreach (long n in ws)
        {
          if (max < n)
          {
            max = n;
          }

          if (min > n)
          {
            min = n;
          }
        }

        result = (min + max).ToString();
      }

      return result;
    }

    private long FindInvalidNumber(IEnumerable<long> numbers, SumsChecker checker, int preamble)
    {
      foreach (long n in numbers.Take(preamble))
      {
        checker.AddNumber(n);
      }

      foreach (long n in numbers.Skip(preamble))
      {
        if (!checker.Contains(n))
        {
          return n;
        }

        checker.AddNumber(n);
      }

      return -1;
    }
  }
}
