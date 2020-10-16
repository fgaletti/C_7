using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_7.ConsoleApp
{
    class Program
    {
        delegate int Trasformer(int x); // case 1


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
            Console.WriteLine("1) Delegate ");
            Console.WriteLine("2) Plug IN Delegates ");
            Console.WriteLine("3) ");
          
            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Trasformer t = DelegateClass.Square;
                    int result = t(4);
                    Console.WriteLine(result);

                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;

                case "2":

                    int[] values = { 1, 2, 3, 4 };
                    DelegateClass.Transform(values, DelegateClass.Square);

                    foreach (int i in values)
                    {
                        Console.WriteLine(i);
                    }

                    // test value/ref
                    int val = 77;
                    DelegateClass.UpdateRefVal(ref val);
                    Console.WriteLine(val);

                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;

                case "3":
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
