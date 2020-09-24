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
            Console.WriteLine("1) Generic  ");
            Console.WriteLine("2) Generic swap");
            Console.WriteLine("3) Generic Default");
            Console.WriteLine("4) Generic Constrain");
            Console.WriteLine("5) Self Reference");
            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Stack<int> stack = new Stack<int>();

                    stack.Push(2);
                    stack.Push(3);

                    Console.WriteLine(stack.Pop());
                    Console.WriteLine(stack.Pop());

                    Console.WriteLine("finishing processing");
                    Console.ReadKey();
                    return true;

                case "2":
                    int x = 5;
                    int y = 10;

                    GenericClass.Swap(ref x, ref y);

                    Console.WriteLine("x:" + x.ToString());

                    Console.WriteLine("Finishing Processing");
                    Console.ReadKey();
                    return true;

                case "3":
                    // get DEFAULT TYPE
                    string[] arrayString = new string[] { "Uno", "Dos", "Tres" };
                    GenericClass.Zap(arrayString);


                    Console.WriteLine("Finishing Default");
                    Console.ReadKey();
                    return true;

                case "4":
                    //Generic Constrain
                    int z = GenericClass.Max(5, 10);
                    Console.WriteLine("z:" + z.ToString());

                    string last = GenericClass.Max("ant", "zoo");
                    Console.WriteLine(last);

                    Console.WriteLine("Finishing Generic Constrain");
                    Console.ReadKey();
                    return true;

                case "5":
                    //Self Reference
                    Balloon b1 = new Balloon();
                    b1.Color = "red";

                    Balloon b2 = new Balloon();
                    b2.Color = "red";

                    bool bAreEqual = b1.Equals(b2);

                    Console.WriteLine(bAreEqual);

                    Console.WriteLine("Finishing SELF REFERENCE");
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
