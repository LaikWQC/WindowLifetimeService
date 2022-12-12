using System.Windows;
using Test.View;
using WindowLifetimeService;

namespace Test
{
    internal class MainWindowContext : WindowLifetimeContext
    {
        public MainWindowContext(Window window) : base(window)
        {

        }

        public ITierOneViewContext CreateTierOneWindow(TierOneViewModel vm)
        {
            var context = new TierOneWindowContext(new TierOneWindow() { DataContext = vm });
            CreateWindow(context);
            return context;
        }
    }
}
