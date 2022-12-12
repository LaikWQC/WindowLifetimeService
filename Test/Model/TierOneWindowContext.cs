using System.Windows;
using Test.View;
using WindowLifetimeService;

namespace Test
{
    internal class TierOneWindowContext : WindowLifetimeContext , ITierOneViewContext
    {
        public TierOneWindowContext(Window window, WindowLifetimeContext childsOwner = null) : base(window, childsOwner)
        {

        }

        public void CreateTierTwoWindow()
        {
            CreateWindow(new TierTwoWindowContext(new TierTwoWindow()));
        }
    }
}
