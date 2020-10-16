using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_7.ConsoleApp
{
    public class DelegateClass
    {
        public delegate int Trasformer(int x); // case 1
        public static int Square(int x)
        {
            return x * x;
        }

        public static void Transform(int[] values, Trasformer t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }
        }

        public static void UpdateRefVal(ref int value)
        {
            value = 88;
        }
    }
}
