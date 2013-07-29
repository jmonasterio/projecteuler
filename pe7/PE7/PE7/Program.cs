using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE7
{
    //By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    //What is the 10001st prime number?
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

        static void Main(string[] args)
        {
            int primeCount = 10001;
            int nthPrime = 0;
            int test = 2; // Start with 2, because 1 does not count as prime.

            do
            {
                if (is_prime(test))
                {
                    primeCount--;
                    nthPrime = test;
                }
                test++;
            }
            while (primeCount > 0);


            Console.WriteLine(nthPrime);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}
