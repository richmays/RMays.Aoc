using NUnit.Framework;
using Rmays.Aoc;

namespace RMays.Aoc.Tests
{
    [TestFixture]
    public class ModularMathHelperTests
    {
        [TestCase(10, 10, 0)]
        [TestCase(10, 9, 1)]
        [TestCase(10, 8, 2)]
        [TestCase(10, 7, 3)]
        [TestCase(10, 6, 4)]
        [TestCase(10, 5, 0)]
        [TestCase(10, 4, 2)]
        [TestCase(10, 3, 1)]
        [TestCase(10, 2, 0)]
        [TestCase(10, 1, 0)]
        public void ModTest(long dividend, long divisor, long expectedResult)
        {
            Assert.AreEqual(expectedResult, ModularMathHelper.Mod(dividend, divisor));
        }

        [TestCase(4,13,497,445)] // from https://en.wikipedia.org/wiki/Modular_exponentiation
        public void ModPowerTest(long _base, long power, long modulus, long expectedResult)
        {
            Assert.AreEqual(expectedResult, ModularMathHelper.ModPow(_base, power, modulus));
        }
    }
}
