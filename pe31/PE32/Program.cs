using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE31
{
    class Program
    {
        /*
          We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.

            The product 7254 is unusual, as the identity, 39  186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.

            Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.

            HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
         */


        static bool g_bDone = false;

        static void Main(string[] args)
        {
            List<int> products = new List<int>(); // Keep list to avoid dups.

            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            do
            {
                int product;
                product = IsIdentity(nums);
                if( product != 0)
                {
                    // avoid dup products.
                    if (!products.Contains(product))
                    {
                        products.Add(product);
                    }
                    else
                    {
                        Console.WriteLine("<-- Previous was DUP");
                    }
                }
                nextPermutation(nums);
            }
            while (!g_bDone ); // HACK

            int sum = 0;
            foreach( int v in products)
            {
                sum+=v;
            }

            Console.WriteLine(sum);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }

        static int IsIdentity(int[] nums)
        {
            /* MULTIPLCAND x MULTIPLIER = PRODUCT
            1 x 2 = 3456789
            1 x 23 = 456789
            1 x 234 = 45789
                ...
            1 x 2345678 = 9

            12 x 3 = 456789
            12 x 34 = 56789 */

            for (int multiplicandDigits = 1; multiplicandDigits < 7; multiplicandDigits++)
            {
                for (int multiplierDigits = 1; multiplierDigits < 8 - multiplicandDigits; multiplierDigits++)
                {
                    int productDigts = 8 - multiplierDigits - multiplicandDigits;

                    int product = MakeInt(nums, 8 - productDigts, 8);
                    int multiplicand = MakeInt(nums, 0, multiplicandDigits-1);
                    int multiplier = MakeInt(nums, multiplicandDigits, multiplicandDigits + multiplierDigits -1);

                    if (multiplicand * multiplier == product)
                    {
                        Console.WriteLine("" + multiplicand + "*" + multiplier + "=" + product);
                        return product;
                    }

                }
            }

            return 0;
        }

        static int MakeInt(int[] nums, int start, int end)
        {
            int sum = 0;
            int pow = 1;
            for( int ii=end; ii>=start; ii--)
            {
                sum += (pow*nums[ii]);
                pow*=10;
            }
            return sum;
        }

        // FROM PE24
        static void nextPermutation(int[] nums)
        {
            int pivot = 0;
            int successor = 0;

            /*
             * 1. scan the array from right-to-left (indices descending from N-1 to 0)
                1.1. if the current element is less than its right-hand neighbor,
                     call the current element the pivot,
                     and stop scanning
                1.2. if the left end is reached without finding a pivot,
                     reverse the array and return
                     (the permutation was the lexicographically last, so its time to start over)
             * */
            for (int ii = nums.Length - 2; ii >= 0; ii--)
            {
                if (nums[ii] < nums[ii + 1])
                {
                    pivot = ii;
                    break;
                }
                else if (ii == 0)
                {
                    Array.Reverse(nums);
                    g_bDone = true; // HACK
                    return;
                }
            }

            // scan the array from right-to-left again, to find the rightmost
            //  element larger than the pivot (call that one the successor)
            for (int ii = nums.Length - 1; ii >= 0; ii--)
            {
                if (nums[ii] > nums[pivot])
                {
                    successor = ii;
                    break;
                }
            }

            // swap the pivot and the successor
            int temp = nums[pivot];
            nums[pivot] = nums[successor];
            nums[successor] = temp;

            // reverse the portion of the array to the right of where the pivot was found
            if (pivot < nums.Length - 2)
            {
                int idx = 1;
                for (int jj = pivot + 1; jj < nums.Length - idx; jj++)
                {
                    int temp2 = nums[jj];
                    nums[jj] = nums[nums.Length - idx];
                    nums[nums.Length - idx] = temp2;
                    idx++;
                }
            }


            // return nums;
        }
    }
}
