using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using System;

namespace CrossApp.PCL.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {

        IUserDialogs _userDialog;

        public MenuViewModel (IUserDialogs userDialog)
        {
            _userDialog = userDialog;
        }

        //Home
        public IMvxCommand ShowHomeCommand
        {
            get { return new MvxCommand(ShowHomeExecuted); }
        }

        private void ShowHomeExecuted()
        {
            ShowViewModel<HomeViewModel>();
        }

        //Create Job
        public IMvxCommand ShowCreateProjectCommand
        {
            get { return new MvxCommand(ShowCreateProjectExecuted); }
        }

        private void ShowCreateProjectExecuted()
        {
            ShowViewModel<CreateProjectViewModel>();
        }

        //Find job
        public IMvxCommand ShowFindProjectCommand
        {
            get { return new MvxCommand(ShowFindProjectExecuted); }
        }

        private void ShowFindProjectExecuted()
        {
            ShowViewModel<FindProjectViewModel>();
        }

        //Opret bruger
        public IMvxCommand ShowUserLogin
        {
            get { return new MvxCommand(DoUserLogin); }
        }

        private void DoUserLogin()
        {
            LoginConfig config = new LoginConfig();
            config.CancelText = "Fortryd";
            config.LoginPlaceholder = "Brugernavn";
            config.OkText = "Log ind";
            config.PasswordPlaceholder = "Kodeord";
            config.Title = "Log ind";
            config.OnAction = _loginMethod;

            _userDialog.Login(config);
        }

        private void _loginMethod(LoginResult res)
        {
            _userDialog.Alert("Du har forsøgt at logge ind som: " + res.LoginText + " med kode: " + res.Password);
        }




    }
}