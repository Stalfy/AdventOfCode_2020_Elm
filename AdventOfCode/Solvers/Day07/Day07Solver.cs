using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solvers.Day07
{
  public class Day07Solver : Solver
  {
    public string SolvePartA(IEnumerable<string> input)
    {
      var bags = GetBags(input);
      return CountBagsContainingColor("shiny gold", bags).ToString();
    }

    public string SolvePartB(IEnumerable<string> input)
    {
      var bags = GetBags(input);
      return CountBagsInsideColor("shiny gold", bags).ToString();
    }

    private Dictionary<string, Dictionary<string, int>> GetBags(IEnumerable<string> input)
    {
      var bags = new Dictionary<string, Dictionary<string, int>>();

      Regex regex = new Regex("\\A(.*) bags contain "
        + "(?:no other bags\\."
        + "|"
        + "(?:(\\d+) ([\\w| ]+) bag[s]{0,1}(?:, |\\.))+?)\\Z");

      IEnumerable<Match> matches = input
        .Select(line => regex.Match(line))
        .Where(match => match.Success);
      
      foreach (Match match in matches)
      {
        Dictionary<string, int> contents = new Dictionary<string, int>();

        for (int i = 0; i < match.Groups[2].Captures.Count; i++)
        {
          string contentColor = match.Groups[3].Captures[i].Value;
          int.TryParse(match.Groups[2].Captures[i].Value, out int contentCount);
          contents[contentColor] = contentCount;
        }

        string color = match.Groups[1].Captures[0].Value;
        bags[color] = contents;
      }

      return bags;
    }
    
    private int CountBagsContainingColor
      ( string color
      , Dictionary<string, Dictionary<string, int>> bags)
    {
      var bagsContainingColor = new Dictionary<string, bool>();
      foreach (var bag in bags)
      {
        BagContainsColor(color, bag, bags, bagsContainingColor);
      }

      return bagsContainingColor.Count(kvp => kvp.Value);
    }

    private bool BagContainsColor
      ( string color
      , KeyValuePair<string, Dictionary<string, int>> bag
      , Dictionary<string, Dictionary<string, int>> bags
      , Dictionary<string, bool> bagsContainingColor)
    {
      if (bagsContainingColor.ContainsKey(bag.Key))
      {
        return bagsContainingColor[bag.Key];
      }
      else if (bag.Value.ContainsKey(color))
      {
        bagsContainingColor[bag.Key] = true;
        return true;
      }
      else
      {
        bool bagContainsColor = bag.Value.Any(content =>
        {
          var b = new KeyValuePair<string, Dictionary<string, int>>
            ( content.Key
            , bags[content.Key]);

          return BagContainsColor(color, b, bags, bagsContainingColor);
        });

        bagsContainingColor[bag.Key] = bagContainsColor;
        return bagContainsColor;
      }
    }

    private int CountBagsInsideColor
      ( string color
      , Dictionary<string, Dictionary<string, int>> bags)
    {
      var counts = new Dictionary<string, int>();
      var bag = new KeyValuePair<string, Dictionary<string, int>>
        ( color
        , bags[color]);

      return CountBagsInsideColor(color, bag, bags, counts);
    }

    private int CountBagsInsideColor
      ( string color
      , KeyValuePair<string, Dictionary<string, int>> bag
      , Dictionary<string, Dictionary<string, int>> bags
      , Dictionary<string, int> counts)
    {
      if (counts.ContainsKey(bag.Key))
      {
        return counts[bag.Key];
      }
      else
      {
        int bagsInsideColor = bag.Value
          .Where(content => content.Key != color)
          .Sum(content =>
          {
            var b = new KeyValuePair<string, Dictionary<string, int>>
              ( content.Key
              , bags[content.Key]);

            return content.Value
              + content.Value * CountBagsInsideColor(color, b, bags, counts);
          });

          counts[bag.Key] = bagsInsideColor;
          return bagsInsideColor;
      }
    }
  }
}
