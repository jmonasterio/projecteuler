using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PELib;
using System.Numerics;

namespace PE57
{
    /* It is possible to show that the square root of two can be expressed as an infinite continued fraction.

        sqrt(2) = 1 + 1/(2 + 1/(2 + 1/(2 + ... ))) = 1.414213...

        By expanding this for the first four iterations, we get:

        1 + 1/2 = 3/2 = 1.5
        1 + 1/(2 + 1/2) = 7/5 = 1.4
        1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666...
        1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379...

        The next three expansions are 99/70, 239/169, and 577/408, but the eighth expansion, 1393/985, is the first example where the number of digits in the numerator exceeds the number of digits in the denominator.

        In the first one-thousand expansions, how many fractions contain a numerator with more digits than denominator?
     */
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int expansions = 1; // Start a 3/2
            var num = new BigInteger( 3);
            var den = new BigInteger(2);

            do
            {
                // Figured out with pencil and paper.
                // Next fraction = (1 + 1/(1 + prev))
                num = (num + den); // 1+ prev
                PELib.Util.Swap(ref num, ref den); // reciprocal
                num = (num + den); // 1 + recip

                //Console.WriteLine("" + num + "/" + den);

                if( (int) BigInteger.Log10( num) > (int) BigInteger.Log10( den))
                {
                    count++;
                }
                expansions++;
            } while (expansions<1000);

            PELib.Util.ShowResult(count);
        }

    }
}
