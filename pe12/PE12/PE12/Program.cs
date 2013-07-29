﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE12
{
    class Program
    {
        /*
         * 
         * 
         * The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:

            1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

            Let us list the factors of the first seven triangle numbers:

             1: 1
             3: 1,3
             6: 1,2,3,6
            10: 1,2,5,10
            15: 1,3,5,15
            21: 1,3,7,21
            28: 1,2,4,7,14,28
            We can see that 28 is the first triangle number to have over five divisors.

            What is the value of the first triangle number to have over five hundred divisors
         */

        /* NOTE: The answer is one of these:
         * 
         * All Highly Composite Triangular numbers below 5*1013 are:
1, 3, 6, 28, 36, 120, 300, 528, 630, 2016, 3240, 5460, 25200, 73920, 157080, 437580, 749700, 1385280, 1493856, 2031120, 2162160, 17907120, 76576500, 103672800, 236215980, 842161320, 3090906000, 4819214400, 7589181600, 7966312200, 13674528000, 20366564400, 49172323200, 78091322400, 102774672000, 557736444720, 666365279580, 876785263200, 1787835551040, 2427046221600, 3798207594720, 24287658595200 and 26571463158240.
         */

        class TriangleNumbers
        {
            long Num = 1;
            long Prev = 0;

            public TriangleNumbers()
            {
                Num = 1;
            }

            public System.Collections.IEnumerator GetEnumerator()
            {
                while (true)
                {
                    Prev += (Num++);
                    yield return Prev;
                }
            }
        }

        // I had trouble getting an efficient function here. My first attempt was much too slow.
        static int CountDivisors(long x) {
            long limit = x;
            int numberOfDivisors = 0;

            for (long ii=1; ii < limit; ii++) {
                if (x % ii == 0) {
                    limit = x / ii;
                    if (limit != ii) {
                        numberOfDivisors++;
                    }
                    numberOfDivisors++;
                }
            }

            return numberOfDivisors;
        }

        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;

            long lookingFor = 500;
            long found = 0;

            TriangleNumbers triangleNumbers = new TriangleNumbers();
            foreach (long tn in triangleNumbers)
            {
                long divCount = CountDivisors(tn);
                //Console.WriteLine("NUM: " + tn + "," + divCount);
                if (divCount >= lookingFor)
                {
                    found = tn;
                    break;
                }
            }

            Console.WriteLine(found);
            Console.WriteLine("TIME: " +(DateTime.Now-start).Seconds + "sec");
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}
