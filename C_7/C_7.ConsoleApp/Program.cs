using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Console.WriteLine("1) TaskCompletionSource ");
            Console.WriteLine("2) GetAwaiter");

            Console.WriteLine("3) PrimeCounts");
            Console.WriteLine("4) PrimeCountsAsync");
            Console.WriteLine("5) Await/Async");
            Console.WriteLine("6) Go");
            Console.WriteLine("7) Signaling");
            Console.WriteLine("8) Task<TResult> /Go chain");

            Console.WriteLine("99) EXIT");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    // 583
                    var tcs = new TaskCompletionSource<int>();

                    new Thread(() =>
                    {
                        Thread.Sleep(1000);
                        tcs.SetResult(42);

                    })
                    { IsBackground = true }
                    .Start();

                    Task<int> task = tcs.Task; // out "slave" task
                    Console.WriteLine(task.Result); // 42


                    Console.WriteLine("finishing processing TaskCompletionSource");
                    Console.ReadKey();
                    return true;

                case "2":
                    // 584 
                    // task that dont tie up a thread
                    var awaiter = TaskClass.GetAnserToLife().GetAwaiter();
                    awaiter.OnCompleted(() => Console.WriteLine(awaiter.GetResult()));

                    Console.WriteLine("Finishing Processing GetAwaiter");
                    Console.ReadKey();
                    return true;

                case "3":
                    // 588 
                    // task that dont tie up a thread
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(TaskClass.GetPrimesCount(i * 1000000 + 2, 1000000)
                             + " Primes between" + (i * 1000000) + " and" +
                             ((i + 1) * 1000000 - 1));

                        Console.WriteLine("Done!");
                    }

                    Console.WriteLine("Finishing Processing GetAwaiter");
                    Console.ReadKey();
                    return true;

                case "4":
                    // 588 
                    // AWAITER
                    for (int i = 0; i < 10; i++)
                    {
                        var awaiter4 = TaskClass.GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
                        awaiter4.OnCompleted(() =>
                           Console.WriteLine(awaiter4.GetResult()
                             + " Primes between" + (i * 1000000) + " and" +
                             ((i + 1) * 1000000 - 1)));
                        

                        Console.WriteLine("Done!");
                    }

                    Console.WriteLine("Finishing Processing GetAwaiter");
                    Console.ReadKey();
                    return true;

                case "5":
                    // 591 
                    // Await /Async
                    //
                    //var result = await expression
                    //statement

                    // similar to:

                    // var awaiter = expression.GetAwaiter();
                    // awaiter.OnCompleted (() =>
                    // { var result = awaiter.GetResult(); statement(s) ...

                    TaskClass.DisplayPrimesCountAsync();

                    Console.WriteLine("Finishing Processing Await /Async");
                    Console.ReadKey();
                    return true;
                case "6":
                    // 594 
                    // Async / await 
                    //
                    TaskClass.Go();

                    Console.WriteLine("Finishing Processing Await /Async");
                    Console.ReadKey();
                    return true;

                case "7":
                    // 572 
                    // Signaling 
                    // thread to wait until reveiveing notifications from other threads

                    var signal = new ManualResetEvent(false);
                    var signal2 = new ManualResetEvent(false); // testing with 2 signals

                    new Thread(() =>
                    {
                        Console.WriteLine("Waiting for Signal");
                        signal.WaitOne();
                        signal.Dispose();
                        Console.WriteLine("Got Signal");

                        //signal 2
                        Console.WriteLine("22 - Waiting for Signal");
                        signal2.WaitOne();
                        signal2.Dispose();
                        Console.WriteLine("22 Signal");

                    }).Start();

                    Thread.Sleep(2000);
                    signal.Set(); // Open the Signal

                    //signal 2
                    Thread.Sleep(2000);
                    signal2.Set(); // Open the Signal

                    Console.WriteLine("Finishing Signaling");
                    Console.ReadKey();
                    return true;

                case "8":
                    // 598 
                    // Returt TASK<>  , chain 

                    Task awaitableGo = TaskClass.GoChain();
                    
                    Console.WriteLine("Finishing Signaling");
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
