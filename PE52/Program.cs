using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE52
{
    class Program
    {
        static void Main(string[] args)
        {
            long nn = 2;

            do
            {
                long nn_sorted = SortDigits(nn);

                if (nn_sorted == SortDigits(nn * 2) &&
                    nn_sorted == SortDigits(nn * 3) &&
                    nn_sorted == SortDigits(nn * 4) &&
                    nn_sorted == SortDigits(nn * 5))
                {
                    break;
                }

                nn++;
            } while (true);

            PELib.Util.ShowResult(nn);

        }

        static long SortDigits(long nn)
        {
            int[] digits = PELib.Util.LongToArrayOfDigits(nn);
            Array.Sort(digits);
            return PELib.Util.ArrayOfDigitsToLong(digits,0,digits.Length-1);
        }
    }
}
