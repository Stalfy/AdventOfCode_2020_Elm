using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day03
{
  public class Day03Solver : Solver
  {
    public string SolvePartA(IEnumerable<string> input)
    {
      return CountTreeCollisions(ParseInput(input), 3, 1).ToString();
    }

    public string SolvePartB(IEnumerable<string> input)
    {
      var tuple = ParseInput(input);

      return new List<Tuple<int, int>>
      {
        Tuple.Create(1, 1),
        Tuple.Create(3, 1),
        Tuple.Create(5, 1),
        Tuple.Create(7, 1),
        Tuple.Create(1, 2)
      }
      .Select(slope => CountTreeCollisions(tuple, slope.Item1, slope.Item2))
      .Aggregate<int, int>(1, (total, next) => total = total * next)
      .ToString();
    }

    private string CreateCoordinate(int x, int y) => $"{x},{y}";

    private Tuple<HashSet<string>, int, int> ParseInput(IEnumerable<string> input)
    {
      HashSet<string> treeCoordinates = new HashSet<string>();
      int rowLength = 0;
      int rowCount = 0;

      foreach (string s in input)
      {
        rowLength = s.Length;

        for (int i = 0; i < s.Length; i++)
        {
          if (s[i] == '#')
          {
            treeCoordinates.Add(CreateCoordinate(i, rowCount));
          }
        }
            
        rowCount++;
      }

      return Tuple.Create(treeCoordinates, rowLength, rowCount);
    }

    private int CountTreeCollisions(Tuple<HashSet<string>, int, int> tuple, int xStep, int yStep)
    {
      int x = 0;
      int y = 0;
      int collisions = 0;

      while (y < tuple.Item3)
      {
        x = (x + xStep) % tuple.Item2;
        y += yStep;

        collisions += tuple.Item1.Contains(CreateCoordinate(x, y)) ? 1 : 0;
      }

      return collisions;
    }
  }
}
