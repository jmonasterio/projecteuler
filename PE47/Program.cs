using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PELib;

namespace PE47
{
    class Program
    {
        /* The first two consecutive numbers to have two distinct prime factors are:

        14 = 2 x 7
        15 = 3 x 5

        The first three consecutive numbers to have three distinct prime factors are:

        644 = 2² x  7 x 23
        645 = 3 x 5 x 43
        646 = 2 x 17 x 19.

        Find the first four consecutive integers to have four distinct primes factors. What is the first of these numbers?
         */
        static void Main(string[] args)
        {
            long first = 1;
            long secondFactors = 1; // Assume answer not at very beginning.
            long thirdFactors = 1;
            long fourthFactors = 1;
            long LOOKING_FOR = 4;

            do
            {
                // TOO SLOW!!
                long firstFactors = Util.CountUniquePrimeFactors(first);

                if ((firstFactors == LOOKING_FOR) && (secondFactors == LOOKING_FOR) && (thirdFactors == LOOKING_FOR) && (fourthFactors == LOOKING_FOR))
                {
                    Util.ShowResult(first-LOOKING_FOR+1);
                    Environment.Exit(0);
                }

                fourthFactors = thirdFactors;
                thirdFactors = secondFactors;
                secondFactors = firstFactors; // To avoid calculating twice.
                first++;
            } while (true);

        }

    }
}
