using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    public class Program
    {
        static void Main(string[] args)
        {
            var t1 = Task.Factory.StartNew(() => DoSomeIntenseWork(1, 1500)).ContinueWith((prevTask) => DoSomeOtherWork(1, 1500));
            var t2 = Task.Factory.StartNew(() => DoSomeIntenseWork(2, 3000)).ContinueWith((prevTask) => DoSomeOtherWork(2, 2000));//until this one finishes task2 is being executed so we get
            var t3 = Task.Factory.StartNew(() => DoSomeIntenseWork(3, 1000)).ContinueWith((prevTask) => DoSomeOtherWork(3, 500));

            var taskList = new List<Task> { t1, t2, t3 };
            Task.WaitAll(taskList.ToArray());//Wait for t1,2,3 to finish before continuing to deal with other tasks

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Doing some other work");
                Thread.Sleep(250);
                Console.WriteLine("i = {0} ", i);
            }

            Console.WriteLine("Press any key to quit");// before waitAll this line was printed before all of the tasks have completed
            Console.ReadKey();
        }

        static void DoSomeIntenseWork(int id, int sleepTime)
        {
            Console.WriteLine("Task {0} is beginning...", id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("Task {0} has completed.", id);
        }
        static void DoSomeOtherWork(int id, int sleepTime)
        {
            Console.WriteLine("Task {0} is beginning more work", id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("Task {0} has completed more work", id);
        }
    }
}
/*In computer science terms, a Task is a future or a promise. (Some people use those two terms synomymously, some use them differently, 
 * nobody can agree on a precise definition.) Basically, a Task<T> "promises" to return you a T, but not right now honey, I'm kinda busy,
 * why don't you come back later?

A Thread is a way of fulfilling that promise. But not every Task needs a brand-new Thread. (In fact, creating a thread is often undesirable,
because doing so is much more expensive than re-using an existing thread from the threadpool. More on that in a moment.) If the value you are 
waiting for comes from the filesystem or a database or the network, then there is no need for a thread to sit around and wait for the data when 
it can be servicing other requests. Instead, the Task might register a callback( ContinueWith ?? ) to receive the value(s) when they're ready.

In particular, the Task does not say why it is that it takes such a long time to return the value. It might be that it takes a long time to compute,
or it might that it takes a long time to fetch. Only in the former case would you use a Thread to run a Task. (In .NET, threads are freaking expensive, 
so you generally want to avoid them as much as possible and really only use them if you want to run multiple heavy computations on multiple CPUs. 
For example, in Windows, a thread weighs 12 KiByte (I think), in Linux, a thread weighs as little as 4 KiByte, in Erlang/BEAM even just 400 Byte. 
In .NET, it's 1 MiByte!)*/
