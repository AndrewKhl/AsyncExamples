using System;
using System.Threading.Tasks;

namespace AsyncExamples.Examples
{
    internal sealed class TaskSynchronizing : ExampleGroup
    {
        protected override string GroupName => nameof(TaskSynchronizing);


        protected override async Task RunExamples()
        {
            //await SyncViaAwait();
            //await SyncViaWaitAll();
            //await SyncViaWaitAny();
            await SyncViaContinue();
        }


        private async Task SyncViaAwait()
        {
            await PrintTask(nameof(SyncViaAwait));
        }

        private async Task SyncViaWaitAll()
        {
            var tasks = new Task[4];

            for (int i = 0; i < tasks.Length; ++i)
                tasks[i] = PrintTask($"{nameof(SyncViaWaitAll)}-{i}");

            await Task.WhenAll(tasks);
        }

        private async Task SyncViaWaitAny()
        {
            var tasks = new Task[4];

            for (int i = 0; i < tasks.Length; ++i)
                tasks[i] = PrintTask($"{nameof(SyncViaWaitAny)}-{i}");

            await Task.WhenAny(tasks);
        }

        private async Task SyncViaContinue()
        {
            await PrintTask($"{nameof(SyncViaContinue)}-1").ContinueWith(_ => PrintTask($"{nameof(SyncViaContinue)}-2"))
                                                           .ContinueWith(_ => PrintTask($"{nameof(SyncViaContinue)}-3"));
        }
    }
}
