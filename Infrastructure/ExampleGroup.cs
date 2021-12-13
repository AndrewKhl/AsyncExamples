using System;
using System.Threading.Tasks;

namespace AsyncExamples.Examples
{
    internal interface IExampleGroup
    {
        Task Run();
    }


    internal abstract class ExampleGroup : IExampleGroup
    {
        protected const int WaitDelay = 1000;


        protected abstract string GroupName { get; }


        protected abstract Task RunExamples();


        public Task Run()
        {
            Console.WriteLine($"Start examples group: {GroupName}");

            return RunExamples();
        }


        protected static async void PrintVoid(string methodName)
        {
            Console.WriteLine($"{methodName} before delay");

            await Task.Delay(WaitDelay);

            Console.WriteLine($"{methodName} after delay");
        }

        protected static async Task PrintTask(string methodName)
        {
            Console.WriteLine($"{methodName} before delay");

            await Task.Delay(WaitDelay);

            Console.WriteLine($"{methodName} after delay");
        }
    }
}
