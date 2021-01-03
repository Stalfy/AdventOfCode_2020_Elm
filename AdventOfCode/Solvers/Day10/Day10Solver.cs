using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day10
{
  public class Day10Solver : Solver
  {
    public string SolvePartA(IEnumerable<string> input)
    {
      var differences = new Dictionary<int, int>();
      int previousJoltage = 0;

      foreach (var joltage in GetOrderedJoltages(input))
      {
        int difference = joltage - previousJoltage;
        if (differences.ContainsKey(difference))
        {
          differences[difference]++;
        }
        else
        {
          differences[difference] = 1;
        }

        previousJoltage = joltage;
      }

      // The final difference is always 3.
      return (differences[1] * (1 + differences[3])).ToString();
    }

    public string SolvePartB(IEnumerable<string> input)
    {
      return CountPermutations(GetOrderedJoltages(input)).ToString();
    }

    private IOrderedEnumerable<int> GetOrderedJoltages(IEnumerable<string> input)
    {
      return input
        .Select<string, int?>(line => int.TryParse(line, out var v) ? v : null)
        .Where(maybeInt => maybeInt.HasValue)
        .Select(maybeInt => maybeInt.Value)
        .OrderBy(joltage => joltage);
    }

    private ulong CountPermutations(IOrderedEnumerable<int> orderedJoltages)
    {
      // Paths leading to the specified key.
      Dictionary<ulong, ulong> possibilities = new Dictionary<ulong, ulong>();
      possibilities[0] = 1;

      ulong permutations = 0;
      foreach(var t in GetTuples(orderedJoltages))
      {
        // Aggregate all possible paths leading to the target (Item1) key.
        possibilities[t.Item1] = t.Item2
          .Where(joltage => t.Item1 - joltage <= 3)
          .Aggregate<ulong, ulong>(0, (acc, joltage) => acc += possibilities[joltage]);

        // Save the last aggregation.
        permutations = possibilities[t.Item1];
      }

      return permutations;
    }

    private IEnumerable<Tuple<ulong, IEnumerable<ulong>>> GetTuples(IOrderedEnumerable<int> joltages)
    {
      Queue<ulong> queue = new Queue<ulong>(3);
      queue.Enqueue(0);

      foreach (ulong joltage in joltages.Select<int, ulong>(i => Convert.ToUInt64(i)))
      {
        yield return Tuple.Create(joltage, queue as IEnumerable<ulong>);
        if (queue.Count == 3)
        {
          queue.Dequeue();
        }

        queue.Enqueue(joltage);
      }
    }
  }
}
