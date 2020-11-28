using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        static SemaphoreSlim _sem = new SemaphoreSlim(3);

        public static void Enter (object id)
        {
            Console.WriteLine(id + "wants to enter" );
            _sem.Wait();
            Console.WriteLine(id + "is in!");
            Thread.Sleep(1000 * (int)id);
            Console.WriteLine(id + "Is leaving" );
            _sem.Release();
        }

        // params example:
        public static void Enter2<T>(params T[] pamametros)
        {
            foreach (var item in pamametros)
            {
                Console.WriteLine(item);
            }
         
        }

        static ReaderWriterLockSlim _rw = new ReaderWriterLockSlim();
        static List<int> _items = new  List<int>();
        static Random _rand = new Random();

        public static void Read()
        {
            while (true)
            {
                _rw.EnterReadLock();
                foreach (int i in _items) Thread.Sleep(10);
                _rw.ExitReadLock();
            }
        }

        public static void Write(object threadId)
        {
            while (true)
            {
                int newNumber = GetRandNumber(100);
                //variation with upgrade
                _rw.EnterUpgradeableReadLock();
                if (!_items.Contains(newNumber))
                {

                    _rw.EnterWriteLock();
                    _items.Add(newNumber);
                    Thread.Sleep(60000);
                    _rw.ExitWriteLock();
                    Console.WriteLine("Thread " + threadId + " added " + newNumber);
                }
                _rw.ExitUpgradeableReadLock();
                Thread.Sleep(1000);
            }
        }

        public static int GetRandNumber (int max)
        {
            lock (_rand) return _rand.Next(max);
        }

        static Barrier _barrier = new Barrier(3, barrier => Console.WriteLine()); //participants / delegate

        public static void Speak()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i + " ");
                _barrier.SignalAndWait();
            }
        }
    }


}
