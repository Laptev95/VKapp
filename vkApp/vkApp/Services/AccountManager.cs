using GalaSoft.MvvmLight.Messaging;
using System;
using vkApp.Model;
using vkApp.Neptune.Messages;
using vkApp.Services.Media;
using vkApp.ViewModel;
using VkLib;
using VkLib.Core.Auth;
using VkLib.Token;

namespace vkApp.Services
{
    public static class AccountManager
    {
        private static readonly Vkontakte _vkontakte;
        static AccountManager()
        {
            _vkontakte = ViewModelLocator.Vkontakte;
        }

        public static void SetLoginVk(AccessToken token)
        {
            if (token == null || token.Token == null)
            {
                throw new ArgumentException("AccessToken is empty");
            }
            else
            {
                _vkontakte.AccessToken = token;
                Settings.Instance.AccessToken = token;
                Settings.Instance.Save();
            }
        }
        public static void LogOutVk()
        {
            AudioService.Stop();
            AudioService.CurrentAudio = null;
            AudioService.SetCurrentPlaylist(null);
            AudioService.Clear();

            _vkontakte.AccessToken.Token = null;
            _vkontakte.AccessToken.UserId = 0;
            _vkontakte.AccessToken.ExpiresIn = DateTime.MinValue;

            Settings.Instance.AccessToken = null;
            Settings.Instance.Save();

            ViewModelLocator.Main.ShowSidebar = false;
            ViewModelLocator.Main.ShowTopbar = false;
            Messenger.Default.Send(new NavigateToPageMessage() { Page = "/Main.LoginView" });
        }
    }
}
