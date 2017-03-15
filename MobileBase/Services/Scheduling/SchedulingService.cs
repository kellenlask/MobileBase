using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MobileBase.Services.Scheduling
{
    /// <summary>
    ///     This class allows an approach that I'm still not comfortable with: using C# Timers to circumvent the normal
    ///     application lifecycle. You should have to create background services to create background work -- and yet,
    ///     with C# timers, you don't seem to have to. I suspect the mono shared runtime is persisting past the life
    ///     of the running application, and propagating the timers that way; though, I really don't know what's
    ///     happening. Regardless, you could use this service to manage timers WITHIN the lifecycle of the application;
    ///     and so, I'm still going to write this class.
    /// </summary>
    public class SchedulingService
    {
        private readonly List<SchedulingModel> _tasks = new List<SchedulingModel>();
        private static SchedulingService _instance;

        public bool IsRunning { get; set; }

        public static SchedulingService Instance => _instance ?? (_instance = new SchedulingService());


        private SchedulingService()
        {
        }


        public void Start()
        {
            if (IsRunning)
            {
                return;
            }

            Task.Run(
                async () => {
                    try
                    {
                        await Run();
                    }
                    catch (Exception ex)
                    {
                        // TODO: Handle error
                    }
                }
            );

            IsRunning = true;
        }


        public void Stop()
        {
            if (!IsRunning)
            {
                return;
            }

            IsRunning = false;
        }


        private async Task Run()
        {
            var due = _tasks.Where(task => task.IsDue);

            foreach (var task in due)
            {
                try
                {
                    var runAgain = await task.Run();

                    if (!runAgain)
                    {
                        _tasks.Remove(task);
                    }
                }
                catch (Exception ex)
                {
                    // TODO: Handle error
                }
            }

            var nextRun = _tasks.Min(task => task.NextRun);
            //TODO: Set timer for next run
        }


        public void RemoveAll()
        {
            _tasks.Clear();
            Stop();
        }


        public Action Add(Func<bool> function, TimeSpan interval)
        {
            var model = SchedulingModel.Create(function, interval);
            _tasks.Add(model);

            Start();

            return () => _tasks.Remove(model);
        }


        public Action Add(Func<Task<bool>> function, TimeSpan interval)
        {
            var model = SchedulingModel.Create(function, interval);
            _tasks.Add(model);

            Start();

            return () => _tasks.Remove(model);
        }
    }
}