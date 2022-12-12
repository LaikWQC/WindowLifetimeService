using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace Test
{
    internal class TierOneViewModel
    {
        #region Builder
        public class Builder
        {
            public TierOneViewModel Product { get; } = new TierOneViewModel();
            public void SetContext(ITierOneViewContext context)
            {
                Product._viewContext = context;
            }
        }
        #endregion

        private ITierOneViewContext _viewContext;
        private TierOneViewModel()
        {
            CmdOpenWindow = new RelayCommand(OpenWindow);
        }

        public ICommand CmdOpenWindow { get; }
        private void OpenWindow()
        {
            _viewContext.CreateTierTwoWindow();
        }
    }
}
