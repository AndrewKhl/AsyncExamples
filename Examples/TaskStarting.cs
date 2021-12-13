using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExamples.Examples
{
    internal sealed class TaskStarting : ExampleGroup
    {
        protected override string GroupName => nameof(TaskStarting);


        protected override async Task RunExamples()
        {
            await RunTaskWithConstructor();
            await RunTaskWithFactory();
            await RunTaskWithRun();

            //await RunTaskWithRun();

            //await RunTask();
            //await RunAwaitTask();

            //await RunTaskWithRun();

            #region WTF

            //await WTFAsync();

            #endregion
        }


        //редко используется, поддерживает только Action
        private Task RunTaskWithConstructor()
        {
            var task = new Task(() => PrintVoid(nameof(RunTaskWithConstructor)));
            //var task = new Task(async () => await PrintTask(nameof(RunTaskWithConstructor)));

            task.Start();

            return task;
        }

        //появился раньше Run, поддерживает Action и Action<T> + доп настройки и кастомные планировщики
        private Task RunTaskWithFactory()
        {
            //одинаковое поведение для всех реализаций, т.к. возвращает Task<Task>, для одинаковой реализации использовать Unwrap (продвинутая техника)
            var task = Task.Factory.StartNew(() => PrintVoid(nameof(RunTaskWithFactory))); 
            //var task = Task.Factory.StartNew(() => PrintTask(nameof(RunTaskWithFactory)));

            return task;
        }

        //появился только в Net4.5, поддерживает Action и Action<T>, всегда выполняется на стандартном планировщике
        //используется чаще других запусков
        private Task RunTaskWithRun()
        {
            //разное поведение для реализации Task и void, т.к. делает Unwrap сам
            var task = Task.Run(() => PrintVoid(nameof(RunTaskWithRun)));
            //var task = Task.Run(() => PrintTask(nameof(RunTaskWithRun)));

            return task;
        }

        #region WTF?!?

        private static async Task WTFAsync()
        {
            int result = await await Task.Factory.StartNew(async () =>
            {
                Console.WriteLine("Start WTF method");

                await Task.Delay(WaitDelay);

                Console.WriteLine("End WTF method");

                return 42;
            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
        }

        #endregion

        // улучшаяет стектрейс при ошибке, но накладывает дополнительный оверхед по памяти и скорости,
        // т.к. разворачивается в узел типа u -> u. Единственный спомоб (который я знаю), где лучше его
        // использовать -> обрабатывать запросы к сторонним библиотекам, т.к. при генерации ошибки в методе
        // стектрейс будет содержать ваш нод для лучшего деббагинга, в остальных случаях лучше возвращать таску
        private async Task RunAwaitTask()
        {
            await PrintTask(nameof(RunAwaitTask));
        }

        private Task RunTask()
        {
            return PrintTask(nameof(RunTask));
        }
    }
}
