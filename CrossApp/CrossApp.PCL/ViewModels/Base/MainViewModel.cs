using CrossApp.PCL.ViewModels;

namespace CrossApp.PCL.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public void ShowMenu()
        {
            ShowViewModel<HomeViewModel>();
            ShowViewModel<MenuViewModel>();
        }

        public void ShowHome()
        {
            ShowViewModel<HomeViewModel>();
        }

        public override void Start()
        {
            //base.Start();
        }
    }
}