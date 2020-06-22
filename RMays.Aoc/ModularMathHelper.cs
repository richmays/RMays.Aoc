using System.Numerics;

namespace Rmays.Aoc
{
    public static class ModularMathHelper
    {
        public static long Mod(long divisor, long dividend)
        {
            return divisor % dividend;
        }

        public static long ModPow(long b, long e, long m)
        {
            // Seriously.  That's all we need.
            return (long)BigInteger.ModPow(b, e, m);
        }
    }
}
