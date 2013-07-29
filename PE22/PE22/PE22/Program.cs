﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE22
{
    class Program
    {
        /*
         * A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.

Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
         */
        static void Main(string[] args)
        {
            int countAbundant = 0;
            List<int> abundantNumbers = new List<int>();

            // Find all abunduant numbers.
            for (int ii=1; ii< 28123; ii++)
            {
                if( SumOfProperDivisors(ii) > ii)
                {
                    //Console.WriteLine( "" + ii + " is abundant");
                    countAbundant++;
                    abundantNumbers.Add(ii);
                }
            }

            int sumCannotBeSumOfTwoAbundant = 0;

            for (int jj = 1; jj < 28123; jj++)
            {
                if (!IsSumOfTwoAbundant(jj, abundantNumbers))
                {
                    sumCannotBeSumOfTwoAbundant += jj;
                }
            }




            Console.WriteLine(sumCannotBeSumOfTwoAbundant);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }

        static bool IsSumOfTwoAbundant( int n, List<int> abundantNumbers)
        {
            int ii = 0;
            while (abundantNumbers[ii] < n)
            {
                // We know the abundantNumbers array is sorted, so binary search is ok.
                if (abundantNumbers.BinarySearch(n - abundantNumbers[ii]) > -1)
                {
                    return true;
                }
                ii++;
            }

            return false;
        }

        static int SumOfProperDivisors(int n)
        {
            int sum = 0;
            int max = n/2;
            for (int ii = 1; ii <= max; ii++)
            {
                if (n % ii == 0)
                {
                    sum += ii;
                }
            }
            return sum;
        }

        static int AlphabeticalPosition(string s)
        {
            int sum = 0;
            for (int ii = 0; ii < s.Length; ii++)
            {
                sum += (int)s[ii] - (int) 'A' + 1;
            }
            return sum;
        }
    }
}
