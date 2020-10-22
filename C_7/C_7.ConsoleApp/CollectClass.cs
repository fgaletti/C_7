using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_7.ConsoleApp
{
    public  class CollectClass : IEnumerable
    {
        int[] data = { 1, 2, 3, 4 };

        public  IEnumerator GetEnumerator()
        {
            foreach (int i in data)
            {
               yield return i;
            }
        }

        public static IEnumerable<int> GetSomeInteger()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }
}
