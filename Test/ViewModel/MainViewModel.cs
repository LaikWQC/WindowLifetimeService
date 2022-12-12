using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Test
{
    internal class MainViewModel
    {
        public MainViewModel()
        {
            CmdOpenWindow = new RelayCommand(OpenWindow);
        }

        public ICommand CmdOpenWindow { get; }
        private void OpenWindow()
        {
            var tier1Vm = new TierOneViewModel.Builder();
            tier1Vm.SetContext(WindowLifetimeService.CreateTierOneWindow(tier1Vm.Product));
        }
    }
}
