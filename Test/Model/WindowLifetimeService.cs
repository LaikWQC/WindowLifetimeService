using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Test
{
    internal class WindowLifetimeService
    {
        private static WindowLifetimeService _instance;
        public static void Init(Window mainWindow)
        {
            _instance = new WindowLifetimeService(mainWindow);
        }

        private MainWindowContext _window;
        private WindowLifetimeService(Window mainWindow)
        {
            _window = new MainWindowContext(mainWindow);
        }

        public static ITierOneViewContext CreateTierOneWindow(TierOneViewModel vm)
        {
            return _instance._window.CreateTierOneWindow(vm);
        }
    }
    internal interface ITierOneViewContext
    {
        void CreateTierTwoWindow();
    }
}
