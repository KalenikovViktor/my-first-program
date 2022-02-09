using System;

namespace lesson_4_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = Sum(3, 5);
            Console.WriteLine(sum);
            Console.WriteLine(Sum(10, 20));             // 30
            Console.WriteLine(Sum(10, 20, true));       // 30
            Console.WriteLine(Sum(10, 20, false));      // -10
            Console.WriteLine(SumNumbers(10, 20));      // 145
            Console.WriteLine(SumNumbers(20, 10));      // 145

            int i = 10;             // 0x0001
            Increment(ref i);           
            Increment(ref i);           
            Console.WriteLine(i); // 12

            if (TryDivideByTree(i, out int result))
            {
                Console.WriteLine(result);
            }

            Concat(10, 20);             //  30
            Concat("10");                // "10
            Concat("10", "20");         // "10, 20"
            Concat("10", "20","30");      // "10, 20, 30" 
            Concat("10", "20", "30", "40");      // 4 



            Console.ReadKey();
        }

        static int Factorial(int value)
        {
            if (value == 1) return value;
            return value * Factorial(value - 1);
        }

        static void Concat(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        static void Concat(string a)
        {
            Console.WriteLine($"{a}");
        }

        static void Concat(string a, string b)
        {
            Console.WriteLine($"{a}, {b}");
        }

        static void Concat(string a, string b, string c)
        {
            Console.WriteLine($"{a}, {b}, {c}");
        }

        static void Concat(params string[] strings)
        {
            Console.WriteLine(strings.Length);
        }

        static bool TryDivideByTree(int a, out int result)
        {
            result = a / 3;
            return a % 3 == 0;
        }

        static int Increment(ref int i)
        {
            i++;            //0x0001
            return i;
        }

        static int Sum(int a, int b, bool r = true)
        {
            if (r) return a + b;
            else return a - b;
        }

        static int SumNumbers(int a, int b)
        {
            int sum = 0;
            for (int i = a; i <= b; i++)
            {
                sum += i;
            }

            return sum;
        }
    }
}
