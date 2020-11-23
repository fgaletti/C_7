using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_7.ConsoleApp
{
   public  class ThreadSafeClass
    {
        static readonly object _locker = new object();
        static int _val1 = 1, _val2 = 1, _val3 = 3;

        public static void Go()
        { lock (_locker)
            {
                try
                {
                    if (_val2 != 0)
                    {
                        _val3 = _val1 / _val2;
                    }
                    else

                    {
                        _val2 = 1;
                        Console.WriteLine("val1");
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("-----------------eRROR0-------------------------");
                }


                _val2 = 0;
            }
            //lock (_locker)
            //{
            //    if (_val2 != 0)
            //        Console.WriteLine(_val1 / _val2);

            //    _val2 = 0;
            //}
        }
    }
}
