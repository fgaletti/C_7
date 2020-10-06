using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_7.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Simple query Lambda ");
            Console.WriteLine("2)  Simple Query");
            Console.WriteLine("3)  chaining");
            Console.WriteLine("4)  Operators");
            Console.WriteLine("5)  reevaluation");
            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");

            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            switch (Console.ReadLine())
            {
                case "1":
                  
                    IEnumerable<string> filteredNames = names.Where(n => n.Length >= 4);

                    // Create custom extensions
                    // Test where2: IEnumerable<string> filteredNames11 = names.Where2(n => n.Length >= 4);

                    foreach (var name in filteredNames)
                    {
                        Console.WriteLine(name);
                    }

                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;

                case "2":
                    // query sintax 1
                  
                    IEnumerable<string> filteredNames2 = from n in names
                                                         where n.Length > 2
                                                         select n;

                    foreach (var name in filteredNames2)
                    {
                        Console.WriteLine(name);
                    }

                    Console.WriteLine("finishing simple query");
                    Console.ReadKey();
                    return true;

                case "3":
                    // chaining queries
                    IEnumerable<string> query = names
                        .Where(n => n.Length >= 4)
                        .OrderBy(n => n.Length)
                        .Select(n => n.ToUpper());

                    foreach (var name in query)
                    {
                        Console.WriteLine(name);
                    }

                    Console.WriteLine("finishing chaining queries");
                    Console.ReadKey();
                    return true;

                case "4":
                    // STANDAR QUERY OPERATORS -> utilize
                    // generic FUNC delegates.
                    // operators
                    int[] numbers = { 10, 9, 8, 7, 6 };

                    int secondNumber = numbers.ElementAt(1);
                    int secondLowest = numbers.OrderBy(n => n).Skip(1).First(); // 7
                    int count = numbers.Count();
                    int min = numbers.Min();

                    bool hasNumberNine = numbers.Contains(9);
                    bool hasMoreThanZero = numbers.Any();
                    bool hasAnOddElement = numbers.Any(n => n % 2 != 0);


                    Console.WriteLine("finishing chaining queries");
                    Console.ReadKey();
                    return true;

                case "5":
                    // REEVALUATION / DEFERRED QUERIES
                    var number = new List<int>() { 1, 2 };

                    IEnumerable<int> query5 = number.Select(n => n * 10);

                    List<int> listTens = number.Select(n => n * 10).ToList();

                    // clear
                    foreach (int n in query5)
                    {
                        Console.WriteLine(n + "|"); //NOTHING
                    }

                    number.Clear();

                    foreach (int n in query5)
                    {
                        Console.WriteLine(n + "|");
                    }

                    // No Reevaluation
                    Console.WriteLine(listTens.Count);

                    Console.WriteLine("finishing REEVALUATION queries");
                    Console.ReadKey();
                    return true;

                case "99":
                    Environment.Exit(0);
                    return true;
                default:
                    return true;
            }
        }
    }

    public static class MyExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static IEnumerable<TSource> Where3<TSource>(this IEnumerable<TSource> source
                                                        )
        {
            List<TSource> tempList = new List<TSource>();
            foreach (var item in source)
            {
                if (item is string && item.ToString().Length < 4)
                {

                    tempList.Add(item);
                }
            }
            return tempList;
        }

        public static IEnumerable<TSource> Where2<TSource>(this IEnumerable<TSource> source,
                                                         Func<TSource, bool> predicate)
        {
            List<TSource> tempList = new List<TSource>();
            foreach (var item in source)
            {
                if (item is string && item.ToString().Length < 4)
                {

                    tempList.Add(item);
                }
            }
            return null;
        }
    }
}
