using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day02
{
  public struct CorporatePolicy
  {
    public int MinOccurences { get; set; }
    public int MaxOccurences { get; set; }
    public string RequiredCharacter { get; set; }
  }
}
