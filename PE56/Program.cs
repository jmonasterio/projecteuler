using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using PELib;

namespace PE56
{
    class Program
    {
        /* A googol (10100) is a massive number: one followed by one-hundred zeros; 100100 is almost unimaginably large: one followed by two-hundred zeros. Despite their size, the sum of the digits in each number is only 1.

            Considering natural numbers of the form, a^b, where a, b  100, what is the maximum digital sum?
         */
        static void Main(string[] args)
        {
            int maxDigitalSum = 0;
            for (int aa = 1; aa < 100; aa++)
            {
                for (int bb = 1; bb < 100; bb++)
                {
                    BigInteger num = BigInteger.Pow(new BigInteger(aa), bb);
                    int sumDigits = 0;

                    BigInteger ten = new BigInteger(10);

                    do
                    {
                        BigInteger rem;
                        BigInteger.DivRem(num, ten, out rem);
                        num = BigInteger.Divide(num, ten);
                        sumDigits += (int)rem;
                    } while (num > 0);

                    if (sumDigits > maxDigitalSum)
                    {
                        maxDigitalSum = sumDigits;
                    }

                }
            }

            Util.ShowResult(maxDigitalSum);

        }
    }
}
