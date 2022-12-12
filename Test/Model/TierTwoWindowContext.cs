using System.Windows;
using WindowLifetimeService;

namespace Test
{
    internal class TierTwoWindowContext : WindowLifetimeContext
    {
        public TierTwoWindowContext(Window window) : base(window)
        {

        }
    }
}
