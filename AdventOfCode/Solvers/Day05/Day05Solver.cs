using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solvers.Day05
{
  public class Day05Solver : Solver
  {
    public string SolvePartA(IEnumerable<string> input)
    {
      IEnumerable<int> seatIds = GetSeatIds(input);
      return seatIds.Max().ToString();
    }

    public string SolvePartB(IEnumerable<string> input)
    {
      HashSet<int> seenIds = new HashSet<int>();
      foreach (int seatId in GetSeatIds(input))
      {
        seenIds.Add(seatId);
      }

      int seat = 1 + seenIds
        .FirstOrDefault(i => !seenIds.Contains(i + 1) && seenIds.Contains(i + 2));

      return seat.ToString();
    }

    private IEnumerable<int> GetSeatIds(IEnumerable<string> input)
    {
      Regex regex = new Regex("\\A([B|F]{7})([L|R]{3})\\Z");
      return input
        .Select(line => regex.Match(line))
        .Where(match => match.Success)
        .Select(ParseBoardingPass)
        .Select(tuple => tuple.Item1 * 8 + tuple.Item2);
    }

    private Tuple<int, int> ParseBoardingPass(Match match)
    {
      int row = ParseBoardingPassPart(match.Groups[1].Value, 'B', 'F');
      int col = ParseBoardingPassPart(match.Groups[2].Value, 'R', 'L');
      return Tuple.Create(row, col);
    }

    private int ParseBoardingPassPart(string part, char higherChar, char lowerChar)
    {
      int low = 0;
      int high = (1 << part.Length) - 1;
      int middle = (high - low) / 2;

      foreach (char c in part)
      {
        if (c == higherChar)
        {
          low = middle + 1;
        }
        else if (c == lowerChar)
        {
          high = middle;
        }

        middle = low + ((high - low) / 2);
      }
      
      return middle;
    }
  }
}
