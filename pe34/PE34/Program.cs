using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE34
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            int[] Factorial = new int[] { 1, 1,2,6,24,120,720,5040,40320,362880 };

            int ii = 3;
            do
            {
                int nn = ii;
                int partialSum = 0;

                do
                {
                    int digit = nn % 10;
                    nn /= 10;
                    partialSum += Factorial[digit];

                } while (nn != 0);

                if (partialSum == ii)
                {
                    Console.WriteLine(ii);
                    sum += ii;
                }

                ii++;

            } while (ii < 362880*10); // Just a guess.

            Console.WriteLine(sum ); // This prints 0.01, so 1/100, so denominator is 100.
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}
