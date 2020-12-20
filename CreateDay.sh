#!/bin/bash

if [ $# -ne 1 ]; then
  echo "Missing argument: Day"
  exit
fi

SOLVER_DIR=./AdventOfCode/Solvers/Day$1
TEST_DIR=./AdventOfCode.Tests/Solvers/Day$1

SOLVER_PATH=$SOLVER_DIR/Day$1Solver.cs
TEST_PATH=$TEST_DIR/Day$1SolverUnit.cs

mkdir -p $SOLVER_DIR
mkdir -p $TEST_DIR

# Create solver file.
echo "using System;"                                           >> $SOLVER_PATH
echo "using System.Collections.Generic;"                       >> $SOLVER_PATH
echo "using System.Linq;"                                      >> $SOLVER_PATH
echo ""                                                        >> $SOLVER_PATH
echo "namespace AdventOfCode.Solvers.Day$1"                    >> $SOLVER_PATH
echo "{"                                                       >> $SOLVER_PATH
echo "  public class Day$1Solver : Solver"                     >> $SOLVER_PATH
echo "  {"                                                     >> $SOLVER_PATH
echo "    public string SolvePartA(IEnumerable<string> input)" >> $SOLVER_PATH
echo "    {"                                                   >> $SOLVER_PATH
echo "      return \"A\";"                                     >> $SOLVER_PATH
echo "    }"                                                   >> $SOLVER_PATH
echo ""                                                        >> $SOLVER_PATH
echo "    public string SolvePartB(IEnumerable<string> input)" >> $SOLVER_PATH
echo "    {"                                                   >> $SOLVER_PATH
echo "      return \"B\";"                                     >> $SOLVER_PATH
echo "    }"                                                   >> $SOLVER_PATH
echo "  }"                                                     >> $SOLVER_PATH
echo "}"                                                       >> $SOLVER_PATH

# Create test file.
echo "using Microsoft.VisualStudio.TestTools.UnitTesting;"   >> $TEST_PATH
echo ""                                                      >> $TEST_PATH
echo "using System.Collections.Generic;"                     >> $TEST_PATH
echo ""                                                      >> $TEST_PATH
echo "using AdventOfCode.Solvers;"                           >> $TEST_PATH
echo "using AdventOfCode.Solvers.Day$1;"                     >> $TEST_PATH
echo ""                                                      >> $TEST_PATH
echo "namespace AdventOfCode.Tests.Solvers.Day$1"            >> $TEST_PATH
echo "{"                                                     >> $TEST_PATH
echo "  [TestClass]"                                         >> $TEST_PATH
echo "  public class Day$1SolverUnit"                        >> $TEST_PATH
echo "  {"                                                   >> $TEST_PATH
echo "    [TestMethod]"                                      >> $TEST_PATH
echo "    public void TestSolvePartA()"                      >> $TEST_PATH
echo "    {"                                                 >> $TEST_PATH
echo "      Solver s = new Day$1Solver();"                   >> $TEST_PATH
echo "      IEnumerable<string> input = new List<string>();" >> $TEST_PATH
echo "      Assert.AreEqual(\"A\", s.SolvePartA(input));"    >> $TEST_PATH
echo "    }"                                                 >> $TEST_PATH
echo ""                                                      >> $TEST_PATH
echo "    [TestMethod]"                                      >> $TEST_PATH
echo "    public void TestSolvePartB()"                      >> $TEST_PATH
echo "    {"                                                 >> $TEST_PATH
echo "      Solver s = new Day$1Solver();"                   >> $TEST_PATH
echo "      IEnumerable<string> input = new List<string>();" >> $TEST_PATH
echo "      Assert.AreEqual(\"B\", s.SolvePartB(input));"    >> $TEST_PATH
echo "    }"                                                 >> $TEST_PATH
echo "  }"                                                   >> $TEST_PATH
echo "}"                                                     >> $TEST_PATH
