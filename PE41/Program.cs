using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE41
{
    /*
     * We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is also prime.

    What is the largest n-digit pandigital prime that exists?
     */
    class Program
    {
        // Try all the permutations of 123456789
        static void Main(string[] args)
        {
            int largest = 0;
            int[] nums = new[] { 1, 2, 3, 4, 5, 6, 7}; // This is a total hack! Including 8 or 8,9 did not find any primes.

            for (int ii = 1; ii < 1000000; ii++)
            {
                // Would be more efficient to go backwards.
                nextPermutation(nums);


                int value = MakeInt(nums);
                if (value > largest)
                {
                    if (is_prime(value))
                    {
                        largest = value;
                        Console.WriteLine(dump(nums));
                    }
                }

            }
            Console.WriteLine( largest);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }

        static int MakeInt(int[] nums)
        {
            int val = 0;
            int pow = 1;
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
        static void nextPermutation( int[] nums)
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
                    return;
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


           // return nums;

        }

                            // naive prime test.
        static bool is_prime(long num)
        {
            if (num == 2 || num == 3) { return true; }
            for (int ii = 2; ii <= Math.Sqrt(num); ii++)
            {
                if (num % ii == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
