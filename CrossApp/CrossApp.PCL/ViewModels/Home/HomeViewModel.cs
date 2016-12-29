using MvvmCross.Core.ViewModels;

namespace CrossApp.PCL.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
        }

        public MvxCommand GoToInfoCommand
        {
            get { return new MvxCommand(() => System.Diagnostics.Debug.WriteLine("Knap blev trykket!")); }
        }
    }
}
