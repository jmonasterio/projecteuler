using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PELib;
using System.Numerics;
/*
 * 
 * Consider the following "magic" 3-gon ring, filled with the numbers 1 to 6, and each line adding to nine.


Working clockwise, and starting from the group of three with the numerically lowest external node (4,3,2 in this example), each solution can be described uniquely. For example, the above solution can be described by the set: 4,3,2; 6,2,1; 5,1,3.

It is possible to complete the ring with four different totals: 9, 10, 11, and 12. There are eight solutions in total.

Total	Solution Set
9	4,2,3; 5,3,1; 6,1,2
9	4,3,2; 6,2,1; 5,1,3
10	2,3,5; 4,5,1; 6,1,3
10	2,5,3; 6,3,1; 4,1,5
11	1,4,6; 3,6,2; 5,2,4
11	1,6,4; 5,4,2; 3,2,6
12	1,5,6; 2,6,4; 3,4,5
12	1,6,5; 3,5,4; 2,4,6
By concatenating each group it is possible to form 9-digit strings; the maximum string for a 3-gon ring is 432621513.

Using the numbers 1 to 10, and depending on arrangements, it is possible to form 16- and 17-digit strings. What is the maximum 16-digit string for a "magic" 5-gon ring?


 */
namespace PE68
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger maxxx = new BigInteger(0);
            foreach (int[] digits in PELib.Util.LexographicPermutationGeneratorArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }))
            {

                if (digits[1] == 10 || digits[2] == 10 || digits[4] == 10 || digits[6] == 10 || digits[8] == 10)
                {
                    //ignore 17 digit solutions
                }
                else
                {
                    int[] sumRow = {0,0,0,0,0};
                    string[] catRow = new string[5];

                    sumRow[0] = digits[0] + digits[1] + digits[2];
                    catRow[0] = "" + digits[0] + digits[1] + digits[2];

                    sumRow[1] = digits[3] + digits[2] + digits[4];
                    catRow[1] = "" + digits[3] + digits[2] + digits[4];
                    if (sumRow[0] == sumRow[1])
                    {
                        sumRow[2] = digits[5] + digits[4] + digits[6];
                        catRow[2] = "" + digits[5] + digits[4] + digits[6];
                        if (sumRow[2] == sumRow[0])
                        {
                            sumRow[3] = digits[7] + digits[6] + digits[8];
                            catRow[3] = "" + digits[7] + digits[6] + digits[8];
                            if (sumRow[3] == sumRow[2])
                            {
                                sumRow[4] = digits[9] + digits[8] + digits[1];
                                catRow[4] = "" + digits[9] + digits[8] + digits[1];
                                if (sumRow[0] == sumRow[4])
                                {

                                    // Working clockwise, and starting from the group of three with the numerically lowest external node


                                    //find index ii of lowest row[ii];
                                    int minRow = int.Parse(catRow[0]);
                                    int minIdx = 0;
                                    for (int ii = 1; ii < 5; ii++)
                                    {
                                        if (int.Parse(catRow[ii]) < minRow)
                                        {
                                            minRow = int.Parse(catRow[ii]);
                                            minIdx = ii;
                                        }
                                    }


                                    string sxx = "";

                                    for (int jj = minIdx; jj < 5; jj++)
                                    {
                                        sxx += catRow[jj];
                                    }
                                    for (int jj = 0; jj < minIdx; jj++)
                                    {
                                        sxx += catRow[jj];
                                    }

                                    BigInteger xx = BigInteger.Parse(sxx);
                                    if (xx < 0)
                                    {
                                        break;
                                    }
                                    if (xx > maxxx)
                                    {
                                        maxxx = xx;
                                    }
                                    System.Console.WriteLine(sxx + " " + catRow[0] + " " + sxx.Length);
                                }
                            }
                        }




                    }


                }
            }
            PELib.Util.ShowResult(maxxx);
        }
    }
}
