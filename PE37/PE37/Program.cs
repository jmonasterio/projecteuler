using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE37
{
    /* The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.

Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
     */
	class Program
	{
		static void Main(string[] args)
		{
            int sum = 0;
            int count = 0;

            // Observation: Find all primes whose digits are all primes. Then out of those, test for truncatable

            int nn = 11; // Start here (since 2,3,5,7 are not valid).

            do
            {
                if (nn == 3797)
                {
                }
                if (IsPrime(nn))
                {
                    if (IsTruncatable(nn))
                    {
                        Console.WriteLine(nn);

                        sum += nn;
                        count++;
                    }
                }
                nn++;

            } while (count < 11);
            
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
		}

        static bool IsTruncatable(long num)
        {
            // Test RIGHT-TO-LEFT
            long rtl = num/10;
            do
            {
                if (!IsPrime(rtl))
                {
                    return false;
                }
                rtl /= 10;
            }
            while (rtl > 0);

            string s = "" + num;

            do
            {

                long ltr = long.Parse(s);

                if (!IsPrime(ltr))
                {
                    return false;
                }
                s = s.Substring(1);
            } while (s.Length > 0);

             return true;
        
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
            

        static bool IsPrime(long num)
        {
            if (num == 2 || num == 3) { return true; }
            if (num == 1) { return false; }
            for (int ii = 2; ii <= Math.Sqrt(num); ii++)
            {
                if (num % ii == 0)
                {
                    return false;
                }
            }
            return true;
        }
	}
}
