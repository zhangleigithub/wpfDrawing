using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace wpfSeries
{
    public class AsyncAwait
    {
        public delegate void CallBack(string e);

        public static async void DoTaskWithAsync(CallBack callBack)
        {
            Console.WriteLine("begin");

            string str = await TaskHttpClientWithAsync("https://www.baidu.com/");
            callBack(str);

            Console.WriteLine("end");
        }

        public static async Task<string> TaskHttpClientWithAsync(string url)
        {
            var client = new HttpClient();
            return await client.GetStringAsync(url);
        }
    }
}
