using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;
using System.IO;

using AdventOfCode.Readers;

namespace AdventOfCode.Test.Readers
{
  [TestClass]
  public class PuzzleReaderUnit
  {
    private static TestContext _context;

    [ClassInitialize]
    public static void ClassSetup(TestContext context)
    {
      _context = context;
    }

    [TestMethod]
    public void TestParseFile()
    {
      string filePath = Path.Combine(_context.TestRunDirectory, "..", "..", "Readers", "Artifacts", "PuzzleReaderTestInput.txt");
      Assert.AreEqual(4, PuzzleReader.GetInputLines(filePath).Count());
    }
  }
}
