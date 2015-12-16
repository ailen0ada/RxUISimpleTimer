using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using ReactiveUI;
using Splat;
using RxUISimpleTimer.Core.Models;

namespace RxUISimpleTimer.Core.ViewModels
{
    public class OperationViewModel : ReactiveObject
    {
        public OperationViewModel()
        {
            dialogService = Locator.CurrentMutable.GetService<IDialogService>();
            stopWatch = new Stopwatch();
            elapsed = TimeSpan.Zero.ToString(FormatString);

            Start = ReactiveCommand.Create(this.WhenAny(m => m.TimerState, m => m.Value != TimerState.Running));
            Start.Subscribe(_ => StartImpl());
            Stop = ReactiveCommand.Create(this.WhenAny(m => m.TimerState, m => m.Value != TimerState.Initial));
            Stop.Subscribe(_ => StopImpl());

            LapTimes = new ReactiveList<LapTime>();
            Lap = ReactiveCommand.CreateAsyncObservable(this.WhenAny(m => m.TimerState, m => m.Value == TimerState.Running), _ => Observable.Return(stopWatch.Elapsed));
            Lap.Subscribe(x => LapTimes.Add(new LapTime(x, x - (LapTimes.LastOrDefault()?.Elapsed ?? TimeSpan.Zero))));
        }

        private const string FormatString = @"hh\:mm\:ss\.fff";

        private readonly IDialogService dialogService;

        private readonly Stopwatch stopWatch;

        private IDisposable TimerSubscription { get; set; }

        public ReactiveCommand<object> Start { get; }

        private void StartImpl()
        {
            stopWatch.Start();
            TimerSubscription = Observable
                .Interval(TimeSpan.FromMilliseconds(10d))
                .Select(_ => stopWatch.Elapsed.ToString(FormatString))
                .Subscribe(s => Elapsed = s);
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
                    TimerSubscription.Dispose();
                    TimerSubscription = null;
                    Elapsed = TimeSpan.Zero.ToString(FormatString);
                    LapTimes.Clear();
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

        private string elapsed;

        public string Elapsed
        {
            get { return elapsed; }
            set { this.RaiseAndSetIfChanged(ref elapsed, value); }
        }
    }
}

