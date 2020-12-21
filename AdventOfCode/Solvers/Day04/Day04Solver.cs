using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
      Regex hclRegex = new Regex("\\A\\#[0-9|a-f]{6}\\Z");
      Regex eclRegex = new Regex("\\A(?:amb|blu|brn|gry|grn|hzl|oth)\\Z");
      Regex pidRegex = new Regex("\\A\\d{9}\\Z");

      var criterias = new List<Func<IDictionary<string, string>, bool>> 
      {
        ValidateBYR,
        ValidateIYR,
        ValidateEYR,
        ValidateHGT,
        (passport) => ValidateHCL(passport, hclRegex),
        (passport) => ValidateECL(passport, eclRegex),
        (passport) => ValidatePID(passport, pidRegex)
      };

      return CountValidPassports(input, criterias).ToString();
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

    private bool ValidateBYR(IDictionary<string, string> passport)
    {
      return passport.TryGetValue("byr", out string val)
        && val.Length == 4
        && Int32.TryParse(val, out int byr)
        && byr >= 1920
        && byr <= 2002;
    }

    private bool ValidateIYR(IDictionary<string, string> passport)
    {
      return passport.TryGetValue("iyr", out string val)
        && val.Length == 4
        && Int32.TryParse(val, out int iyr)
        && iyr >= 2010
        && iyr <= 2020;
    }

    private bool ValidateEYR(IDictionary<string, string> passport)
    {
      return passport.TryGetValue("eyr", out string val)
        && val.Length == 4
        && Int32.TryParse(val, out int eyr)
        && eyr >= 2020
        && eyr <= 2030;
    }

    private bool ValidateHGT(IDictionary<string, string> passport)
    {
      bool valid = false;
      if (passport.TryGetValue("hgt", out string val))
      {
        int hgt = -1;
        int cmIndex = val.IndexOf("cm");
        int inIndex = val.IndexOf("in");
        if (cmIndex > 0 && Int32.TryParse(val.Substring(0, cmIndex), out hgt))
        {
          valid = 150 <= hgt && hgt <= 193;
        }
        else if (inIndex > 0 && Int32.TryParse(val.Substring(0, inIndex), out hgt))
        {
          valid = 59 <= hgt && hgt <= 76;
        }
      }

      return valid;
    }

    private bool ValidateHCL(IDictionary<string, string> passport, Regex hclRegex)
    {
      return passport.TryGetValue("hcl", out string val)
        && val.Length == 7
        && hclRegex.IsMatch(val);
    }

    private bool ValidateECL(IDictionary<string, string> passport, Regex eclRegex)
    {
      return passport.TryGetValue("ecl", out string val)
        && val.Length == 3
        && eclRegex.IsMatch(val);
    }

    private bool ValidatePID(IDictionary<string, string> passport, Regex pidRegex)
    {
      return passport.TryGetValue("pid", out string val)
        && val.Length == 9
        && pidRegex.IsMatch(val);
    }
  }
}
