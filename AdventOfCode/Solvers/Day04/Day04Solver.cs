using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day04
{
  public class Day04Solver : Solver
  {
    public string SolvePartA(IEnumerable<string> input)
    {
      List<string> requiredFields = new List<string> 
      { 
        "byr", 
        "iyr",
        "eyr",
        "hgt",
        "hcl",
        "ecl",
        "pid"
      };

      var criterias = new List<Func<IDictionary<string, string>, bool>> 
      {
        (passport) => ContainsRequiredFields(passport, requiredFields)
      };

      return CountValidPassports(input, criterias).ToString();
    }

    public string SolvePartB(IEnumerable<string> input)
    {
      return "B";
    }

    private int CountValidPassports
      (IEnumerable<string> input
      , IEnumerable<Func<IDictionary<string, string>, bool>> criterias)
    {
      var validators = criterias.ToList();
      return CreatePassports(input)
        .Count(passport => validators.All(v => v(passport)));
    }

    private IEnumerable<IDictionary<string, string>> CreatePassports(IEnumerable<string> input)
    {
      IDictionary<string, string> passport = new Dictionary<string, string>();
      char[] splitters = new char[] { ' ', ':' };
      foreach(string s in input)
      {
        if (s.Length == 0)
        {
          yield return passport;
          passport.Clear();
        }
        else
        {
          string[] splits = s.Split(splitters);
          for (int i = 0; i < splits.Length; i += 2)
          {
            passport[splits[i]] = splits[i + 1];
          }
        }
      }

      // Return the final passport.
      yield return passport;
    }

    private bool ContainsRequiredFields
      (IDictionary<string, string> passport
      , IEnumerable<string> requiredFields)
    {
      return requiredFields.All(key => passport.ContainsKey(key));
    }
  }
}
