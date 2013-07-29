using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Numerics;


namespace PELib
{
    public class Util
    {
        public static bool Swap<T>(ref T x, ref T y)
        {
            try
            {
                T t = y;
                y = x;
                x = t;
                return true;
            }
            catch
            {
                return false;
            }
        }

        // n - CHOOSE - r
        /*
         * 
            nCr = n!/(r!(n-r)!), where r  <= n, n! = n(n-1)...3x2x1, and 0! = 1.
         * 
         */
        public static BigInteger C(int n, int r)
        {
            BigInteger bn = Factorial(n);
            BigInteger br = Factorial(r);
            BigInteger bnr = Factorial(n - r);

            return bn /( br *  bnr);
        }

        public static BigInteger Factorial(int n)
        {
            BigInteger f = new BigInteger(1);

            while( n>0) 
            {
                f = f * n;
                n--;
            }

            return f;

        }


        public static bool IsOdd( long num) 
        {
            return (num % 2 != 0);
        }

        public static bool IsEven( long num)
        {
            return (num % 2 == 0);
        }

        public static void ShowResult<T>( T result)
        {
            Console.WriteLine( result);
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }

        // naive prime test.
        public static bool IsPrime(long num)
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

        public static IEnumerable PrimeGenerator(long startIdx)
        {
            while (true)
            {
                while (!IsPrime(startIdx))
                {
                    startIdx++;
                }
                yield return startIdx;
                startIdx++;
            }
        }

        public static IEnumerable PrimeGenerator(long startIdx, long max)
        {
            while (true)
            {
                while (!IsPrime(startIdx))
                {
                    startIdx++;

                    if (startIdx > max)
                    {
                        goto Exit;
                    }
                }
                yield return startIdx;
                startIdx++;
            }
        Exit: ;

        }

        public static IEnumerable PrimeGeneratorReverse(long startIdx)
        {
            while (startIdx>1)
            {
                while (!IsPrime(startIdx))
                {
                    startIdx--;
                }
                yield return startIdx;
                startIdx--;
            }
        }

        public static IEnumerable CompositeGenerator(long startIdx)
        {
            while (true)
            {
                while (IsPrime(startIdx))
                {
                    startIdx++;
                }
                yield return startIdx;
                startIdx++;
            }
        }

        public static IEnumerable TriangleGenerator(long startIdx)
        {
            while (true)
            {
                long next = (startIdx) * (startIdx + 1) / 2;
                yield return next;
                startIdx++;
            }
        }

        public static IEnumerable SquareGenerator(long startIdx)
        {
            while (true)
            {
                long next = (startIdx) * (startIdx);
                yield return next;
                startIdx++;
            }
        }

        /* Given that P=n(3n-1)/2, we get the quadratic, 3n2-n-2P=0, and using the quadratic formula, 
         *  n=(1+√(1+24P))/6 (only taking positive root). 
         *  In other words, if the number being test, P, produces an integer in the formula, then it is a pentagon number. 
         */
        public static bool IsPentagonal(long s)
        {
            double v = ((1 + Math.Sqrt(1 + 24 * s)) / 6);
            if ((v - (int)v) < .00000000001)
            {
                return true;
            }
            return false;
        }

        public static IEnumerable PentagonalGenerator(long startIdx)
        {
            while (true)
            {
                long next = (startIdx) * (3 * startIdx - 1) / 2;
                yield return next;
                startIdx++;
            }
        }

        public static IEnumerable HexagonalGenerator(long startIdx)
        {
            while (true)
            {
                long next = (startIdx) * (2 * startIdx - 1);
                yield return next;
                startIdx++;
            }
        }

        public static IEnumerable HeptagonalGenerator(long startIdx)
        {
            while (true)
            {
                long next = (startIdx) * (5 * startIdx - 3)/2;
                yield return next;
                startIdx++;
            }
        }

        public static IEnumerable OctagonalGenerator(long startIdx)
        {
            while (true)
            {
                long next = (startIdx) * (3 * startIdx - 2);
                yield return next;
                startIdx++;
            }
        }

        // 1,2,1, 1,4,1, 1,6,1 , ... , 1,2k,1, ...
        public static IEnumerable EGenerator()
        {
            int n = 1;
            while (true)
            {
                yield return 1;
                yield return n * 2;
                yield return 1;
                n++;
            }
        }

        public static IEnumerable NonSquareGenerator(long startIdx)
        {

            while (true)
            {
                if (!Util.IsPerfectSquare(startIdx))
                { 
                    yield return startIdx;
                }
                startIdx++;
            }
        }

        private static BigInteger[] ConvertContinuedFractionToFraction(List<long> frac)
        {
            BigInteger num = new BigInteger(1);
            var denom = new BigInteger(frac[frac.Count - 1]);

            for (int ii = frac.Count; ii > 2; ii--)
            {
                long pp = frac[ii - 2]; // prev

                num += pp * denom;
                Util.Swap(ref num, ref denom); // take recip

            }

            // Add 2
            num += denom * frac[0];

            //Console.WriteLine("NUM: " + num + " DENOM: " + denom);

            return new BigInteger[] { num, denom };
        }

        // Returns each continued fraction like: http://en.wikipedia.org/wiki/Pell's_equation
        public static IEnumerable ContinuedFractionSquareRootGenerator(long n)
        {
            var frac = new List<long>();


            // Step 1 find whole number that starts continued fraction
            // sqrt(n) = m + 1/x
            long m= (int)Math.Sqrt(n);

            frac.Add(m);
            yield return new BigInteger[] { new BigInteger(m), new BigInteger(1) };

            long b = 1;
            long a = 0;  //( sqrt(n) + a) / b 

            do
            {

                // Step 2. Rearrange the equation in step 1 into the form of x equals an expression involving the square root of which
                //  will appear as the denominator of the fraction: x = 1/(sqrt(n) - m)

                // new m

                // convert to
                // x1 = (c1 /(sqrt(n) - d1)
                long a1 = -(a - m * b);
                long b1 = ( n - (a - m * b) * (a - m * b)) / b;

                a = a1;
                b = b1;

                if (b == 0) 
                {
                    // Done -- simple square.
                    //break;
                }

                m = ((long)Math.Sqrt(n) + a) / b;


                frac.Add(m);
                yield return ConvertContinuedFractionToFraction(frac);


                // Done
                if (b == 1)
                {
                    //break;
                }

            } while( true);

              
        }

        // From: http://stackoverflow.com/questions/295579/fastest-way-to-determine-if-an-integers-square-root-is-an-integer
        public static bool IsPerfectSquare(long n)
        {
            if (n < 0)
                return false;

            switch ((int)(n & 0xF))
            {
                case 0:
                case 1:
                case 4:
                case 9:
                    long tst = (long)Math.Sqrt(n);
                    return tst * tst == n;

                default:
                    return false;
            }
        }


        public static bool IsPerfectSquare(BigInteger n)
        {
           // if (n < 0)
            //    return false;

            //double tst = Math.Exp(BigInteger.Log(n)/2);

            BigInteger sr = Sqrt(n);
            bool bIs = BigInteger.Compare(BigInteger.Pow(sr, 2), n) == 0;

            //bool bIs = BigInteger.Compare( BigInteger.Pow(new BigInteger(tst),2), n) == 0;
            return bIs;
        }

        static BigInteger Sqrt(BigInteger number)
        {
            // problem with lower numbers to to right bit shift
            int bitLength = number.ToByteArray().Length * 8 + 1;
            BigInteger G = number >> bitLength / 2;
            BigInteger LastG = BigInteger.Zero;
            BigInteger One = new BigInteger(1);
            while (true)
            {
                LastG = G;
                G = (number / G + G) >> 1;
                int i = G.CompareTo(LastG);
                if (i == 0) return G;
                if (i < 0)
                {
                    if ((LastG - G).CompareTo(One) == 0)
                        if ((G * G).CompareTo(number) < 0 &&
                          (LastG * LastG).CompareTo(number) > 0) return G;
                }
                else
                {
                    if ((G - LastG).CompareTo(One) == 0)
                        if ((LastG * LastG).CompareTo(number) < 0 &&
                          ((G * G).CompareTo(number) > 0)) return LastG;
                }
            }
        }

        public static long GreatestPrimeFactor(long num)
        {
            long gpf = 0;

            long prime = 2;
            while( true)
            {
                if( num % prime == 0)
                {
                    // Is factor.
                    num = num / prime;
                    if (IsPrime(num))
                    {
                        // The other factor is prime.
                        return Math.Max(num, prime);
                    }
                    gpf = prime;
                    prime = 2;
                }
                else
                {
                    prime = NextPrime( prime, (long) Math.Sqrt(num));
                    if( 0 == prime)
                    {
                        // Reached max!
                        return gpf;
                    }

                }
            }
        }

        public static long CountUniquePrimeFactors(long num)
        {
            long gpf = 0;

            long prime = 2;
            List<long> factors = new List<long>();

            while (true)
            {
                if (num % prime == 0)
                {
                    // Is factor.
                    num = num / prime;

                    if (!factors.Contains(prime))
                    {
                        factors.Add(prime);
                    }

                    if (Util.IsPrime(num))
                    {
                        // The other factor is prime.
                        long otherPrime = Math.Max(num, prime);

                        if (!factors.Contains(otherPrime))
                        {
                            factors.Add(otherPrime);
                        }

                        return factors.Count;
                    }
                    gpf = prime;
                    prime = 2;
                }
                else
                {
                    prime = Util.NextPrime(prime, (long)Math.Sqrt(num));
                    if (0 == prime)
                    {
                        // Reached max!
                        return factors.Count;
                    }

                }
            }
        }

        public static long NextPrime(long prevPrime, long max)
        {
            long next = prevPrime;
            while (true)
            {
                next += 1;
                if (next > max)
                {
                    return 0;
                }
                if (IsPrime(next))
                {
                    return next;
                }
            }

        }

        public static string AddLongString(string op1, string op2)
        {
            string sum = "";

            // I know the first op1 is always longer (or as long as op2);
            System.Diagnostics.Debug.Assert(op1.Length >= op2.Length);

            int carry = 0;

            int len1 = op1.Length;
            int len2 = op2.Length;

            for (int ii = 0; ii < len1; ii++)
            {
                int dig1 = int.Parse(op1.Substring(len1 - ii - 1, 1));
                int dig2;

                if (ii < len2)
                {
                    dig2 = int.Parse(op2.Substring(len2 - ii - 1, 1));
                }
                else
                {
                    dig2 = 0;
                }

                int digSum = dig1 + dig2 + carry;
                if (digSum <= 9)
                {
                    sum = "" + digSum + sum;
                    carry = 0;
                }
                else
                {
                    sum = "" + (digSum % 10) + sum;
                    carry = 1;
                }
            }
            if (carry != 0)
            {
                sum = "1" + sum;
            }
            return sum;
        }

        // naive - repeated addition;
        public static String MultiplyLongString(string op1, int multiplicand)
        {
            for (int ii = 0; ii < multiplicand; ii++)
            {
                op1 = AddLongString(op1, op1);
            }
            return op1;
        }

        public static long ArrayOfDigitsToLong(int[] nums, int start, int end)
        {
            long sum = 0;
            long pow = 1;
            for (int ii = end; ii >= start; ii--)
            {
                sum += (pow * nums[ii]);
                pow *= 10;
            }
            return sum;
        }

        public static int[] LongToArrayOfDigits(long num)
        {
            List<int> answer = new List<int>();
            do
            {
                int digit = (int) (num % 10);
                answer.Add(digit);
                num = num / 10;
            } while (num > 0);

            answer.Reverse();

            return answer.ToArray<int>();
        }

        // FROM PE24
        public static IEnumerable LexographicPermutationGenerator(int[] nums)
        {
            while (true)
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
                        // THE END
                        // Array.Reverse(nums);
                        yield break;
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


                yield return ArrayOfDigitsToLong(nums, 0, nums.Length - 1);
            }
        }

        // Return array instead of long.
        public static IEnumerable LexographicPermutationGeneratorArray(int[] nums)
        {
            while (true)
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
                        // THE END
                        // Array.Reverse(nums);
                        yield break;
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


                yield return nums;
            }
        }


        public static bool IsPalindrome(string ss)
        {
            return ss == ReverseString(ss);
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

    }
}
