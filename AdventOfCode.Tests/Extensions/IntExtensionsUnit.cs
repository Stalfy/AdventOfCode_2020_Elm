using Microsoft.VisualStudio.TestTools.UnitTesting;

using AdventOfCode.Extensions;

namespace AdventOfCode.Tests.Extensions
{
    [TestClass]
    public class IntExtensionUnit
    {
        [TestMethod]
        public void TestParseOrNull()
        {
          Assert.AreEqual(null, IntExtensions.ParseOrNull("a"));
          Assert.AreEqual(-1, IntExtensions.ParseOrNull("-1"));
          Assert.AreEqual(1, IntExtensions.ParseOrNull("1"));
        }
    }
}
