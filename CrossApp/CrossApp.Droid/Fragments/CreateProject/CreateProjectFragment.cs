using Android.Runtime;
using CrossApp.PCL.ViewModels;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using Android.Views.InputMethods;
using MvvmCross.Binding.Droid.Views;
using Android.InputMethodServices;
using Acr.UserDialogs;

namespace CrossApp.Droid.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("crossapp.droid.fragments.CreateProjectFragment")]
    public class CreateProjectFragment : BaseFragment<CreateProjectViewModel>
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.fragment_create_project;

    }
}