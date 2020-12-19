using System;

namespace AdventOfCode.Extensions
{
  public static class IntExtensions
  {
    public static int? ParseOrNull(string text)
    {
      int? result = null;
      if (Int32.TryParse(text, out int val))
      {
        result = val;
      }

      return result;
    }
  }
}
