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
        [TestCase(new int[] {2,4,6}, true)]

        public void ForAll_CheckEven(int[] items, bool result)
        {
            
        }
    }
}