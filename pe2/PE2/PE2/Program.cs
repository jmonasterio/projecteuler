using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE2
{
    class Program
    {
        static int fibon(int term)
        {
            if (term == 1) return 1;
            if (term == 2) return 2;
            return fibon(term - 1) + fibon(term - 2);
        }

        static void Main(string[] args)
        {
            int sumOfEven = 0;
            int fib = 0;
            int term = 1;
            int last = 4000000;

            do
            {
                fib = fibon(term++);
                if (fib > last)
                {
                    break;
                }
                if (fib % 2 == 0)
                {
                    //Console.WriteLine(fib);
                    sumOfEven += fib;
                }
            } while (true);

            Console.WriteLine(sumOfEven);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();

        }
    }
}
