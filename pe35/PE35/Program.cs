using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE35
{
    class Program
    {
                    // naive prime test.
        static bool is_prime(long num)
        {
            if (num == 2 || num == 3) { return true; }
            for (int ii = 2; ii <= Math.Sqrt(num); ii++)
            {
                if (num % ii == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static bool is_circular_prime(long num)
        {
            // Rotate once for each digit.
            long nn = num;
            for( int rotates =0; rotates < (int) Math.Log10(num); rotates++)
            {
                nn = Rotate(nn);
                if( !is_prime(nn))
                {
                    return false;
                }
            }
            return true;
        }

        // 123 -> 312
        static long Rotate( long num)
        {
            // Better to use string to handle 0's more easily, like 701. -> 71?
            string s = "" + num;
            s = s.Substring(s.Length-1,1) + s.Substring(0,s.Length-1);
            long n = long.Parse(s);
            return n;
        }

        static void Main(string[] args)
        {
            long maxPrime = 1000000;
            int countCircularPrimes = 0;
            long test = 2; // Start with 2, because 1 does not count as prime.

            do
            {
                if (is_prime(test))
                {
                    if (is_circular_prime(test))
                    {
                        countCircularPrimes++;
                        Console.WriteLine(test);
                    }
                }
                test++;
            }
            while (test < maxPrime);


            Console.WriteLine( "Count:" + countCircularPrimes);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}
