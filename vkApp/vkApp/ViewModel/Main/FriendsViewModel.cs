using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using vkApp.Neptune.Messages;
using vkApp.Services;
using VkLib.Core.Users;

namespace vkApp.ViewModel.Main
{
    public class FriendsViewModel : ViewModelBase
    {
        private List<VkProfile> _friends;

        public RelayCommand<VkProfile> GoToFriendCommand { get; private set; }

        public List<VkProfile> Friends
        {
            get { return _friends; }
            set { Set(ref _friends, value); }
        }
        public void Activate()
        {
            if (Friends == null || Friends.Count == 0)
                LoadFriends();
        }
        public FriendsViewModel()
        {
            InitializeCommands();
        }
        private void InitializeCommands()
        {
            GoToFriendCommand = new RelayCommand<VkProfile>(user =>
            {
                MessengerInstance.Send(new NavigateToPageMessage()
                {
                    Page = "/Selected.UserView",
                    Parameters = new Dictionary<string, object>()
                    {
                        {"user", user}
                    }
                });
            });
        }
        private async void LoadFriends()
        {
            ViewModelLocator.Main.IsWorking = true;
            try
            {
                var friends = await DataService.GetFriends(0, 0, 0, "photo_100");
                if (friends.Items != null && friends.Items.Count > 0)
                {
                    Friends = friends.Items;
                }
                else
                {
                    Console.WriteLine("friends are null");
                }
            }
            catch (Exception ex)
            {
                LoggingService.Log(ex);
            }
            ViewModelLocator.Main.IsWorking = false;
        }
    }
}