using System;
using System.Threading.Tasks;

namespace AsyncExamples.Examples
{
    internal sealed class TaskReturning : ExampleGroup
    {
        protected override string GroupName => nameof(TaskReturning);


        protected override async Task RunExamples()
        {
            //await ReturnTask();
            await ReturnVoidAsTask();
            //Console.WriteLine(await ReturnAsyncTaskWithValue());
            //Console.WriteLine(await ReturnTaskWithValue());
        }


        private Task ReturnTask()
        {
            return PrintTask(nameof(ReturnTask));
        }

        private Task ReturnVoidAsTask()
        {
            Console.WriteLine(nameof(ReturnVoidAsTask));

            return Task.CompletedTask;
        }

        private async Task<int> ReturnAsyncTaskWithValue()
        {
            await PrintTaskVal(nameof(ReturnAsyncTaskWithValue));

            return 5;
        }

        private Task<int> ReturnTaskWithValue()
        {
            Console.WriteLine(nameof(ReturnTaskWithValue));

            return Task.FromResult(6);
        }
    }
}