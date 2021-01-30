using System;
using System.Threading.Tasks;

namespace Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(0, 10, i =>
            {

                Thread.Sleep(1000);
            });
        }
    }
}
