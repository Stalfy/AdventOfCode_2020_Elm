using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Solvers.Day11
{
  public class SeatsMap
  {
    private Dictionary<int, Dictionary<int, char>> Data { get; set; }

    public SeatsMap()
    {
      Data = new Dictionary<int, Dictionary<int, char>>();
    }

    public char this[int row, int col]
    {
      get => Data[row][col];
      set
      {
        if (!Data.ContainsKey(row))
        {
          Data[row] = new Dictionary<int, char>();
        }

        Data[row][col] = value;
      }
    }

    public char this[Tuple<int, int> key]
    {
      get => this[key.Item1, key.Item2];
      set => this[key.Item1, key.Item2] = value;
    }

    public IEnumerable<Tuple<int, int>> Seats
    {
      get
      { 
        return Data
          .SelectMany(row => 
          { 
            return row
              .Value
              .Keys
              .Select(colKey => Tuple.Create(row.Key, colKey));
          });
      }
    }

    public IEnumerable<char> Values
    {
      get => Data.SelectMany(row => row.Value.Values);
    }

    public bool ContainsKey(int row, int col)
    {
      return Data.ContainsKey(row) && Data[row].ContainsKey(col);
    }

    public bool ContainsKey(Tuple<int, int> key)
    {
      return ContainsKey(key.Item1, key.Item2);
    }
  }
}
