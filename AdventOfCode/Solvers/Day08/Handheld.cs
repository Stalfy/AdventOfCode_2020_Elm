using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day08
{
  public class Handheld
  {
    public int InstructionPointer { get; set; }
    public int Accumulator { get; set; }
    
    public Handheld()
    {
      Reset();
    }

    public void Reset()
    {
      InstructionPointer = 0;
      Accumulator = 0;
    }

    public void ExecuteInstruction(string instruction)
    {
      string[] parts = instruction.Split(new char[] { ' ' });

      switch (parts[0])
      {
        case "nop":
          InstructionPointer++;
          break;
        case "acc" when int.TryParse(parts[1], out int acc):
          Accumulator += acc;
          InstructionPointer++;
          break;
        case "jmp" when int.TryParse(parts[1], out int jmp):
          InstructionPointer += jmp;
          break;
      }
    }
  }
}
