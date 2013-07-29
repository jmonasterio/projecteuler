using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE27
{
    class Program
    {
        /* Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:

        21 22 23 24 25
        20  7  8  9 10
        19  6  1  2 11
        18  5  4  3 12
        17 16 15 14 13

        It can be verified that the sum of the numbers on the diagonals is 101.

        What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
         */

        /* 

         43 44 45 46 47 48 49
         42 21 22 23 24 25 26
         41 20  7  8  9 10 27
         40 19  6  1  2 11 28
         39 18  5  4  3 12 29
         38 17 16 15 14 13 30
         37 36 35 34 33 32 31
         
         
          1 3 13 31

          1 5 17 37

          1 7 21 43

          1 9 25 49 .. 64


          = 1 (for center) +

              + ( 3 ^2 + 5^2 ) * 4

              - ( 2-4-6 - 4-8-12 )

         = 1 + 34*4 - 48
         = 1 + 136 - 36
         = 101
         
         
         =1 + (9+25+49)*4 - (2-4-6 - 4-8-12 - 6-12-18)
         = 1 + 332 - 72
         = 261

         
         = 57 + 45 = 102
                 */

        static void Main(string[] args)
        {
            int totalDiagonal = 1; // Start with center.
            for (int ii = 3; ii <= 1001; ii += 2)
            {
                totalDiagonal += (ii * ii)*4;
                totalDiagonal -= ((ii - 1) * 6);
            }

            Console.WriteLine(totalDiagonal);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}
