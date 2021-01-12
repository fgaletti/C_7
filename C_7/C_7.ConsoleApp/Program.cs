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
            Console.WriteLine("6)  subqueries");
            Console.WriteLine("7)  progrsive query building");
            Console.WriteLine("8)  INTO Keyword");
            Console.WriteLine("9)  WRAPPING QUERIES ");
            Console.WriteLine("10) OBJECT INITIALIZER ");
            Console.WriteLine("11) Anonymous Types ");
            Console.WriteLine("12) LET ");
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

                case "6":
                    // SUBQUERIES
                    // select names where lenght ==  min (lengyh
                    IEnumerable<string> outerQuery = names
                        .Where(n => n.Length == names.OrderBy(n2 => n2.Length)
                                .Select(n2 => n2.Length).First());

                    var outerQuery2 = from n in names
                                      where n.Length ==
                                      (from n2 in names
                                       orderby n2.Length
                                       select n2.Length).First()
                                      select n;

                    // succinctly 
                    IEnumerable<string> query6 =
                        from n in names
                        where n.Length == names.OrderBy(n2 => n2.Length).First().Length
                        select n;

                    // with the MIN Aggregation

                    IEnumerable<string> query61 =
                        from n in names
                        where n.Length == names.Min(n2 => n2.Length)
                        select n;

                    /* ALL This is inneffient for a LOCAL COLLECTION */
                    // pag: 473 
                    // -> solution: running a subquery separetly

                    int shortest = names.Min(n => n.Length);

                    IEnumerable<string> queryEffiecient =
                         from n in names
                         where n.Length == shortest
                         select n;

                    // fist , count - in a subquery does not force immediate execution

                    Console.WriteLine("finishing SUBQUERIES");
                    Console.ReadKey();
                    return true;

                case "7":
                    // PROGRESSIVE QUERY BUILDER

                    //SYNTAX QUERY
                    IEnumerable<string> query7 = names
                        .Select(n => n.Replace("a", "").Replace("e", "").Replace("i", "")
                                    .Replace("o", "").Replace("u", ""))
                        .Where(n => n.Length > 2)
                        .OrderBy(n => n);

                    // dck , hrry, mry

                    /* n => Regex.Replace(n, "[aeiou]"), "") */

                    //into a QUERY expression

                    // TROBELSOME because Select MUST come after the where and oorder by
                    IEnumerable<string> query71 =
                        from n in names
                        where n.Length > 2
                        orderby n
                        select n.Replace("a", "").Replace("e", "").Replace("i", "")
                                    .Replace("o", "").Replace("u", "");

                    // diffent RESULT as query progresses
                    // dck , hrry, mry, jy, mry, tm

                    // Solutuion 1:
                    IEnumerable<string> queryPart1 = from n in names
                                                     select n.Replace("a", "").Replace("e", "").Replace("i", "")
                                   .Replace("o", "").Replace("u", "");

                    IEnumerable<string> queryPart2 = from n in queryPart1
                                                     where n.Length > 2
                                                     orderby n
                                                     select n;


                    Console.WriteLine("finishing  PROGRESSIVE QUERY BUILDER");
                    Console.ReadKey();
                    return true;

                case "8":
                    // INTO
                    // lets you Continue a query after a proyection

                    IEnumerable<string> queryInto =
                        from n in names
                        select n.Replace("a", "").Replace("e", "").Replace("i", "")
                                  .Replace("o", "").Replace("u", "")
                        into noVowels
                        where noVowels.Length > 2
                        orderby noVowels
                        select noVowels;

                    // the only place where you can use a INTO is
                    // after a select or GROUP.
                    // INTO -> RESTARTS a query 
                    //       -> allowind introducte a new Where, orderby, select

                    Console.WriteLine("finishing  INTO");
                    Console.ReadKey();
                    return true;
                case "9":
                    // WRAPPING
                    // identical to progressive queries or INTO

                    IEnumerable<string> queryWrapping =
                        from n1 in
                            (
                        from n2 in names
                        select n2.Replace("a", "").Replace("e", "").Replace("i", "")
                                 .Replace("o", "").Replace("u", "")
                         )
                        where n1.Length > 2
                        orderby n1
                        select n1;

                    //fluent Syntax
                    IEnumerable<string> queryWrappingSyntax
                        = names
                        .Select(n => n.Replace("a", "").Replace("e", "").Replace("i", "")
                                 .Replace("o", "").Replace("u", ""))
                        .Where(n => n.Length > 2)
                        .OrderBy(n => n);
                    

                    Console.WriteLine("finishing WRAPPING");
                    Console.ReadKey();
                    return true;


                case "10":
                    // object INITIALIZERS
                    // identical to progressive queries or INTO

                    IEnumerable<TempProjectionItem> temp =
                        from n in names
                        select new TempProjectionItem
                        {
                            Original = n,
                            Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
                                 .Replace("o", "").Replace("u", "")
                        };

                    foreach (var item in temp)
                    {
                        Console.WriteLine("item1: {0}, item2: {1}", item.Original, item.Vowelless );
                    }

                    // result is  IEnumerable<TempProjectionItem> 
                    // Step 2: subquery
                    IEnumerable<string> query10 =
                        from item in temp
                        where item.Vowelless.Length > 2
                        select item.Original;

                    Console.WriteLine("finishing object INITIALIZERS");
                    Console.ReadKey();
                    return true;
                case "11":
                    // Anonymous Types
                    // no need of a class

                    //compiler generates a temporaty class
                    var intermediate = from n in names
                                       select new
                                       {
                                           Original = n,
                                           vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
                                                .Replace("o", "").Replace("u", "")
                                       };

                    IEnumerable<string> query11 =
                        from items in intermediate
                        where items.vowelless.Length > 2
                        orderby items.vowelless.Length
                        select items.Original;

                    // same thing with Into

                    var queryAnonyInto = from n in names
                                         select new
                                         {
                                             Original = n,
                                             vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
                                                .Replace("o", "").Replace("u", "")
                                         }
                                         into temp11
                                         where temp11.vowelless.Length > 2
                                         orderby temp11.vowelless.Length
                                         select temp11.Original;

                    /* query expression provides a SHORCUT for writing this queries: LET key */

                    Console.WriteLine("finishing Anonymous Types");
                    Console.ReadKey();
                    return true;

                case "12":
                    // LET
                    // no need of a class

                    IEnumerable<string> queryLet =
                        from n in names
                        let vowelless = n.Replace("a", "")
                        where vowelless.Length > 2
                        orderby vowelless.Length
                        select n;

                    Console.WriteLine("finishing Anonymous Types");
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

    class TempProjectionItem
    {
        public string Original; // origianl nam
        public string Vowelless; // vowel-stripped name
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
