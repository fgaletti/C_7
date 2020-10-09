using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public static async void DisplayPrimesCountAsync()
        {
            int result = await GetPrimesCountAsync(2, 10000000);
            Console.WriteLine(result);
        }

        public static void DisplayPrimesCount()
        {
            var awaiter = GetPrimesCountAsync(2, 10000000).GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine("Result GetAwaiter" + awaiter.GetResult());
            });
        }

        public static async void Go()
        {
            //_button.IsEnabled = false; // simulate windows
            string[] urls = "www.google.com www.yahoo.com www.microsoft.com".Split();
            int totalLenght = 0;
            try
            {
                foreach (string url in urls)
                {
                    var uri = new Uri("http://" + url);
                    byte[] data = await new WebClient().DownloadDataTaskAsync(uri);
                    totalLenght += data.Length;
                }

                // windows :  _result.text = "Total Lenght" + totalLenght;
                Console.WriteLine(totalLenght);

            }
            catch (WebException ex)
            {
               // windows: _result.text += ex.Message; 
            }
            finally { // windows: _button1.enabled = true
                    }

        }

        public static void PrintAnswerToLifeVoid()
        {
             Task.Delay(2000);
            int answer = 21 * 2;
            Console.WriteLine(answer);
        }
        //Replace any VOID with TASK:
        public static async Task PrintAnswerToLife()
        {
            await Task.Delay(2000);
            int answer = 21 * 2;
            Console.WriteLine(answer);
        }


        // Returning TASK

        public static async Task<int> GetAnswerToLife()
        {
            await Task.Delay(5000);
            int answer = 21 * 2;
            return answer;
        }

        public static async Task PrintAnswerToLifeChain()
        {
            int answer = await GetAnserToLife();
            Console.WriteLine(answer);
        }

        public static async Task GoChain()
        {
            await PrintAnswerToLifeChain();
            Console.WriteLine("Done");
        }

    }
}
