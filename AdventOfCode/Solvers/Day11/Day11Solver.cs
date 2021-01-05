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
      Stabilize(seatsMap, GetImmediateSeatNeighborhoods, 4);
      return seatsMap.Values.Count(c => c == UsedSeat).ToString();
    }

    public string SolvePartB(IEnumerable<string> input)
    {
      var seatsMap = GetSeatsMap(input);
      Stabilize(seatsMap, GetClosestSeatNeighborhoods, 5);
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
      , Func<SeatsMap, IEnumerable<SeatNeighborhood>> getNeighborhoods
      , int maxUsedNeighbors)
    {
      bool iterate = true;

      List<SeatNeighborhood> neighborhoods = getNeighborhoods(sm).ToList();
      while (iterate)
      {
        var modifications = GetModifications(sm, neighborhoods, maxUsedNeighbors).ToList();
        iterate = modifications.Any();
        foreach (var tuple in modifications)
        {
          sm[tuple.Item1] = tuple.Item2;
        }
      }
    }

    private IEnumerable<Tuple<Tuple<int, int>, char>> GetModifications
      ( SeatsMap sm
      , IEnumerable<SeatNeighborhood> neighborhoods
      , int maxUsedNeighbors)
    {
      foreach (SeatNeighborhood sn in neighborhoods)
      {
        switch (sm[sn.Seat])
        {
          case FreeSeat when sn.Neighbors.All(seat => sm[seat] == FreeSeat):
            yield return Tuple.Create(sn.Seat, UsedSeat);
            break;
          case UsedSeat when sn.Neighbors.Count(seat => sm[seat] == UsedSeat) >= maxUsedNeighbors:
            yield return Tuple.Create(sn.Seat, FreeSeat);
            break;
        }
      }
    }

    private IEnumerable<SeatNeighborhood> GetImmediateSeatNeighborhoods(SeatsMap sm)
    {
      List<SeatNeighborhood> neighborhoods = new List<SeatNeighborhood>();
      foreach (Tuple<int, int> seat in sm.Seats)
      {
        // Unrolling the cases for all eight directions.
        SeatNeighborhood sn = new SeatNeighborhood(seat);

        Tuple<int, int> candidate = Tuple.Create(seat.Item1 - 1, seat.Item2 - 1);
        if (sm.ContainsKey(candidate))
        {
          sn.SetNeighbor(Direction.TopLeft, candidate);
        }

        candidate = Tuple.Create(seat.Item1 - 1, seat.Item2);
        if (sm.ContainsKey(candidate))
        {
          sn.SetNeighbor(Direction.Top, candidate);
        }

        candidate = Tuple.Create(seat.Item1 - 1, seat.Item2 + 1);
        if (sm.ContainsKey(candidate))
        {
          sn.SetNeighbor(Direction.TopRight, candidate);
        }

        candidate = Tuple.Create(seat.Item1, seat.Item2 + 1);
        if (sm.ContainsKey(candidate))
        {
          sn.SetNeighbor(Direction.Right, candidate);
        }

        candidate = Tuple.Create(seat.Item1 + 1, seat.Item2 + 1);
        if (sm.ContainsKey(candidate))
        {
          sn.SetNeighbor(Direction.BottomRight, candidate);
        }

        candidate = Tuple.Create(seat.Item1 + 1, seat.Item2);
        if (sm.ContainsKey(candidate))
        {
          sn.SetNeighbor(Direction.Bottom, candidate);
        }

        candidate = Tuple.Create(seat.Item1 + 1, seat.Item2 - 1);
        if (sm.ContainsKey(candidate))
        {
          sn.SetNeighbor(Direction.BottomLeft, candidate);
        }

        candidate = Tuple.Create(seat.Item1, seat.Item2 - 1);
        if (sm.ContainsKey(candidate))
        {
          sn.SetNeighbor(Direction.Left, candidate);
        }

        yield return sn;
      }
    }

    private IEnumerable<SeatNeighborhood> GetClosestSeatNeighborhoods(SeatsMap sm)
    {
      List<SeatNeighborhood> neighborhoods = new List<SeatNeighborhood>();
      foreach (Tuple<int, int> seat in sm.Seats)
      {
        SeatNeighborhood sn = new SeatNeighborhood(seat);
        foreach (SeatNeighborhood neighborhood in neighborhoods)
        {
          if (TryGetDirection(neighborhood.Seat, seat, out var direction))
          {
            Direction opposite = GetOppositeDirection(direction);
            Tuple<int, int> neighbor = neighborhood.GetNeighbor(direction);
            if (neighbor is Tuple<int, int>)
            {
              int neighborDist = GetManhattanDistance(neighbor, neighborhood.Seat);
              int seatDist = GetManhattanDistance(seat, neighborhood.Seat);
              if (seatDist < neighborDist)
              {
                neighborhood.SetNeighbor(direction, seat);
                sn.SetNeighbor(opposite, neighborhood.Seat);
              }
            }
            else
            {
              neighborhood.SetNeighbor(direction, seat);
              sn.SetNeighbor(opposite, neighborhood.Seat);
            }
          }
        }

        neighborhoods.Add(sn);
      }

      return neighborhoods;
    }

    private bool TryGetDirection(Tuple<int, int> seatA, Tuple<int, int> seatB, out Direction dir)
    {
      dir = Direction.Top;
      bool found = false;

      int drow = seatB.Item1 - seatA.Item1;
      int dcol = seatB.Item2 - seatA.Item2;
      if (drow == 0 && dcol != 0)
      {
        found = true;
        dir = dcol < 0 ? Direction.Left : Direction.Right;
      }
      else if (drow != 0 && dcol == 0)
      {
        found = true;
        dir = drow < 0 ? Direction.Top : Direction.Bottom;
      }
      else if (drow != 0 && dcol != 0 && (drow == dcol || drow == -dcol))
      {
        found = true;
        switch (drow < 0)
        {
          case true when dcol < 0:
            dir = Direction.TopLeft;
            break;
          case true when dcol > 0:
            dir = Direction.TopRight;
            break;
          case false when dcol < 0:
            dir = Direction.BottomLeft;
            break;
          case false when dcol > 0:
            dir = Direction.BottomRight;
            break;
        }
      }
      
      return found;
    }

    private Direction GetOppositeDirection(Direction direction)
    {
      switch(direction)
      {
        case Direction.Right:       return Direction.Left;
        case Direction.TopRight:    return Direction.BottomLeft;
        case Direction.Top:         return Direction.Bottom;
        case Direction.TopLeft:     return Direction.BottomRight;
        case Direction.Left:        return Direction.Right;
        case Direction.BottomLeft:  return Direction.TopRight;
        case Direction.Bottom:      return Direction.Top;
        case Direction.BottomRight: return Direction.TopLeft;
      }

      throw new Exception("Invalid direction.");
    }

    private int GetManhattanDistance(Tuple<int, int> seatA, Tuple<int, int> seatB)
    {
      return Math.Abs(seatA.Item1 - seatB.Item1) + Math.Abs(seatA.Item2 - seatB.Item2);
    }

    private class SeatNeighborhood
    {
      private Dictionary<Direction, Tuple<int, int>> Neighborhood { get; set; }

      public Tuple<int, int> Seat { get; }
      public IEnumerable<Tuple<int, int>> Neighbors => Neighborhood.Values;

      public SeatNeighborhood(Tuple<int, int> seat)
      {
        Seat = seat;
        Neighborhood = new Dictionary<Direction, Tuple<int, int>>();
      }

      public bool HasNeighbor(Direction direction)
      {
        return Neighborhood.ContainsKey(direction);
      }

      public Tuple<int, int> GetNeighbor(Direction direction)
      {
          if (Neighborhood.TryGetValue(direction, out var neighbor))
          {
            return neighbor;
          }

          return null;
      }

      public void SetNeighbor(Direction direction, Tuple<int, int> neighbor)
      {
        Neighborhood[direction] = neighbor;
      }
    }
  }
}
