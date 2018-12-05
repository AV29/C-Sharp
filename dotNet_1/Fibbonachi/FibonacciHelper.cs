using System.Collections.Generic;
using System.Numerics;

namespace Fibbonacci
{
    public static class FibonacciHelper
    {
        public static IEnumerable<BigInteger> TakeNFibs(BigInteger start1, BigInteger start2, int amount)
        {
            foreach (BigInteger i in Fibonacci(start1, start2))
            {
                if (amount == 0) yield break;
                amount--;
                yield return i;
            }
        }

        public static IEnumerable<BigInteger> TakeFibs(this IEnumerable<BigInteger> source, int amount)
        {
            foreach (BigInteger i in source)
            {
                if (amount == 0) yield break;
                amount--;
                yield return i;
            }
        }

        public static IEnumerable<BigInteger> Fibonacci(BigInteger f0, BigInteger f1)
        {
            yield return f0;
            yield return f1;
            while (true)
            {
                (f0, f1) = (f1, f0 + f1); //кортежный хак - помещаем в f0 f1, а в f1 - f0+f1 налету, до того как f0 поменялось))
                yield return f1;
            }
        }
    }
}
