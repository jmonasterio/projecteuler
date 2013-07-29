using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE17
{
    class Program
    {
        static string MakeWordWithNoSpace( int ii)
        {
            string sret = "";

            int ones = ii%10;
            ii = ii/10;

            int tens = ii%10;
            ii = ii/10;

            int hundreds = ii%10;
            ii = ii/10;

            int thousands = ii%10;
            ii = ii/10;

            if( (ones > 0) & (tens != 1))
            {
                switch(ones)
                {
                    case 1: sret = "one"; break;
                    case 2: sret = "two"; break;
                    case 3: sret = "three"; break;
                    case 4: sret = "four"; break;
                    case 5: sret = "five"; break;
                    case 6: sret = "six"; break;
                    case 7: sret = "seven"; break;
                    case 8: sret = "eight"; break;
                    case 9: sret = "nine"; break;
                }
            }
            if( tens == 1)
            {
                switch( ones)
                {
                    case 0: sret = "ten"; break;
                    case 1: sret = "eleven"; break;
                    case 2: sret = "twelve"; break;
                    case 3: sret = "thirteen"; break;
                    case 4: sret = "fourteen"; break;
                    case 5: sret = "fifteen"; break;
                    case 6: sret = "sixteen"; break;
                    case 7: sret = "seventeen"; break;
                    case 8: sret = "eighteen"; break;
                    case 9: sret = "nineteen"; break;
                }
            }
            else if( tens > 1)
            {
                switch( tens)
                {
                    case 2: sret = "twenty" + sret; break;
                    case 3: sret = "thirty" + sret; break;
                    case 4: sret = "forty" + sret; break;
                    case 5: sret = "fifty" + sret; break;
                    case 6: sret = "sixty" + sret; break;
                    case 7: sret = "seventy" + sret; break;
                    case 8: sret = "eighty" + sret; break;
                    case 9: sret = "ninety" + sret; break;
                }
            }
            if(hundreds > 0)
            {

                if (sret.Length > 0)
                {
                    sret = "and" + sret;
                }
                
                switch (hundreds)
                {
                    case 1: sret = "onehundred" + sret; break;
                    case 2: sret = "twohundred" + sret; break;
                    case 3: sret = "threehundred" + sret; break;
                    case 4: sret = "fourhundred" + sret; break;
                    case 5: sret = "fivehundred" + sret; break;
                    case 6: sret = "sixhundred" + sret; break;
                    case 7: sret = "sevenhundred" + sret; break;
                    case 8: sret = "eighthundred" + sret; break;
                    case 9: sret = "ninehundred" + sret; break;
                }
            }
            if( thousands == 1)
            {
                sret = "onethousand";
            }
            else if( thousands > 0)
            {
                System.Diagnostics.Debug.Assert(false, "Bad thousands");

            }
            return sret;
        }

        static void Main(string[] args)
        {
            string letters = "";


            for (int ii = 1; ii <= 1000; ii++)
            {
                letters += MakeWordWithNoSpace(ii);
            }

            Console.WriteLine(letters.Length);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}
