using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;
using RxUISimpleTimer.Core.Models;

namespace RxUISimpleTimer.Core.ViewModels
{
    public class OperationViewModel : ReactiveObject
    {
        public OperationViewModel() : this(Scheduler.Default)
        {
        }

        public OperationViewModel(IScheduler scheduler)
        {
            dialogService = Locator.CurrentMutable.GetService<IDialogService>();
            stopWatch = new Stopwatch();

            Start = ReactiveCommand.Create(this.WhenAny(m => m.TimerState, m => m.Value != TimerState.Running));
            Start.Subscribe(_ => StartImpl());
            Stop = ReactiveCommand.Create(this.WhenAny(m => m.TimerState, m => m.Value != TimerState.Initial));
            Stop.Subscribe(_ => StopImpl());

            LapTimes = new ReactiveList<LapTime>();
            Lap = ReactiveCommand.CreateAsyncObservable(this.WhenAny(m => m.TimerState, m => m.Value == TimerState.Running), _ => Observable.Return(stopWatch.Elapsed));
            Lap.Subscribe(x => LapTimes.Add(new LapTime(x, x - (LapTimes.LastOrDefault()?.Elapsed ?? TimeSpan.Zero))));

            Observable.Interval(TimeSpan.FromMilliseconds(10d))
                .Where(_ => timerState != TimerState.Initial)
                .Select(_ => stopWatch.Elapsed.ToString(FormatString))
                .ToProperty(this, vm => vm.Elapsed, out elapsed, TimeSpan.Zero.ToString(FormatString), scheduler);
        }

        private const string FormatString = @"hh\:mm\:ss\.fff";

        private readonly IDialogService dialogService;

        private readonly Stopwatch stopWatch;

        public ReactiveCommand<object> Start { get; }

        private void StartImpl()
        {
            stopWatch.Start();
            TimerState = TimerState.Running;
        }

        public ReactiveCommand<object> Stop { get; }

        private void StopImpl()
        {
            switch (timerState)
            {
                case TimerState.Running:
                    stopWatch.Stop();
                    TimerState = TimerState.Stopped;
                    break;
                case TimerState.Stopped:
                    if (!dialogService.Confirm("Are you sure you want to start new?", "Confirm"))
                        return;
                    stopWatch.Reset();
                    LapTimes.Clear();
                    Task.Delay(10).Wait();  // bad
                    TimerState = TimerState.Initial;
                    break;
                case TimerState.Initial:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public ReactiveCommand<TimeSpan> Lap { get; }

        public ReactiveList<LapTime> LapTimes { get; } 

        private TimerState timerState;

        public TimerState TimerState
        {
            get { return timerState; }
            set { this.RaiseAndSetIfChanged(ref timerState, value); }
        }

        private readonly ObservableAsPropertyHelper<string> elapsed;

        public string Elapsed => elapsed.Value;
    }
}

