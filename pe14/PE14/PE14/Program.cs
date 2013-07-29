using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * The following iterative sequence is defined for the set of positive integers:

n  n/2 (n is even)
n  3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:

13  40  20  10  5  16  8  4  2  1
It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.
 * */
namespace PE14
{
    class Program
    {
        static int CountChain(long n)
        {
            int chain = 0;
            do
            {
                chain++;
                if (n % 2 == 0)
                {
                    // even
                    n = n / 2;
                }
                else
                {
                    n = 3 * n + 1;
                }
            } while (n != 1);

            return chain;
        }

        static void Main(string[] args)
        {
            const int MAX = 1000000;
            int longestChain = 0;
            long longestInt = 0;
            for( long ii=3; ii<MAX; ii++)
            {

                int chain = CountChain( ii);
                if( chain > longestChain)
                {
                    longestChain = chain;
                    longestInt = ii;
                }
            }


            Console.WriteLine(longestInt);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();

        }
    }
}
