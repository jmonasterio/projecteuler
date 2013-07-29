using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE15
{
    class Program
    {
        /* Starting in the top left corner of a 2x2 grid, there are 6 routes (without backtracking) to the bottom right corner.

            How many routes are there through a 20x20 grid?
         */
        static void Main(string[] args)
        {
            // See : http://betterexplained.com/articles/navigate-a-grid-using-combinations-and-permutations/

            // observation: for 2x2 there are 2 RIGHTS and 2 DOWNS. RRDD DDRR RDRD DRDR RDDR DRRD
            // 6 =  4! / 2!*2! = 4*3*2/4 = 6
         

            // 20! / 10! * 10!

            Double fact40 = Factorial(40);
            Double fact20 = Factorial(20);

            Double result = fact40 / fact20 / fact20;

            Console.WriteLine(result);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }

        static Double Factorial(int n)
        {
            Double f = 1;
            do
            {
                f *= n;
            } while (--n > 0);
            return f;
        }
    }
}
