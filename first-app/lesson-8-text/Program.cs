using System;
using System.IO;
using System.Text.RegularExpressions;

namespace lesson_8_text
{
    internal class Program
    {
        private static void Main()
        {
            string filePath = "Phone Book.csv";
            string namesFile = "names.list";        //contains names list in order to be able generate a new record
            string[] randomNames = FromFile(namesFile);
            string[] names = FromFile(filePath);

            var book = Deserialize(names);          //convert strings to .net object
            Add(ref book, GenerateRecord(randomNames));
            Update(book, GenerateRecord(randomNames), 0);
            //Delete(ref book, 0);
            
            Console.WriteLine("Here is all list");
            Print(book);

            Console.WriteLine($"{BinarySearch(book, x => x.name, "Maria")} was fount by name");
            Console.WriteLine($"{BinarySearch(book, x => x.number, 1430127282)} was fount by number");

            ToFile(Serialize(book), filePath);
        }

        private static void Print((string name, int number)[] book)
        {
            foreach (var item in book)
            {
                Console.WriteLine($"{item.name} which phone number is {item.number}");
            }
        }

        private static void Add(ref (string name, int number)[] book, (string name, int number) newRecord)
        {
            var newBook = new (string name, int number)[book.Length + 1];
            book.CopyTo(newBook, 0);
            newBook[book.Length] = newRecord;
            book = newBook;
        }

        private static void Update((string name, int number)[] book, (string name, int number) record, int index)
        {
            book[index] = record;
        }

        // ReSharper disable once UnusedMember.Local
        private static void Delete(ref (string name, int number)[] book, int index)
        {
            var newBook = new (string name, int number)[book.Length - 1];
            var i = 0;
            for (var j = 0; j < book.Length; j++)
            {
                if (j != index)
                {
                    newBook[i++] = book[j];
                }
            }

            book = newBook;
        }

        private static (string name, int number)[] AsSorted<T>((string name, int number)[] book, Func<(string name, int number), T> selector) where T: IComparable
        {
            var newBook = new (string name, int number)[book.Length];
            book.CopyTo(newBook, 0);
            for (var i = 0; i < newBook.Length; i++)
            {
                for (var j = 0; j < newBook.Length - 1; j++)
                {
                    if (selector(newBook[j]).CompareTo(selector(newBook[j + 1])) == 1)
                    {
                        (newBook[j], newBook[j + 1]) = (newBook[j + 1], newBook[j]);
                    }
                }
            }

            return newBook;
        }

        private static (string name, int number)? BinarySearch<T>((string name, int number)[] book, Func<(string name, int number), T> selector, T searchedValue)
            where T : IComparable
        {
            (string name, int number)? MiddleValue((string name, int number)[] valueTuples, Func<(string name, int number), T> func, T comparable, int first, int last)
            {
                if (first > last)
                {
                    return null;
                }

                var middle = (first + last) / 2;
                var middleValue = valueTuples[middle];

                if (func(middleValue).CompareTo(comparable) == 0)
                {
                    return middleValue;
                }

                return func(middleValue).CompareTo(comparable) == 1
                    ? MiddleValue(valueTuples, func, comparable, first, middle - 1)
                    : MiddleValue(valueTuples, func, comparable, middle + 1, last);
            }

            return MiddleValue(AsSorted(book, selector), selector, searchedValue, 0, book.Length);
        }

        private static (string name, int number) GenerateRecord(string[] names)
        {
            var random = new Random();
            return (names[random.Next(names.Length)], random.Next());
        }

        private static string[] FromFile(string filePath) => File.ReadAllLines(filePath);

        private static void ToFile(string[] content, string filePath)
        {
            File.WriteAllLines(filePath, content);
        }

        private static string[] Serialize((string name, int number)[] content)
        {
            var toFile = new string[content.Length];
            for (var i = 0; i < content.Length; i++)
            {
                var (name, number) = content[i];
                toFile[i] = $"{name};{number}";
            }

            return toFile;
        }

        private static (string name, int number)[] Deserialize(string[] names)
        {
            var regex = new Regex(@"^(\w+);(\d+)$");
            var book = new (string name, int number)[names.Length];
            for (var index = 0; index < names.Length; index++)
            {
                var item = names[index];
                var match = regex.Match(item);

                if (match.Success)
                {
                    book[index].name = match.Groups[1].Value;
                    book[index].number = int.Parse(match.Groups[2].Value);
                }
            }

            return book;
        }
    }
}