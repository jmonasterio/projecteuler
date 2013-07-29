using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

3
7 4
2 4 6
8 5 9 3

That is, 3 + 7 + 4 + 9 = 23.

Find the maximum total from top to bottom of the triangle below:

                    75
                  95 64
                17 47 82
               18 35 87 10
             20 04 82 47 65
            19 01 23 75 03 34
           88 02 77 73 07 63 67
         99 65 04 28 06 16 70 92
        41 41 26 56 83 40 80 70 33
       41 48 72 33 47 32 37 16 94 29
     53 71 44 65 25 43 91 52 97 51 14
    70 11 33 28 77 73 17 78 39 68 17 57
   91 71 52 38 17 14 91 43 58 50 27 29 48
  63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route. However, Problem 67, is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force, and requires a clever method! ;o)
 */
namespace PE18
{
    class Program
    {
        /* Think of it this way in an array
         * 
         *                    
75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

         Observations:
         1) Every item has 2 children.
         2) Start at bottom and prune the bad child
         3) Then repeat on next row up, building up a longer chain below.
         
         
          
         **/

        static void FillArray( int[,] nums, string vals)
        {
            string[] items = System.Text.RegularExpressions.Regex.Split( vals, @"\s+");
            int rr = 0;
            int cc = 0;
            int ii = 1;
            do
            {
                nums[cc,rr] = int.Parse(items[ii]);
                ii++;
                rr++;
                if( rr>cc)
                {
                    cc++;
                    rr=0;
                }
            }
            while( cc < 15);

        }

        static void Main(string[] args)
        {
            const int ROWS = 15;
            int[,] nums = new int[ROWS, ROWS];
            FillArray(nums, @"  75
                                95 64
                                17 47 82
                                18 35 87 10
                                20 04 82 47 65
                                19 01 23 75 03 34
                                88 02 77 73 07 63 67
                                99 65 04 28 06 16 70 92
                                41 41 26 56 83 40 80 70 33
                                41 48 72 33 47 32 37 16 94 29
                                53 71 44 65 25 43 91 52 97 51 14
                                70 11 33 28 77 73 17 78 39 68 17 57
                                91 71 52 38 17 14 91 43 58 50 27 29 48
                                63 66 04 68 89 53 67 30 73 16 69 87 40 31
                                04 62 98 27 23 09 70 98 73 93 38 53 60 04 23");

            int [] runs = new int[ROWS]; // 15 end points. keep total running back.
            string[] run_nums = new string[ROWS];

            // Start runs with value of bottom row.
            for( int cc = 0; cc <ROWS; cc ++)
            {
                runs[cc] = nums[ROWS-1,cc];
                run_nums[cc] = "" + runs[cc];
            }

            for (int rr = ROWS-2; rr >= 0; rr--)
            {
                for (int cc = 0; cc <= rr; cc++)
                {
                    int whichChild = 0; // 0 = under, 1=down-right
                    whichChild = (runs[cc] > runs[cc + 1]) ? 0 : 1;
                    runs[cc] = nums[rr, cc] + runs[cc + whichChild];
                    // For debug
                    run_nums[cc] = "" + nums[rr,cc] + "+" + run_nums[cc + whichChild];
                }

            }


            Console.WriteLine(runs[0]);
            Console.WriteLine(run_nums[0]); // For debug
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}
