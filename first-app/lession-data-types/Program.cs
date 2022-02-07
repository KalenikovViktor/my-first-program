using System;

namespace lession_data_types
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 2;
            int b = 3;

            short s = 300;
            int us = -234234;

            int i = 5;
            int result = ++i + i++;
            Console.WriteLine(-i);
            Console.WriteLine(result);

            bool isTrue = true;
            Console.WriteLine(!isTrue);

            Console.WriteLine(a * b);
            Console.WriteLine(6 / 4);
            Console.WriteLine(6 % 4);

            short biiiigInt = 32000;
            short biiiigInt1 = 32000;

            unchecked
            {
                short result1 = (short)(biiiigInt + short.Parse("32000"));
            }

            double aD = 3.4;
            double bD = 5.6;

            Console.WriteLine($"Double result is: {aD * bD - Math.Sqrt(100) / 5}");

            //2 - 00000010 => 00010000
            //2 - 00000010 => 00010000
            Console.WriteLine(a << b);
            Console.WriteLine(16 >> 100);

            int aA = 4;
            int bB = 10;

            Console.WriteLine(aA < bB); //true
            Console.WriteLine(aA > bB); // false
            Console.WriteLine(!(aA > bB)); // true
            Console.WriteLine(!(aA == bB)); // false


            bool aBool = true;
            bool bBool = false;
            Console.WriteLine(aBool | bBool); // true
            Console.WriteLine(aBool || bBool); // true

            //4 -  00000100
            //10 - 00001010
            //r    00001110
            Console.WriteLine(aA | bB); // 14

            //4 -  00000100
            //10 - 00001010
            //r    00000000
            Console.WriteLine(aA & bB); // 0

            //6 -  00000110
            //10 - 00001010
            //r    00001100
            Console.WriteLine(6 ^ 10); // 12

            //aA = 4;
            aA = aA + 10;
            aA += 10;
            Console.WriteLine(aA);

            double d = 3.23423423;
            Console.WriteLine(Math.Pow(d, 2)); // > 9
            Console.WriteLine(Math.Ceiling(d)); // 4
            Console.WriteLine(Math.Floor(d)); // 3
            Console.WriteLine(Math.Sign(-342)); //

            char aC = 'a';
            Console.WriteLine((char)(aC + 1));

            var now = DateTime.Now;
            Console.WriteLine(now);
            var yesterday = now.AddDays(-1);
            Console.WriteLine((now - yesterday).TotalSeconds);

            // 00000000 - 0
            // 11111111 - 255
            // 01111111 + 1 = 000000
        }
    }
}
