using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace C_7.ConsoleApp
{
     public class WebClass
    {
        public static async Task downloadAsync()
        {
            WebClient wc2 = new WebClient ();
            wc2.DownloadProgressChanged += (sender, args) =>
                 Console.WriteLine(args.ProgressPercentage + "% complete ");

          //  await  Task.Delay(5000).ContinueWith(ant => wc2.CancelAsync());
            string url = "https://file-examples-com.github.io/uploads/2017/11/file_example_MP3_5MG.mp3";
            // http://oreilly.com
            await wc2.DownloadFileTaskAsync(url, "webpage.htm");
        }
    }
}
