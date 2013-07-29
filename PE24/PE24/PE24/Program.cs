using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE24
{
    class Program
    {

        /*
         * A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

            012   021   102   120   201   210

            What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
         */
        static void Main(string[] args)
        {
            int[] nums = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 , 9};

            for (int ii = 1; ii < 1000000; ii++)
            {
                //Console.WriteLine("" + ii + " : " + dump(nums));
                nextPermutation(nums);
            }
            Console.WriteLine( dump(nums));
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }

        static string dump( int[] nums)
        {
            string s = "";
            for( int ii= 0; ii<nums.Length; ii++)
            {
                s += "" + nums[ii];
            }
            return s;
        }

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
        /*

            012 SWAP
            021 2-3
            102 ALL
            120 2-3
            201 ALL
            210 2-3

            0123 
            0132 3-4
            0213 ALL
            0231 3-4
            0312 ALL
            0321 3-4
            

      0      0123456789
      1      0123456798 +9  !the next one is always greater than previouse
      2      0123456879 +81
      3      0123456897 +18
      4      0123456978 +81
      5            6987 +9
      6            7689 +702
      7            7698 +9
      8            7869 +171
      9            7896 +27
     10            7968 +72
     11            7986 +18
     12            8679 +693
     13            8
     14            8
     15            8
     16            8
     17            8
     18            9
     19            9
     20            9
     21            9
     22            9
     23            9
     24            65789 <- Flip next digit to first, and then Sort the rest lexographically.


      0      0123456789 9>8, // so swap 8 and 9
      1      0123456798 8<9, // so move 8 to left of 9
      2      0123456879 9>7, // so swap 9 and  7
      3      0123456897 7<9, // so move 
      4      0123456978 8>7
      5            6987 +9
      6            7689 +702
      7            7698 +9
      8            7869 +171
      9            7896 +27
     10            7968 +72
     11            7986 +18
     12            8679 +693
     13            8
     14            8
     15            8
     16            8
     17            8
     18            9
     19            9
     20            9
     21            9
     22            9
     23            9
     24            65789 <- Flip next digit to first, and then Sort the rest lexographically.


*/


    }

    

}

