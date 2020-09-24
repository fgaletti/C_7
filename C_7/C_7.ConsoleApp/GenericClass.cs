using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace C_7.ConsoleApp
{
    public class GenericClass
    {
       public static void Swap<T> (ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        //DEFAULT Generic Value
      public  static void Zap<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = default(T); // Gets default value , string = null , int = 0, etc..
            }
        }

        public static T Max<T> (T a, T b) where T :IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }

    
}
