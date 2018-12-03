using System;
using System.Collections.Generic;
using System.Numerics;

namespace Fibbonachi
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            foreach (var i in TakeNFibs(0, 1, 25)) {
                Console.WriteLine(i);
            }
        }

        public static IEnumerable<BigInteger> TakeNFibs(BigInteger start1, BigInteger start2, int amount)
        {
            foreach (BigInteger i in Fibonacchi(start1, start2))
            {
                if (amount == 0) yield break;
                amount--;
                yield return i;
            }
        }

        public static IEnumerable<BigInteger> Fibonacchi(BigInteger f0, BigInteger f1) {
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
