using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
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
            this.WhenAny(vm => vm.TimerState, oc => oc.Value == TimerState.Initial).Subscribe(_ => LapTimes.Reset());

            Observable.Interval(TimeSpan.FromMilliseconds(10d))
                .Select(_ => GetFormattedElapsed(stopWatch.Elapsed))
                .ToProperty(this, vm => vm.Elapsed, out elapsed, GetFormattedElapsed(TimeSpan.Zero), scheduler);
        }

        private const string FormatStringWithoutMsec = @"hh\:mm\:ss";

        private const string FormatStringWithMsec = @"hh\:mm\:ss\.fff";

        public string GetFormattedElapsed(TimeSpan t) => t.ToString(showMilliseconds ? FormatStringWithMsec : FormatStringWithoutMsec);
        
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

        private bool showMilliseconds = true;

        public bool ShowMilliseconds
        {
            get { return showMilliseconds; }
            set { this.RaiseAndSetIfChanged(ref showMilliseconds, value); }
        }

        private readonly ObservableAsPropertyHelper<string> elapsed;

        public string Elapsed => elapsed.Value;
    }
}

