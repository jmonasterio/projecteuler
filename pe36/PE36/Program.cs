using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE36
{
    class Program
    {
        /*
         * The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.

Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

(Please note that the palindromic number, in either base, may not include leading zeros.)
         */
        static void Main(string[] args)
        {
            int sum = 0;
            for (int ii = 1; ii < 1000000; ii += 2) // Count by 2's because leading zeroes in binary not allowed.
            {
                string decimalString = "" + ii;
                if (!decimalString.EndsWith("0"))
                {
                    if (IsPalindrome(decimalString))
                    {
                        string hexString = String.Format("{0:x}", ii);
                        //Console.WriteLine(hexString);

                        string binaryString = "";
                        // convert hex to binary (easy)
                        for (int jj = 0; jj < hexString.Length; jj++)
                        {
                            switch (hexString[jj])
                            {
                                case '0': binaryString += "0000"; break;
                                case '1': binaryString += (jj == 0 ? "1" : "0001"); break;
                                case '2': binaryString += (jj == 0 ? "10" : "0010"); break;
                                case '3': binaryString += (jj == 0 ? "11" : "0011"); break;
                                case '4': binaryString += (jj == 0 ? "100" : "0100"); break;
                                case '5': binaryString += (jj == 0 ? "101" : "0101"); break;
                                case '6': binaryString += (jj == 0 ? "110" : "0110"); break;
                                case '7': binaryString += (jj == 0 ? "111" : "0111"); break;
                                case '8': binaryString += "1000"; break;
                                case '9': binaryString += "1001"; break;
                                case 'a': binaryString += "1010"; break;
                                case 'b': binaryString += "1011"; break;
                                case 'c': binaryString += "1100"; break;
                                case 'd': binaryString += "1101"; break;
                                case 'e': binaryString += "1110"; break;
                                case 'f': binaryString += "1111"; break;
                            }
                        }

                        if (!binaryString.EndsWith("0"))
                        {
                            if (IsPalindrome(binaryString))
                            {
                                Console.WriteLine("" + ii + "  " + hexString + "  " + binaryString);
                                sum += ii;
                            }
                        }
                    
                    }

                }
            }

            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }

        static bool IsPalindrome(string ss)
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
