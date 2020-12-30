using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day09
{
  public class WeaknessFinder
  {
    private List<WeaknessSet> WeaknessSets { get; set; }

    public WeaknessFinder()
    {
      WeaknessSets = new List<WeaknessSet>();
    }

    public IEnumerable<long> FindWeaknessSet(IEnumerable<long> numbers, long target)
    {
      WeaknessSets.Clear();
      
      foreach (long n in numbers)
      {
        AddNumber(n);
        WeaknessSets.RemoveAll(ws => ws.Total > target);

        var weaknessSet = WeaknessSets
          .FirstOrDefault(ws => ws.Total == target && ws.Items.Count() >= 2);

        if (weaknessSet is WeaknessSet)
        {
          return weaknessSet.Items;
        }
      }

      return null;
    }

    private void AddNumber(long number)
    {
      WeaknessSets.Add(new WeaknessSet());
      foreach(var weaknessSet in WeaknessSets)
      {
        weaknessSet.Add(number);
      }
    }

    private class WeaknessSet
    {
      private List<long> items;

      public long Total { get; private set; }
      public IEnumerable<long> Items => items;

      public WeaknessSet()
      {
        Total = 0;
        items = new List<long>();
      }

      public void Add(long number)
      {
        Total += number;
        items.Add(number);
      }
    }
  }
}
