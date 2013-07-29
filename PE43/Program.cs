using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE43
{
    class Program
    {
        /* The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.

Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:

d2d3d4=406 is divisible by 2
d3d4d5=063 is divisible by 3
d4d5d6=635 is divisible by 5
d5d6d7=357 is divisible by 7
d6d7d8=572 is divisible by 11
d7d8d9=728 is divisible by 13
d8d9d10=289 is divisible by 17
Find the sum of all 0 to 9 pandigital numbers with this property.
         */

        // Try all the permutations of 123456789
        static void Main(string[] args)
        {
            int[] nums = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9}; // This is a total hack! Including 8 or 8,9 did not find any primes.
            long sum = 0;
            bool bMore;

            int[] DIVISORS = new int[]{2,3,5,7,11,13,17};
           do
            {
               int pos = 1;
               bool divisibleByAll = true;

               foreach( int div in DIVISORS)
               {
                  if( (nums[pos]*100+nums[pos+1]*10+nums[pos+2]) % div != 0)
                  {
                      divisibleByAll = false;
                      break;
                  }
                  pos++;
               }

               if( divisibleByAll)
               {
                   long debug = MakeLong(nums);
                   Console.WriteLine(debug);
                   sum += debug;
               }

                bMore = nextPermutation(nums);
           }
            while( bMore);

            Console.WriteLine( sum);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }

        static long MakeLong(int[] nums)
        {
            long val = 0;
            long pow = 1;
            for (int ii = 0; ii < nums.Length; ii++)
            {
                val += (nums[nums.Length - ii -1] * pow);
                pow *= 10;
            }
            return val;
        }

        static string dump(int[] nums)
        {
            string s = "";
            for( int ii= 0; ii<nums.Length; ii++)
            {
                s += "" + nums[ii];
            }
            return s;
        }

        /* FROM PE24 */
        static bool nextPermutation( int[] nums)
        {
            int pivot= 0;
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
                if( nums[ii] < nums[ii+1])
                {
                    pivot = ii;
                    break;
                }
                else if (ii == 0)
                {
                    Array.Reverse(nums);
                    return false;
                }
            }

            // scan the array from right-to-left again, to find the rightmost
            //  element larger than the pivot (call that one the successor)
            for( int ii=nums.Length-1; ii>=0; ii--)
            {
                if( nums[ii]> nums[pivot])
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
                for (int jj = pivot + 1; jj < nums.Length-idx; jj++)
                {
                    int temp2 = nums[jj];
                    nums[jj] = nums[nums.Length - idx];
                    nums[nums.Length - idx] = temp2;
                    idx++;
                }
            }


           return true;

        }


    }
}
