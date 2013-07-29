using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE38
{
    /* Take the number 192 and multiply it by each of 1, 2, and 3:

        192 x 1 = 192
        192 x 2 = 384
        192 x 3 = 576
        By concatenating each product we get the 1 to 9 pandigital, 192384576. We will call 192384576 the concatenated product of 192 and (1,2,3)

        The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, giving the pandigital, 918273645, which is the concatenated product of 9 and (1,2,3,4,5).

        What is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an integer with (1,2, ... , n) where n  1?
     */
    class Program
    {
        static void Main(string[] args)
        {
            int nMaxPanDigital = 0;

            for (int aa = 2; aa < 10; aa++)
            {
                // init array
                int[] array = new int[aa];
                for (int ii = 0; ii < array.Length; ii++)
                {
                    array[ii] = ii + 1;
                }

                for (int n = 1; n < 100000; n++)
                {
                    int nPanDigital = MakePandigital(n, array);

                    if (nPanDigital > nMaxPanDigital)
                    {
                        nMaxPanDigital = nPanDigital;
                    }
                }
            }


            
            Console.WriteLine("Max: " + nMaxPanDigital);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();


        }

        // return -1 if not pan digital.
        static int MakePandigital(int n, int[] array)
        {
            string s = "";
            for (int ii = 0; ii < array.Length; ii++)
            {
                s += "" + n * array[ii];
            }
            if (s.Length != 9)
            {

                return -1;
            }
            for (int dig = 1; dig < 10; dig++)
            {
                if (!s.Contains("" + dig))
                {
                    return -1;
                }
            }
            return int.Parse(s);
        }
    }
}
