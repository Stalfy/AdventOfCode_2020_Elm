using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solvers.Day09
{
  public class SumsChecker
  {
    private List<Tuple<long, HashSet<long>>> Sums { get; set; }

    public SumsChecker(int capacity)
    {
      Sums = new List<Tuple<long, HashSet<long>>>(capacity);
    }

    public void AddNumber(long number)
    {
      if (Sums.Count == Sums.Capacity)
      {
        Sums.RemoveAt(0);
      }

      foreach (var tuple in Sums)
      {
        tuple.Item2.Add(tuple.Item1 + number);
      }

      Sums.Add(Tuple.Create(number, new HashSet<long>(Sums.Capacity)));
    }

    public bool Contains(long sum)
    {
      return Sums.Any(tuple => tuple.Item2.Contains(sum));
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var tuple in Sums)
      {
        sb.Append($"{tuple.Item1} ->");
        foreach (long sum in tuple.Item2)
        {
          sb.Append($" {sum}");
        }

        sb.AppendLine("");
      }

      return sb.ToString();
    }
  }
}
