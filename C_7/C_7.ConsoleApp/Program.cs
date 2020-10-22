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
            Console.WriteLine("1)  Yield1");
            Console.WriteLine("2) ");
          
            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    CollectClass coll = new CollectClass();
                    var enumer = coll.GetEnumerator();

                    List<string> Month = new List<string>();
                    Month.Add("January");
                    Month.Add("February");

                    IEnumerator<string> iEnumeratorOfString = Month.GetEnumerator();//to convert list into IEnumerator we can invoke the GetEnumerator method   
                                                                                    //To retrieve all the items from the above IEnumerator object, we cannot use foreach loop instead of that we need to invoke MoveNext() Boolean method.  
                    while (iEnumeratorOfString.MoveNext())
                    {
                        var a = iEnumeratorOfString.Current;
                    }

                    foreach (int i in CollectClass.GetSomeInteger())
                    {
                        Console.WriteLine(i);
                    }
                    
                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;

                case "2":
                    Console.WriteLine("Finishing Processing");
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
}
