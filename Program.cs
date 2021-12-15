using AsyncExamples.Examples;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncExamples
{
    internal static class Program
    {
        private static List<IExampleGroup> _examples;


        static async Task Main(string[] args)
        {
            _examples = new List<IExampleGroup>
            {
                new AsyncFunctionTypes(),
                new TaskStarting(),
                new TaskSynchronizing(),
                new TaskReturning(),
            };

            await _examples[1].Run();

            Console.WriteLine("\n-----------Finish Main-----------\n");
            Console.ReadLine();
        }
    }
}
