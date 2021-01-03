using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day11
{
  public class Day11Solver : Solver
  {
    private const char UsedSeat = '#';
    private const char FreeSeat = 'L';

    public string SolvePartA(IEnumerable<string> input)
    {
      var seatsMap = GetSeatsMap(input);
      Stabilize(seatsMap, GetPart1Modifications);
      return seatsMap.Values.Count(c => c == UsedSeat).ToString();
    }

    public string SolvePartB(IEnumerable<string> input)
    {
      var seatsMap = GetSeatsMap(input);
      Stabilize(seatsMap, GetPart2Modifications);
      return seatsMap.Values.Count(c => c == UsedSeat).ToString();
    }

    private SeatsMap GetSeatsMap(IEnumerable<string> input)
    {
      SeatsMap sm = new SeatsMap();

      int row = 0;
      foreach (var line in input)
      {
        int col = 0;
        foreach (var c in line)
        {
          if (c == FreeSeat)
          {
            sm[row, col] = c;
          }

          col++;
        }

        row++;
      }

      return sm;
    }

    private void Stabilize
      ( SeatsMap sm
        , Func<SeatsMap, IEnumerable<Tuple<Tuple<int, int>, char>>> getModifications)
    {
      bool iterate = true;
      while (iterate)
      {
        var modifications = getModifications(sm).ToList();

        iterate = modifications.Any();
        foreach (var tuple in modifications)
        {
          sm[tuple.Item1] = tuple.Item2;
        }
      }
    }

    private IEnumerable<Tuple<Tuple<int, int>, char>> GetPart1Modifications(SeatsMap sm)
    {
      foreach (Tuple<int, int> seat in sm.Keys)
      {
        switch (sm[seat])
        {
          case FreeSeat when GetSurroundingSeats(sm, seat).All(seat => sm[seat] == FreeSeat):
            yield return Tuple.Create(seat, UsedSeat);
            break;
          case UsedSeat when GetSurroundingSeats(sm, seat).Count(seat => sm[seat] == UsedSeat) >= 4:
            yield return Tuple.Create(seat, FreeSeat);
            break;
        }
      }
    }

    private IEnumerable<Tuple<int, int>> GetSurroundingSeats(SeatsMap sm, Tuple<int, int> seat)
    {
      for (int row = seat.Item1 - 1; row <= seat.Item1 + 1; row++)
      {
        for (int col = seat.Item2 - 1; col <= seat.Item2 + 1; col++)
        {
          if ((row != seat.Item1 || col != seat.Item2) && sm.ContainsKey(row, col))
          {
            yield return Tuple.Create(row, col);
          }
        }
      }
    }

    private IEnumerable<Tuple<Tuple<int, int>, char>> GetPart2Modifications(SeatsMap sm)
    {
      foreach (Tuple<int, int> seat in sm.Keys)
      {
        switch (sm[seat])
        {
          case FreeSeat when GetAlignedSeats(sm, seat).All(seat => sm[seat] == FreeSeat):
            yield return Tuple.Create(seat, UsedSeat);
            break;
          case UsedSeat when GetAlignedSeats(sm, seat).Count(seat => sm[seat] == UsedSeat) >= 5:
            yield return Tuple.Create(seat, FreeSeat);
            break;
        }
      }
    }

    private IEnumerable<Tuple<int, int>> GetAlignedSeats(SeatsMap sm, Tuple<int, int> seat)
    {
      int maxRow = 0;
      int minRow = int.MaxValue;
      int maxCol = 0;
      int minCol = int.MaxValue;

      foreach (var s in sm.Keys)
      {
        if (s.Item1 > maxRow) maxRow = s.Item1;
        if (s.Item1 < minRow) minRow = s.Item1;
        if (s.Item2 > maxCol) maxCol = s.Item2;
        if (s.Item2 < minCol) minCol = s.Item2;
      }

      // Right.
      bool stop = false;
      int row = seat.Item1;
      int col = seat.Item2;
      while (col < maxCol && !stop)
      {
        var alignedSeat = Tuple.Create(row, ++col);
        if (sm.ContainsKey(alignedSeat))
        {
          stop = true;
          yield return alignedSeat;
        }
      }

      // Top Right.
      stop = false;
      row = seat.Item1;
      col = seat.Item2;
      while (col < maxCol && row > minRow && !stop)
      {
        var alignedSeat = Tuple.Create(--row, ++col);
        if (sm.ContainsKey(alignedSeat))
        {
          stop = true;
          yield return alignedSeat;
        }
      }
      
      // Top.
      stop = false;
      row = seat.Item1;
      col = seat.Item2;
      while (row > minRow && !stop)
      {
        var alignedSeat = Tuple.Create(--row, col);
        if (sm.ContainsKey(alignedSeat))
        {
          stop = true;
          yield return alignedSeat;
        }
      }
      
      // Top Left.
      stop = false;
      row = seat.Item1;
      col = seat.Item2;
      while (col > minCol && row > minRow && !stop)
      {
        var alignedSeat = Tuple.Create(--row, --col);
        if (sm.ContainsKey(alignedSeat))
        {
          stop = true;
          yield return alignedSeat;
        }
      }

      // Left.
      stop = false;
      row = seat.Item1;
      col = seat.Item2;
      while (col > minCol && !stop)
      {
        var alignedSeat = Tuple.Create(row, --col);
        if (sm.ContainsKey(alignedSeat))
        {
          stop = true;
          yield return alignedSeat;
        }
      }

      // Bottom Left.
      stop = false;
      row = seat.Item1;
      col = seat.Item2;
      while (col > minCol && row < maxRow && !stop)
      {
        var alignedSeat = Tuple.Create(++row, --col);
        if (sm.ContainsKey(alignedSeat))
        {
          stop = true;
          yield return alignedSeat;
        }
      }

      // Bottom.
      stop = false;
      row = seat.Item1;
      col = seat.Item2;
      while (row < maxRow && !stop)
      {
        var alignedSeat = Tuple.Create(++row, col);
        if (sm.ContainsKey(alignedSeat))
        {
          stop = true;
          yield return alignedSeat;
        }
      }

      // Bottom Right.
      stop = false;
      row = seat.Item1;
      col = seat.Item2;
      while (col < maxCol && row < maxRow && !stop)
      {
        var alignedSeat = Tuple.Create(++row, ++col);
        if (sm.ContainsKey(alignedSeat))
        {
          stop = true;
          yield return alignedSeat;
        }
      }
    }

    private class SeatsMap
    {
      private Dictionary<Tuple<int, int>, char> Data { get; set; }

      public char this[int row, int col]
      {
        get => Data[GetKey(row, col)];
        set => Data[GetKey(row, col)] = value;
      }

      public char this[Tuple<int, int> key]
      {
        get => Data[key];
        set => Data[key] = value;
      }

      public IEnumerable<Tuple<int, int>> Keys => Data.Keys;
      public IEnumerable<char> Values => Data.Values;

      public SeatsMap()
      {
        Data = new Dictionary<Tuple<int, int>, char>();
      }

      private Tuple<int, int> GetKey(int row, int col) => Tuple.Create(row, col);

      public bool ContainsKey(int row, int col) => Data.ContainsKey(GetKey(row, col));
      public bool ContainsKey(Tuple<int, int> key) => Data.ContainsKey(key);
    }
  }
}
