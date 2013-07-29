using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PELib;
using System.Numerics;

namespace PE62
{
    class Program
    {
        class Item
        {
            public BigInteger small = new BigInteger(0);
            public int count = 0;

        }


        static void Main(string[] args)
        {
            /*
            The cube, 41063625 (3453), can be permuted to produce two other cubes: 56623104 (3843) and 66430125 (4053). In fact, 41063625 is the smallest cube which has exactly three permutations of its digits which are also cube.

            Find the smallest cube for which exactly five permutations of its digits are cube.
             */

            var dic = new Dictionary<string, Item>();

            int ii = 345;

            do
            {
                BigInteger cube = BigInteger.Pow(new BigInteger(ii), 3);

                string sCube = cube.ToString();
                sCube = Alphabetize(sCube);

                if (dic.Keys.Contains(sCube))
                {
                    dic[sCube].count++;
                    if (dic[sCube].count > 4)
                    {
                        PELib.Util.ShowResult(dic[sCube].small);
                    }
                }
                else
                {
                    var item = new Item();
                    item.small = cube;
                    item.count = 1;
                    dic.Add(sCube, item);
                }

                ii++;
            } while (true);

        }

        /// <summary>
        /// Alphabetize the characters in the string.
        /// </summary>
        public static string Alphabetize(string s)
        {
            // 1.
            // Convert to char array.
            char[] a = s.ToCharArray();

            // 2.
            // Sort letters.
            Array.Sort(a);

            // 3.
            // Return modified string.
            return new string(a);
        }
    }
    
}
