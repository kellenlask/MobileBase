using System;
using System.Threading.Tasks;


namespace MobileBase.Services.Scheduling
{
    internal class SchedulingModel
    {
        private readonly Func<Task<bool>> _functionAsync;
        private readonly Func<bool> _function;
        private readonly DateTime _created = DateTime.Now;

        public TimeSpan Interval { get; private set; }

        public DateTime? LastRun { get; private set; }

        public DateTime NextRun => (LastRun ?? _created) + Interval;

        public bool IsDue => NextRun < DateTime.Now;


        public SchedulingModel(Func<Task<bool>> function, TimeSpan interval)
        {
            _functionAsync = function;
            Interval = interval;
        }


        public SchedulingModel(Func<bool> function, TimeSpan interval)
        {
            _function = function;
            Interval = interval;
        }


        public async Task<bool> Run()
        {
            LastRun = DateTime.Now;

            if (_function == null && _functionAsync == null)
            {
                return false;
            }

            try
            {
                var task = _functionAsync?.Invoke();
                if (task != null)
                {
                    return await task;
                }

                return _function?.Invoke() ?? false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR: Failed to run scheduled task with exception: {ex}");
                return false;
            }
        }


        public SchedulingModel With(TimeSpan interval) => _function == null
            ? Create(_functionAsync, interval)
            : Create(_function, interval);


        public SchedulingModel With(Func<bool> function) => new SchedulingModel(function, Interval)
        {
            LastRun = LastRun
        };


        public SchedulingModel With(Func<Task<bool>> function) => new SchedulingModel(function, Interval)
        {
            LastRun = LastRun
        };


        public static SchedulingModel Create(Func<Task<bool>> function, TimeSpan interval) => new SchedulingModel(
            function,
            interval
        );


        public static SchedulingModel Create(Func<bool> function, TimeSpan interval) => new SchedulingModel(
            function,
            interval
        );
    }
}