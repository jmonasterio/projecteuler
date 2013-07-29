using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE30
{
    class Program
    {
        /*
         * Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

            1634 = 14 + 64 + 34 + 44
            8208 = 84 + 24 + 04 + 84
            9474 = 94 + 44 + 74 + 44
            As 1 = 14 is not a sum it is not included.

            The sum of these numbers is 1634 + 8208 + 9474 = 19316.

            Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
         */
        static void Main(string[] args)
        {
            int[] power5 = new int[11];
            int max = 0; // This is the largest possible number ( a guess).
            int answerSum = 0;
            for (int ii = 1; ii < 10; ii++)
            {
                power5[ii] = (int) Math.Pow(ii,5);
                max += power5[ii];
            }

            for (int ii = 2; ii <= max*2; ii++) // max*2 = increased guess?
            {
                int num = ii;
                int sum = 0;
                do
                {
                    int nextDig = num % 10;
                    sum += power5[nextDig];
                    num /= 10;
                } while (num != 0);

                if (sum == ii)
                {
                    Console.WriteLine(sum);
                    answerSum += sum;
                }
            }


            Console.WriteLine(answerSum);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}
