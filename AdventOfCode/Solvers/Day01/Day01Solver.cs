using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Extensions;

namespace AdventOfCode.Solvers.Day01
{
  public class Day01Solver : Solver
  {
    public string SolvePartA(IEnumerable<string> input)
    {
      IEnumerable<int> numbers = input
        .Select(IntExtensions.ParseOrNull)
        .Where(maybeNumber => maybeNumber.HasValue)
        .Select(maybeNumber => maybeNumber.Value);

      Tuple<int, int> pair = CreatePairs(numbers)
        .FirstOrDefault(t => t.Item1 + t.Item2 == 2020);

      string result = "Pair not found";
      if (pair is Tuple<int, int>)
      {
        result = $"{pair.Item1 * pair.Item2}";
      }

      return result;
    }

    public string SolvePartB(IEnumerable<string> input)
    {
      IEnumerable<int> numbers = input
        .Select(IntExtensions.ParseOrNull)
        .Where(maybeNumber => maybeNumber.HasValue)
        .Select(maybeNumber => maybeNumber.Value);

      Tuple<int, int, int> triplet = CreateTriplets(numbers)
        .FirstOrDefault(t => t.Item1 + t.Item2 + t.Item3 == 2020);

      string result = "Triplet not found";
      if (triplet is Tuple<int, int, int>)
      {
        result = $"{triplet.Item1 * triplet.Item2 * triplet.Item3}";
      }

      return result;
    }

    public IEnumerable<Tuple<int, int>> CreatePairs(IEnumerable<int> numbers)
    {
      List<int> list = numbers.ToList();
      for(int i = 0; i < list.Count - 1; i++)
      {
        for (int j = i + 1; j < list.Count; j++)
        {
          yield return Tuple.Create(list[i], list[j]);
        }
      }
    }

    public IEnumerable<Tuple<int, int, int>> CreateTriplets(IEnumerable<int> numbers)
    {
      List<int> list = numbers.ToList();
      for(int i = 0; i < list.Count - 2; i++)
      {
        for (int j = i + 1; j < list.Count - 1; j++)
        {
          for (int k = i + 2; k < list.Count; k++)
          {
            yield return Tuple.Create(list[i], list[j], list[k]);
          }
        }
      }
    }
  }
}
