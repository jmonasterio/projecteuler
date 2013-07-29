using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE10
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

        static void Main(string[] args)?142913828922oirewq  q nc 
            fs  -
        {
            long maxPrime = 2000000;
            long sum = 0;
            long test = 2; // Start with 2, because 1 does not count as prime.

            do
            {
                if (is_prime(test))
                {
                    sum += test;
                }
                test++;
            }
            while (test < maxPrime);


            Console.WriteLine(sum);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}
