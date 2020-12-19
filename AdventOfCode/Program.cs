using System;
using System.Collections.Generic;
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
          string puzzleFilePath = Path.Combine("..", "Puzzles", puzzleFileName);
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
          
          List<string> input = PuzzleReader.GetInputLines(puzzleFilePath).ToList();
          input.ForEach(Console.WriteLine);


          Console.WriteLine("Hello World!");

          return 0;
        }

        private static Solver CreateSolver(int day)
        {
          Solver solver = null;

          try
          {
            string typeName = string.Format("Solvers.Day{0:D2}.Day{0:D2}Solver", day);
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
