using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solvers.Day02
{
  public class Day02Solver : Solver
  {
    public string SolvePartA(IEnumerable<string> input)
    {
      string pattern = "^(\\d+)-(\\d+) (\\w{1}): (\\w+)$";
      Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

      return input
        .Select(line => regex.Match(line))
        .Where(match => match.Success)
        .Select(match => ParseMatchEntry(match))
        .Count(IsValidEntry)
        .ToString();
    }

    public string SolvePartB(IEnumerable<string> input)
    {
      return "B";
    }

    private Entry ParseMatchEntry(Match match)
    {
      return new Entry
      {
        Password = match.Groups[4].ToString(),
        Policy = new CorporatePolicy
        {
          MinOccurences = Int32.Parse(match.Groups[1].Value),
          MaxOccurences = Int32.Parse(match.Groups[2].Value),
          RequiredCharacter = match.Groups[3].Value
        }
      };
    }

    private bool IsValidEntry(Entry entry)
    {
      int reducedLength = entry
        .Password
        .Replace(entry.Policy.RequiredCharacter, "")
        .Length;

      int occurences = entry.Password.Length - reducedLength;
      return entry.Policy.MinOccurences <= occurences
        && entry.Policy.MaxOccurences >= occurences;
    }
  }
}
