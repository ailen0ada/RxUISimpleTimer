using System;
using System.Windows.Forms;
using ReactiveUI;
using ReactiveUI.Winforms;
using RxUISimpleTimer.Core.ViewModels;

namespace RxUISimpleTimer.WinForms
{
    public partial class MainForm : Form, IViewFor<OperationViewModel>
    {
        public MainForm()
        {
            InitializeComponent();

            ViewModel = new OperationViewModel(RxApp.MainThreadScheduler);
            this.OneWayBind(ViewModel, vm => vm.Elapsed, v => v.ElapsedLabel.Text);
            this.Bind(ViewModel, vm => vm.ShowMilliseconds, v => v.ShowMsecCheck.Checked);
            this.BindCommand(ViewModel, vm => vm.Start, v => v.StartButton);
            this.BindCommand(ViewModel, vm => vm.Stop, v => v.StopButton);
            this.BindCommand(ViewModel, vm => vm.Lap, v => v.LapButton);

            LapTimesBindingList = ViewModel.LapTimes.CreateDerivedBindingList(x => $"{ViewModel.GetFormattedElapsed(x.Elapsed)} - {ViewModel.GetFormattedElapsed(x.Duration)}");
            LapTimes.DataSource = LapTimesBindingList;
            ViewModel.WhenAny(vm => vm.ShowMilliseconds, oc => true).Subscribe(_ => LapTimesBindingList.Reset());
        }

        private IReactiveDerivedBindingList<string> LapTimesBindingList { get; } 

        /// <summary/>
        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = value as OperationViewModel; }
        }

        OperationViewModel IViewFor<OperationViewModel>.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = value; }
        }

        /// <summary>
        /// The ViewModel corresponding to this specific View. This should be
        ///             a DependencyProperty if you're using XAML.
        /// </summary>
        public OperationViewModel ViewModel { get; private set; }
    }
}
