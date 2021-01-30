using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Task<int> t = Task.Run(() =>
            {
                int r = 0;

                for (int i = 1; i < 100; i++)
                {
                    Thread.Sleep(100);

                    for (int j = 0; j < i; j++)
                    {
                        r += i + j;
                    }
                }
                return r;
            }).ContinueWith((i) =>
            {
                Console.WriteLine(i.Result * 2);
                return i.Result * 2;
            });

            Console.WriteLine(t.Result);
        }

        /*Attempting to read the Result property on a Task will force the thread that’s trying to read the result to wait until the Task is finished before continuing.
         * As long as the Task has not finished, it is impossible to give the result. If the Task is not finished, this call will block the current thread.*/
    }
}