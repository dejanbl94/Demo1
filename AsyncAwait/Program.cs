using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public static class Program
    {
        public static void Main()
        {
            string result = DownloadContent().Result;
            Console.WriteLine(result);
        }

        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");// Await means if the task is not complete then return to your caller, and sign up the remainder of this method as the continuation of the task.
                // The GetStringAsync uses asynchronous code internally and returns a Task<string> to the caller that will finish when the data is retrieved. 
                // In the meantime, your thread can do other work.
                return result;
            }
        }
    }
}