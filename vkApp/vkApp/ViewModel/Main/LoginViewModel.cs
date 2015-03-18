using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using vkApp.Controls;
using vkApp.Neptune.Messages;
using vkApp.Services;
using vkApp.View.Flyouts;
using VkLib.Core.Auth;

namespace vkApp.ViewModel.Main
{
    public class LoginViewModel : ViewModelBase
    {
        public RelayCommand LoginVkCommand { get; private set; }
        public LoginViewModel()
        {
            InitiailizeCommands();
        }
        private void InitiailizeCommands()
        {
            LoginVkCommand = new RelayCommand(DoLogin);
        }

        private async void DoLogin()
        {
            var redirectUri = DataService.Login();
            var flyout = new FlyoutControl();
            flyout.FlyoutContent = new WebValidationView(new Uri(redirectUri.Result));
            var token = await flyout.ShowAsync() as AccessToken;
            if (token != null)
            {
                AccountManager.SetLoginVk(token);

                ViewModelLocator.Main.ShowSidebar = ViewModelLocator.Main.ShowTopbar = true;

                MessengerInstance.Send(new NavigateToPageMessage() { Page = "/Main.ProfileView" });
            }
        }
    }
}