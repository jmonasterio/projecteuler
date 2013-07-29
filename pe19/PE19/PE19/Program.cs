using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE19
{
    class Program
    {
        static int DaysInMonth(int mon, int yr)
        {
            switch(mon)
            {
                case 9:
                case 4:
                case 6:
                case 11: return 30;
                case 2:
                    {
                        if( yr %4 == 0 )
                        {
                            if (yr % 400 == 0)
                            {
                                return 28;
                            }

                            return 29;
                        }
                        else 
                        {
                            return 28;
                        }
                    }

                default: return 31;
            }
        }

        static void Main(string[] args)
        {
            int cntSundaysOnFirstOfMonth = 0;
            int day =6; // Sun - Jan - 6 -1901 
            int mon = 1;
            int yr = 1901;
            int daysInMonth = DaysInMonth(mon,yr);

            do
            {
                day += 7;
                if (day > daysInMonth)
                {
                    day = (day - daysInMonth);  // 7 - (31-28) = 4   28 .. 29 .. 30 .. 31 .. 1 .. 2 .. 3 .. 4
                    mon++;
                    if (mon > 12)
                    {
                        mon = 1;
                        yr++;
                    }
                    if (yr > 2000)
                    {
                        break;
                    }
                    daysInMonth = DaysInMonth(mon, yr);
                    if (day == 1) // We just incremented month. It is Sunday because we are incrementing weeks.
                    {
                        Console.WriteLine("" + yr + "-" + mon + "-" + day);
                        cntSundaysOnFirstOfMonth++;
                    }
                }

            } while (true);

            Console.WriteLine(cntSundaysOnFirstOfMonth);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}
