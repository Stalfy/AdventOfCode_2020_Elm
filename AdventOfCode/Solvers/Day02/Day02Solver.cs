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
        .Count(IsValidCharacterCount)
        .ToString();
    }

    public string SolvePartB(IEnumerable<string> input)
    {
      string pattern = "^(\\d+)-(\\d+) (\\w{1}): (\\w+)$";
      Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

      return input
        .Select(line => regex.Match(line))
        .Where(match => match.Success)
        .Select(match => ParseMatchEntry(match))
        .Count(IsSingleMatchingCharacter)
        .ToString();
    }

    private Entry ParseMatchEntry(Match match)
    {
      return new Entry
      {
        Password = match.Groups[4].ToString(),
        Policy = new CorporatePolicy
        {
          MinIndex = Int32.Parse(match.Groups[1].Value),
          MaxIndex = Int32.Parse(match.Groups[2].Value),
          RequiredCharacter = match.Groups[3].Value
        }
      };
    }

    private bool IsValidCharacterCount(Entry entry)
    {
      int reducedLength = entry
        .Password
        .Replace(entry.Policy.RequiredCharacter, "")
        .Length;

      int occurences = entry.Password.Length - reducedLength;
      return entry.Policy.MinIndex <= occurences
        && entry.Policy.MaxIndex >= occurences;
    }

    private bool IsSingleMatchingCharacter(Entry entry)
    {
      char target = entry.Policy.RequiredCharacter[0];
      char a = entry.Password[entry.Policy.MinIndex - 1];
      char b = entry.Password[entry.Policy.MaxIndex - 1];

      return (a == target) ^ (b == target);
    }
  }
}
