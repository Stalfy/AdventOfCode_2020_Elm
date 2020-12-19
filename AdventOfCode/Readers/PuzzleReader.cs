using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Readers
{
  public static class PuzzleReader
  {
    public static IEnumerable<string> GetInputLines(string filePath)
    {
      string[] lines = new string[0];
      try
      {
        lines = File.ReadAllLines(filePath);
      }
      catch
      {
      }

      foreach(string line in File.ReadAllLines(filePath))
      {
          yield return line;    
      }
    }
  }
}
