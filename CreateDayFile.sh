#!/bin/bash

if [ $# -ne 2 ]; then
  echo "Usage: CreateDayFile.sh Day FileName"
  exit
fi

SOLVER_DIR=./AdventOfCode/Solvers/Day$1
TEST_DIR=./AdventOfCode.Tests/Solvers/Day$1

SOLVER_PATH=$SOLVER_DIR/$2.cs
TEST_PATH=$TEST_DIR/$2Unit.cs

mkdir -p $SOLVER_DIR
mkdir -p $TEST_DIR

# Create file.
echo "using System;"                         >> $SOLVER_PATH
echo "using System.Collections.Generic;"     >> $SOLVER_PATH
echo "using System.Linq;"                    >> $SOLVER_PATH
echo ""                                      >> $SOLVER_PATH
echo "namespace AdventOfCode.Solvers.Day$1"  >> $SOLVER_PATH
echo "{"                                     >> $SOLVER_PATH
echo "  public class $2"                     >> $SOLVER_PATH
echo "  {"                                   >> $SOLVER_PATH
echo "    public bool BaseMethod() => true;" >> $SOLVER_PATH
echo "  }"                                   >> $SOLVER_PATH
echo "}"                                     >> $SOLVER_PATH

# Create test file.
echo "using Microsoft.VisualStudio.TestTools.UnitTesting;" >> $TEST_PATH
echo ""                                                    >> $TEST_PATH
echo "using System.Collections.Generic;"                   >> $TEST_PATH
echo ""                                                    >> $TEST_PATH
echo "using Solvers.Day$1;"                                >> $TEST_PATH
echo ""                                                    >> $TEST_PATH
echo "namespace AdventOfCode.Tests.Solvers.Day$1"          >> $TEST_PATH
echo "{"                                                   >> $TEST_PATH
echo "  [TestClass]"                                       >> $TEST_PATH
echo "  public class $2Unit"                               >> $TEST_PATH
echo "  {"                                                 >> $TEST_PATH
echo "    [TestMethod]"                                    >> $TEST_PATH
echo "    public void TestBaseMethod()"                    >> $TEST_PATH
echo "    {"                                               >> $TEST_PATH
echo "      $2 tested = new $2();"                         >> $TEST_PATH
echo "      Assert.IsTrue(tested.BaseMethod());"           >> $TEST_PATH
echo "    }"                                               >> $TEST_PATH
echo "  }"                                                 >> $TEST_PATH
echo "}"                                                   >> $TEST_PATH
