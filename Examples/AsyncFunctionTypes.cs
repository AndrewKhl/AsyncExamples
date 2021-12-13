using System;
using System.Threading.Tasks;

namespace AsyncExamples.Examples
{
    internal sealed class AsyncFunctionTypes : ExampleGroup
    {
        protected override string GroupName => nameof(AsyncFunctionTypes);


        protected async override Task RunExamples()
        {
            //AsyncVoid(); // нельзя авейтить войд

            await TaskAsync();

            await GenericTaskAsync();

            await ValueTaskAsync();

            await GenericValueTaskAsync();
        }


        private async void AsyncVoid()
        {
            await Task.Delay(WaitDelay);

            Console.WriteLine("Async void");
        }


        private async Task TaskAsync()
        {
            await Task.Delay(WaitDelay);

            Console.WriteLine("Async task");
        }

        private async Task<int> GenericTaskAsync()
        {
            await Task.Delay(WaitDelay);

            Console.WriteLine("Async task gen");

            return 0;
        }


        private async ValueTask ValueTaskAsync()
        {
            await Task.Delay(WaitDelay);

            Console.WriteLine("Async ValueTask");
        }

        private async ValueTask<int> GenericValueTaskAsync()
        {
            await Task.Delay(WaitDelay);

            Console.WriteLine("Async ValueTask gen");

            return 0;
        }
    }
}