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

            Console.WriteLine("13) LINQ LIKE SQL ");
            Console.WriteLine("14) Take / Sk/ip ");
            Console.WriteLine("15) TakeWhile / SkipWhile ");
            Console.WriteLine("16) Distinct ");

            Console.WriteLine("17) Select MANY ");
            Console.WriteLine("18) Multiple Range Variables ");

            Console.WriteLine("19) DATABASE ");

            Console.WriteLine("20) Cartesian ");
            Console.WriteLine("21) Joining select many ");
            Console.WriteLine("22) Select MANY -Linq to Sql / EF ");
            Console.WriteLine("23) Select MANY -Outer Join ");

            Console.WriteLine("24) Join ");
            Console.WriteLine("25) Joining in Fluent Syntax ");
            Console.WriteLine("26) GroupJoin ");

            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");

            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            string[] fullnames = { "Anna Williams", "John Fred Smith", "Sue Green" , "Beto Soto"};

            var dataContext = new NutshellContext(@"Data Source=DESKTOP-G8PER65\SQLEXPRESS;Initial Catalog=LinqC;Integrated Security=True");
    

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

                    foreach (var item in queryInto)
                    {
                        Console.WriteLine("item: {0}", item );
                    }

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

                    foreach (var item in intermediate)
                    {
                        Console.WriteLine($"item1 {item.Original} - item2 { item.vowelless}");
                    }

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

                    // same query Into With anonymous 
                    // to return 2 fields

                    var queryAnonyIntoAnony = from n in names
                                         select new
                                         {
                                             Original = n,
                                             vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
                                                .Replace("o", "").Replace("u", "")
                                         }
                                         into temp11
                                         where temp11.vowelless.Length > 2
                                         orderby temp11.vowelless.Length
                                         select new
                                         {
                                             temp11.Original, temp11.vowelless
                                         };


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

                    // same thing LET but 2 fields

                    //IEnumerable<string> queryLetNew =
                    //from n in names
                    //let vowelless2 = select new
                    //{
                    //    vow1 = n.Replace("a", "")
                    //    ,vow2 = n
                    //} 
                    //where vowelless2.Length > 2
                    //orderby vowelless2.Length
                    //select n;


                    Console.WriteLine("finishing LET");
                    Console.ReadKey();
                    return true;

                case "13":
                    // SQL LIKE

                    // SQL' LIKE

                    //Contains , StartsWith, EndsWith

                    //c.NAME.Contains("abc") ->   translates -> customer.Name LIKE '%abc'

                    // WHERE IN
#pragma warning disable
                    string[] choosenOnes = { "Tom", "Ray" };

                    //from c in datacontext.customes
                    //where choosenOnes.Contains(c.Name);
#pragma warning restore


                    Console.WriteLine("finishing LET");
                    Console.ReadKey();
                    return true;

                case "14":
                    // Take / Skip
                     //Pagination   
                    //.Skip(10).Take(20)

                    Console.WriteLine("finishing LET");
                    Console.ReadKey();
                    return true;


                case "15":
                    // TakeWhile /SkipWhile

                    int[] numbers15 = { 3, 5, 2, 234, 4, 1 };

                    // ignores the remaining element
                    var takeWhile = numbers15.TakeWhile(n => n < 100); // 3,5,2

                    // then emits the remaining elements
                    var skipWhile = numbers15.SkipWhile(n => n < 100); // 234,4,1


                    Console.WriteLine("finishing TakeWhile /SkipWhile");
                    Console.ReadKey();
                    return true;

                case "16":
                    // Distinct

                    char[] distintLetters = "HelloWorld".Distinct().ToArray();
                    string s = new string(distintLetters); // HeloWrd


                    Console.WriteLine("finishing TakeWhile /SkipWhile");
                    Console.ReadKey();
                    return true;

                case "17":

                    IEnumerable<string> query17 = fullnames.SelectMany(name => name.Split());

                    foreach (string name in query17)
                    {
                        Console.WriteLine(name + "|");
                    }

                    //equivalent with select

                    Console.ReadKey();

                    //returns an array 
                    IEnumerable<string[]> query172 = fullnames.Select(name => name.Split());
                    
                    //iterate the each array
                    foreach (string[] stringArray in query172)
                        foreach (string name in stringArray)
                        {
                            Console.WriteLine(name + "|");
                        }

                    // Select Many in query sintax
                    IEnumerable<string> query173 = from fullname in fullnames
                                                   from name in fullname.Split() // translate to selectMany
                                                   select name;  // new range variable (name) , we can access both (fullname and name)


                    foreach (var item in query173)
                    {
                        Console.WriteLine(item);
                    }
                    

                   Console.WriteLine("finishing SELECT MANY");
                    Console.ReadKey();
                    return true;

                case "18":
                    // Multiple Range Variables
                    IEnumerable<string> query18 =
                        from fullname in fullnames
                        from name in fullname.Split()
                        select name + " came from " + fullname;

                    foreach (var item in query18)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("---------");
                    // order by
                    IEnumerable<string> query181 =
                      from fullname in fullnames
                      from name in fullname.Split()
                      orderby fullname, name
                      select name + " came from " + fullname;

                    foreach (var item in query181)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("----Carry-----");
                    // Order by , carry outer
                    IEnumerable<string> query182 =
                    from fullname in fullnames
                    from x in fullname.Split().Select(name => new { name, fullname})
                    orderby x.fullname, x.name
                    select x.name + " came from " + x.fullname;

                    foreach (var item in query182)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("----Fluent -----");

                    // Order by , carry outer
                    IEnumerable<string> query183 = fullnames
                        .SelectMany(fName => fName.Split()
                                        .Select(name => new { name, fName }))
                        .OrderBy(x => x.fName)
                        .ThenBy(x => x.name)
                        .Select(x => x.name + " Came from " + x.fName);

                    foreach (var item in query183)
                    {
                        Console.WriteLine(item);
                    }

                    // undestand Fluent
                    Console.WriteLine("--- undestand fluent");
                    // Order by , carry outer
                    IEnumerable<string> query184 = fullnames
                        .SelectMany(fName => fName.Split()
                                    .Select(name => new { name, fName }))
                         .Select(x => x.name);
                                       
                        //.OrderBy(x => x.)
                       // .ThenBy(x => x.name)
                      //  .Select(x => x.name + " Came from " + x.fName);

                    foreach (var item in query184)
                    {
                        Console.WriteLine(item);
                    }


                    Console.WriteLine("finishing Multiple Range Variables");
                    Console.ReadKey();
                    return true;

                case "19":

                   
                    IEnumerable<string> query19 = from c in dataContext.Customers
                                                  from p in c.Purchases
                                                  select c.Name + " Bougth a " + p.Description;

                    foreach (var item in query19)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;
                case "20":
                    //cartesian
                    int[] numbers20 = { 1, 2, 3 };
                    string[] letters = { "a", "b" };

                    IEnumerable<string> query20 =
                        from n in numbers20
                        from str in letters
                        select n.ToString() + str;

                    foreach (var item in query20)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("finishing cartesian");
                    Console.ReadKey();
                    return true;
                case "21":
                    //Joining Select Many

                    string[] players = { "Tom", "Jay", "May" };

                    IEnumerable<string> query21 =
                        from name1 in players
                        from name2 in players
                        select name1 + " vs " + name2;

                    foreach (var item in query21)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("----non equi Join---");
                    // Cross Join
                    IEnumerable<string> query211 =
                       from name1 in players
                       from name2 in players
                       where name1.CompareTo(name2) < 0 // onlu returns 3 values
                      // where name1 != name2
                      // where !name1.Equals( name2)
                       select name1 + " vs " + name2;

                    foreach (var item in query211)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("finishing Joining Select Many");
                    Console.ReadKey();
                    return true;

                case "22":  //426
                    // Select MANY -Linq to Sql / EF 

                    //returns a flat result set
                    var query22 = from c in dataContext.Customers
                                  from p in dataContext.Purchases
                                  select c.Name + "might bought a " + p.Description;

                    foreach (var item in query22)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("---Join---");
                    // join

                    var query222 = from c in dataContext.Customers
                                  from p in dataContext.Purchases
                                  where c.ID == p.CustomerID
                                  select c.Name + "might bought a " + p.Description;


                    foreach (var item in query222)
                    {
                        Console.WriteLine(item);
                    }

                    // if you have association properties

                    Console.WriteLine("---asosiatoipn --");
                    var query223 = from c in dataContext.Customers
                                   from p in c.Purchases  // association  
                                   select new
                                   {
                                       c.Name , p.Description
                                   };


                    foreach (var item in query223)
                    {
                        Console.WriteLine(item.Name + " - " + item.Description);
                    }

                    Console.WriteLine("----introduce a where---");
                    // introduce a where

                    var query224 = from c in dataContext.Customers
                                   where c.Name.StartsWith("T") // filter by T
                                   from p in c.Purchases  // association  
                                   select new
                                   {
                                       c.Name,
                                       p.Description
                                   };


                    foreach (var item in query224)
                    {
                        Console.WriteLine(item.Name + " - " + item.Description);
                    }

                    Console.WriteLine("finishing Select MANY -Linq to Sql / EF ");
                    Console.ReadKey();
                    return true;
                case "23":
                    // outer Join Select MANY    427

                    // every element of customer is included
                    var query23 = from c in dataContext.Customers
                                  select new
                                  {
                                      c.Name,
                                      Purchases = from p in c.Purchases
                                                  where p.Price <= 1000
                                                  select new
                                                  {
                                                      p.Description,
                                                      p.Price
                                                  }
                                  };



                    foreach (var item in query23)
                    {
                        Console.WriteLine(item.Name + " -" );
                        foreach (var item2 in item.Purchases)
                        {
                            Console.WriteLine("purchases: " + item2.Description + " - " + item2.Price  );
                        }
                    }

                    Console.WriteLine("---- Selectmany outer -----");

                    var query231 = from c in dataContext.Customers
                                   from p in c.Purchases
                                   where p.Price <= 1000
                                   select new
                                   {
                                       c.Name,
                                       p.Description,
                                       p.Price
                                   };

                    foreach (var item in query231)
                    {
                        Console.WriteLine( item.Name + " -" + item.Description + " - " + item.Price);
                    }


                    Console.WriteLine("---- Selectmany outer NULL -----");

                    var query232 = from c in dataContext.Customers
                                   from p in c.Purchases.DefaultIfEmpty()
                                   //where p.Price <= 1000
                                   select new
                                   {
                                       c.Name,
                                       p.Description,
                                       Price = (decimal?) p.Price 
                                   };

                    foreach (var item in query232)
                    {
                        Console.WriteLine(item.Name + " -" + item.Description + " - " + item.Price);
                    }

                    Console.WriteLine("finishing processing  outer Join Select MANY");
                    Console.ReadKey();
                    return true;


                case "24":
                    // Join
                    IQueryable<string> query24 =
                        from c in dataContext.Customers
                        join p in dataContext.Purchases
                        on c.ID equals p.CustomerID
                        select c.Name + " bought a " + p.Description;

                    foreach (var name in query24)
                    {
                        Console.WriteLine(name);
                    }

                    Console.WriteLine("--- comparison with select many --");


                    Customer[] customers = dataContext.Customers.ToArray();
                    Purchase[] purchases = dataContext.Purchases.ToArray();

                    var slowQuery = from c in customers
                                    from p in purchases
                                    where c.ID == p.CustomerID
                                    select c.Name + " bought a " + p.Description;

                    var fastQuery = from c in customers
                                    join p in purchases
                                    on c.ID equals p.CustomerID
                                    select c.Name + " bought a " + p.Description;

                    //Joining multiple queries

                    // from c in secuencex
                    // join y in secuencey 
                    // on new { K1 = x.prop1, K2 = x.prop2}
                    // equals new { K1 = y.prop3, K2 = y.prop4}


                    Console.WriteLine("finishing Join");
                    Console.ReadKey();
                    return true;

                case "25":
                    //joining fluent syntax 

                    IQueryable<string> query251 =
                        from c in dataContext.Customers
                        join p in dataContext.Purchases
                        on c.ID equals p.CustomerID
                        select c.Name + " bought a " + p.Description;

                  

                    // In Fluent Syntax
                    Console.WriteLine("-----fuent syntax----");

                    Customer[] customers25 = dataContext.Customers.ToArray();
                    Purchase[] purchases25 = dataContext.Purchases.ToArray();

                    var query25 = customers25.Join(                // outter selector
                                                purchases25,      // inner selector
                                                c => c.ID,      // outer ker
                                                p => p.CustomerID, // inner key
                                                (c, p) => new    // result
                                                {
                                                    c.Name,
                                                    p.Description,
                                                    p.Price
                                                });
                    
                    foreach (var item in query25)
                    {
                        Console.WriteLine(item.Name + " - " + item.Description + " - " + item.Price);
                    }

                    Console.WriteLine("----orderby ----");

                    var query252 = customers25.Join(                // outter selector
                                               purchases25,      // inner selector
                                               c => c.ID,      // outer ker
                                               p => p.CustomerID, // inner key
                                               (c, p) => new    // result
                                               { c, p })
                                                .OrderBy(x => x.p.Price)
                                                // .Select(x => x.c.Name + " bought a " + x.p.Description);
                                                .Select(x => new { name = x.c.Name, desc = x.p.Description });
                    foreach (var item in query252)
                    {
                        //Console.WriteLine(item);
                        Console.WriteLine(item.name + " - " + item.desc);
                    }

                    Console.WriteLine("finishing joining fluent syntax ");
                    Console.ReadKey();
                    return true;

                case "26":
                    // group join
                    // yeals a hirerquivcal
                    Customer[] customers26 = dataContext.Customers.ToArray();
                    Purchase[] purchases26 = dataContext.Purchases.ToArray();

                    IEnumerable <IEnumerable<Purchase>> query26 =
                        from c in customers26
                        join p in purchases26
                        on c.ID equals p.CustomerID
                        into custPurchases
                        select custPurchases;

                    foreach(IEnumerable<Purchase> purc in query26)
                        foreach (var item in purc)
                        {
                            Console.WriteLine(item.Description);
                        }

                    Console.WriteLine("--- reference customer ---");

                    var query261 =  // string , ,ienumerable<purchases>
                       from c in customers26
                       join p in purchases26
                       on c.ID equals p.CustomerID
                       into custPurchases
                       select new { CustName = c.Name, custPurchases };

                    foreach (var item in query261)
                    {
                        Console.WriteLine(item.CustName);
                        foreach (var subItem in item.custPurchases)
                        {
                            Console.WriteLine(subItem.Description + " - " + subItem.Price);
                        }
                    }

                    Console.WriteLine("--- group Join inner---");

                    var query262 =  // string , ,ienumerable<purchases>
                       from c in customers26
                       join p in purchases26
                       on c.ID equals p.CustomerID
                       into custPurchases
                       where custPurchases.Any()
                       select new { CustName = c.Name, custPurchases };

                    foreach (var item in query262)
                    {
                        Console.WriteLine(item.CustName);
                        foreach (var subItem in item.custPurchases)
                        {
                            Console.WriteLine(subItem.Description + " - " + subItem.Price);
                        }
                    }

                    Console.WriteLine("finishing processing Grouping");
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
