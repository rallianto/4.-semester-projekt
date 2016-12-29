using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace CrossApp.PCL
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //RegisterAppStart<ViewModels.MainViewModel>();

            // Construct custom application start object
            Mvx.ConstructAndRegisterSingleton<IMvxAppStart, AppStart>();

            //User Dialog from github.com/aritchie/userdialogs
            Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

            // request a reference to the constructed appstart object 
            var appStart = Mvx.Resolve<IMvxAppStart>();

            // register the appstart object
            RegisterAppStart(appStart);
        }
    }
}
