using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day06
{
  public class Day06Solver : Solver
  {
    public string SolvePartA(IEnumerable<string> input)
    {
      return GetGroupAnyoneAnswers(input)
        .Sum(hs => hs.Count)
        .ToString();
    }

    public string SolvePartB(IEnumerable<string> input)
    {
      return GetGroupEveryoneAnswers(input)
        .Sum(hs => hs.Count)
        .ToString();
    }

    public IEnumerable<HashSet<char>> GetGroupAnyoneAnswers(IEnumerable<string> input)
    {
      HashSet<char> hashset = new HashSet<char>(26);
      foreach(string line in input)
      {
        if (string.IsNullOrWhiteSpace(line))
        {
          if (hashset.Count > 0)
          {
            yield return hashset;
          }

          hashset.Clear();
        }
        else
        {
          foreach(char c in line)
          {
            hashset.Add(c);
          }
        }
      }

      // Yield final group.
      yield return hashset;
    }

    public IEnumerable<HashSet<char>> GetGroupEveryoneAnswers(IEnumerable<string> input)
    {
      HashSet<char> hashset = new HashSet<char>(26);
      hashset.UnionWith("abcdefghijklmnopqrstuvwxyz");
      foreach(string line in input)
      {
        if (string.IsNullOrWhiteSpace(line))
        {
          if (hashset.Count > 0)
          {
            yield return hashset;
          }

          hashset.UnionWith("abcdefghijklmnopqrstuvwxyz");
        }
        else
        {
          hashset.IntersectWith(line);
        }
      }

      // Yield final group.
      yield return hashset;
    }
  }
}
