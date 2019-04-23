using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using PseudoEnumerable;

namespace PseudoEnumerable.Tests
{
    [TestFixture]
    public class EnumerableTests
    {
        [TestCase(new int[] {2,4,6, 100, 324, 862, 976}, true)]
        [TestCase(new int[] {2,4,6, 1}, false)]
        [TestCase(new int[] {2,4,6, 16, int.MaxValue}, false)]
        public void ForAll_CheckEven(int[] items, bool result)
        {
            bool expected = Enumerable.ForAll(items, (x) =>  ((x % 2) == 0) ? true : false );
            Assert.AreEqual(expected, result);
        }

        [TestCase(new string[] {"qwe", "123456789", "qwert", "qwerty" }, false)]
        [TestCase(new string[] {"qwe123", "123456789", "qwert6", "qwerty" }, true)]
        [TestCase(new string[] {"qweweeee", "123456789", "qwert5", "qwerty" }, true)]
        public void ForAll_StrLengthLess5(string[] items, bool result)
        {
            bool expected = Enumerable.ForAll(items, (s) => (s.Length > 5) ? true : false);
            Assert.AreEqual(expected, result);

        }
    }
}