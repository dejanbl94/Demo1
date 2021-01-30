using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Action<Action> measure = (body) =>
            {
                var startTime = DateTime.Now;
                body();
                Console.WriteLine("{0} {1}", DateTime.Now - startTime, Thread.CurrentThread.ManagedThreadId);
            };

            Action calcJob = () => { for (int i = 0; i < 350000000; i++) ; };
            /// Simulate io(waiting for network, reading from hdd) operation to see real advantages
            /// of TPL TPL will introduce new threads from a thread pool as it will recognize that
            /// not full capacity of the CPU is used.
            Action ioJob = () => { Thread.Sleep(2000); };

            /// We want to wait for the task to finish so we use Wait(), otherwise it will not wait
            /// for it Ona a multicore processor these two ops can be done simultaneously so again it
            /// wil take approx 1 sec to finish
              measure(() =>
              {
                  /// body of our action delegate TPL recognizes that it should reuse existing threads,
                  /// so we can see in the output repetition of thread ids
                  var tasks = Enumerable.Range(1, 20)
                                          .Select(_ => Task.Factory.StartNew(() => measure(ioJob)))
                                              .ToArray();

                  Task.WaitAll(tasks);
              });
            Enumerable.Range(1, 10)
                        .AsParallel()/// AsParallel can be used whenever we have an IEnumerable, and it will change to parallel query
                         .WithDegreeOfParallelism(20)
                         .ForAll(_ => measure(ioJob));

                    ParallelEnumerable.Range(1, 10)
                        .WithDegreeOfParallelism(20)
                        .ForAll(_ => measure(ioJob));

            var queue = new BlockingCollection<int>(100);
            /// Producers
            var producers = Enumerable.Range(1, 3)
                .Select(_ => Task.Factory.StartNew(() =>
                {
                    Enumerable.Range(1, 100)
                        .ToList()
                        .ForEach(i =>
                        {
                            // WRONG, queue is not thread safe, and we need to use lock keyword to make sure it is not done i parallel.
                            queue.Add(i);//putting 100 ints in a queue
                            Thread.Sleep(100);
                        });
                }))
            .ToArray();

            //WRONG!! queue is not thread safe, the while loop is wrong
            var consumers = Enumerable.Range(1, 2)
                .Select(_ => Task.Factory.StartNew(() =>
               {
                   foreach (var item in queue.GetConsumingEnumerable())
                   {
                       Console.WriteLine(item);
                   }
               }))
            .ToArray();

            Task.WaitAll(producers);
            queue.CompleteAdding();
            Task.WaitAll(consumers);

            /// Tasks are sitting on top of the threads, they are distributed across different threads, and management of threads is done automatically by the .Net framework.
            //Parallel.For(0, 10, _ => { measure(ioJob); });
        }
    }
}