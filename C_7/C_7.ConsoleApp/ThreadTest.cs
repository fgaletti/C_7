using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_7.ConsoleApp
{

    // 565 shared data
     public class ThreadTest
    {
        bool _done;

        public void Go()
        {
            if(!_done)
            {
                _done = true;
                Console.WriteLine("Done");
            }
        }
    }
}
