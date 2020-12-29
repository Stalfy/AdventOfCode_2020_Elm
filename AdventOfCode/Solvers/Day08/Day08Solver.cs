using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day08
{
  public class Day08Solver : Solver
  {
    public string SolvePartA(IEnumerable<string> input)
    {
      Handheld handheld = new Handheld();
      Run(handheld, input);
      return handheld.Accumulator.ToString();
    }

    public string SolvePartB(IEnumerable<string> input)
    {
      Handheld handheld = new Handheld();
      RepairHandheldProgram(handheld, input);
      return handheld.Accumulator.ToString();
    }

    private bool Run(Handheld handheld, IEnumerable<string> program)
    {
      HashSet<int> seenInstructions = new HashSet<int>();
      List<string> instructions = program.ToList();

      int accumulator = handheld.Accumulator;
      while (!seenInstructions.Contains(handheld.InstructionPointer)
        && handheld.InstructionPointer < instructions.Count)
      {
        seenInstructions.Add(handheld.InstructionPointer);
        accumulator = handheld.Accumulator;
        handheld.ExecuteInstruction(instructions[handheld.InstructionPointer]);
      }

      return handheld.InstructionPointer == instructions.Count;
    }

    private void RepairHandheldProgram(Handheld handheld, IEnumerable<string> program)
    {
      bool programRepaired = false;
      List<string> instructions = program.ToList();
      for (int i = 0; i < instructions.Count && !programRepaired; i++)
      {
        string instructionCode = instructions[i].Substring(0, 3);
        if (IsSwappableInstruction(instructionCode))
        {
          string tmp = instructions[i];
          instructions[i] = SwapInstruction(instructionCode, instructions[i]);

          handheld.Reset();
          programRepaired = Run(handheld, instructions);

          instructions[i] = tmp;
        }
      }
    }

    private bool IsSwappableInstruction(string instructionCode)
    {
      return instructionCode == "nop" || instructionCode == "jmp";
    }

    private string SwapInstruction(string code, string instruction)
    {
      string newInstruction = instruction;
      switch (code)
      {
        case "nop":
          newInstruction = newInstruction.Replace("nop", "jmp");
          break;
        case "jmp":
          newInstruction = newInstruction.Replace("jmp", "nop");
          break;
      }

      return newInstruction;
    }
  }
}
