using System;
using RxUISimpleTimer.Core.Models;
using Splat;

namespace RxUISimpleTimer.Core.Models
{
    public class SimpleTimer
    {
        public SimpleTimer()
        {
            dialogService = Locator.CurrentMutable.GetService<IDialogService>();
        }

        private readonly IDialogService dialogService;
    }
}

