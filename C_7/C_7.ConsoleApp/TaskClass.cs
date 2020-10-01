using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_7.ConsoleApp
{
    public class TaskClass
    {
        // 584 awaitable
        public static Task<int> GetAnserToLife()
        {
            var tcs = new TaskCompletionSource<int>();
            var timer = new System.Timers.Timer(1500) { AutoReset = false };
            timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult(42); };
            timer.Start();
            return tcs.Task;
        }

        //587
        public static int GetPrimesCount(int start, int count)
        {
            return ParallelEnumerable.Range(start, count).Count(n =>
             Enumerable.Range(2, (int)Math.Sqrt(n)-1).All(i => n % i > 0));
        }
        //588
        public static Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() =>    ParallelEnumerable.Range(start, count).Count(n =>
            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
            
        }

        //591 
        // Await /ASYNC
        //
        //var result = await expression
        //statement

        // similar to:

        // var awaiter = expression.GetAwaiter();
        // awaiter.OnCompleted (() =>
        // { var result = awaiter.GetResult(); statement(s) ...
        public static async void DisplayPrimesCount()
        {
            int result = await GetPrimesCountAsync(2, 10000000);
            Console.WriteLine(result);
        }
    }
}
