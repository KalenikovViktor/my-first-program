using System;

namespace lesson_6_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 10;
            int[] array = new int[N];                   // 10 items
            int[] array1 = new[] { 1, 2, 3, 4, 5 };     // 5 items
            int[] array2 = { 12, 522, 2523, 24, 0 };    // 5 items

            array[0] = 18;
            array[1] = 34;
            array[6] = 12;

            int i = 0;
            for (i = 0; i < N; i++)
            {
                int value = array[i];
                array[i] = i;
            }

            for (i = 0; i < N; i++)
            {
                Console.WriteLine($"{i} item of array is {array[i]}");
            }

            int q = 0;
            q = 0;
            Console.WriteLine("------------------------------------");

            for (i = 0; i < array1.Length; i++)
            {
                Console.WriteLine($"{i} item of array is {array1[i]}");
            }

            Console.WriteLine("------------------------------------");

            i = -1;
            foreach (int item in array2)
            {
                Console.WriteLine($"{++i} item of array is {item}");
            }

            int multiplier = 2;
            var copiedArray = Copy(array);
            MultipleByNumber(array, multiplier);

            Console.WriteLine("------------------------------------");

            i = -1;
            foreach (int item in copiedArray)
            {
                Console.WriteLine($"{++i} item of array is {item}");
            }

            i = -1;
            foreach (var item in InitArray(10, 20))
            {
                Console.WriteLine($"{++i} item of array is {item}");
            }

            var random = new Random();
            int[] randomArray = new int[N];
            for (i = 0; i < N; i++)
            {
                randomArray[i] = random.Next(100);
            }

            Console.WriteLine("------------------------------------");

            i = -1;
            foreach (int item in randomArray)
            {
                Console.WriteLine($"{++i} item of array is {item}");
            }
            
            Console.WriteLine("------------------------------------");

            i = -1;
            foreach (int item in Sort(randomArray))
            {
                Console.WriteLine($"{++i} item of array is {item}");
            }
        }

        // 2, 6, 5, 1
        // 2, 5, 1, 6
        // 2, 1, 5, 6
        // 1, 2, 5, 6
        static int[] Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // ReSharper disable once SwapViaDeconstruction
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            return array;
        }

        static int[] InitArray(int a, int b)
        {
            int[] init = new int [b - a];
            Console.WriteLine($"array length is {init.Length}");
            for (int i = 0; i < init.Length; i++)
            {
                init[i] = a++;
            }

            return init;
        }

        static int[] Copy(int[] array)
        {
            int[] copy = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                copy[i] = array[i];
            }

            return copy;
        }

        static int[] MultipleByNumber(int[] array, int multiplier)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= multiplier;
            }

            multiplier = 10;
            return array;
        }
    }
}