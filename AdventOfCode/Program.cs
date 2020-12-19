using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Reflection;

using AdventOfCode.Solvers;
using AdventOfCode.Readers;

namespace AdventOfCode
{
    public class Program
    {
        const byte MAX_DAY = 01;

        public static int Main(string[] args)
        {
          if (1 != args.Length)
          {
            Console.WriteLine("Arguments (1): puzzleDay");
            return -1;
          }

          if (!Int32.TryParse(args[0], out int day))
          {
            Console.WriteLine("Could not parse puzzle day.");
            return -1;
          }

          if (day <= 0 || day > MAX_DAY)
          {
            Console.WriteLine($"Please select a day between 1 and {MAX_DAY}");
            return -1;
          }

          string puzzleFileName = string.Format("Day{0:D2}.txt", day);
          string puzzleFilePath = Path.Combine(".", "Puzzles", puzzleFileName);
          Console.WriteLine(puzzleFilePath);
          if (!File.Exists(puzzleFilePath))
          {
            Console.WriteLine("Puzzle Input Not Found.");
            return -1;
          }

          Solver solver = CreateSolver(day);
          if (solver is not Solver)
          {
            Console.WriteLine("Solver creation failed.");
            return -1;
          }
          
          // Initialisation.
          TimeSpan ts;
          string solution;
          Stopwatch stopwatch = new Stopwatch();
          List<string> input = PuzzleReader.GetInputLines(puzzleFilePath).ToList();

          // Part 1.
          stopwatch.Start();
          solution = solver.SolvePartA(input);
          stopwatch.Stop();
          
          ts = stopwatch.Elapsed;
          Console.WriteLine($"Part 1: {solution}");
          Console.WriteLine("Time 1: {0:D2}.{1:D3} seconds.", ts.Seconds, ts.Milliseconds);

          // Part 2.
          stopwatch.Restart();
          solution = solver.SolvePartB(input);
          stopwatch.Stop();

          ts = stopwatch.Elapsed;
          Console.WriteLine($"Part 2: {solution}");
          Console.WriteLine("Time 2: {0:D2}.{1:D3} seconds.", ts.Seconds, ts.Milliseconds);

          return 0;
        }

        private static Solver CreateSolver(int day)
        {
          Solver solver = null;

          try
          {
            string typeName = string.Format("AdventOfCode.Solvers.Day{0:D2}.Day{0:D2}Solver", day);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType(typeName, true);
            solver = Activator.CreateInstance(type) as Solver;
          }
          catch
          {
          }

          return solver;
        }
    }
}
