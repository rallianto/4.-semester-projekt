using Android.Runtime;
using CrossApp.PCL.ViewModels;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;

namespace CrossApp.Droid.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("crossapp.droid.fragments.FindProjectFragment")]
    public class FindProjectFragment : BaseFragment<FindProjectViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.fragment_find_project;
    }
}