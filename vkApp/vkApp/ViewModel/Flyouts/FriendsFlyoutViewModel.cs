using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using vkApp.Neptune.Messages;
using vkApp.Services;
using vkApp.View.Flyouts;
using VkLib.Core.Users;

namespace vkApp.ViewModel.Flyouts
{
    public class FriendsFlyoutViewModel : ViewModelBase
    {
        private List<VkProfile> _friends;
        private VkProfile _selectedUser;
        private int _selectedTabIndex;

        public RelayCommand<VkProfile> GoToUserCommand { get; private set; }

        public List<VkProfile> Friends
        {
            get { return _friends; }
            set { Set(ref _friends, value); }
        }
        public VkProfile SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (Set(ref _selectedUser, value))
                    LoadFriends();
            }
        }
        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set
            {
                if (Set(ref _selectedTabIndex, value))
                {
                    switch (value)
                    {
                        case 0:
                            Console.WriteLine("0");
                            LoadFriends();
                            break;

                        case 1:
                            Console.WriteLine("1");
                            break;
                    }
                }
            }
        }
        public FriendsFlyoutViewModel()
        {
            InitializeCommands();
        }
        private void InitializeCommands()
        {
            GoToUserCommand = new RelayCommand<VkProfile>(user =>
            {
                MessengerInstance.Send(new NavigateToPageMessage()
                {
                    Page = "/Selected.UserView",
                    Parameters = new Dictionary<string, object>()
                    {
                        {"user", user}
                    }
                });
                FriendsFlyout.Close();
            });
        }
        private async void LoadFriends()
        {
            ViewModelLocator.Main.IsWorking = true;
            try
            {
                var friends = await DataService.GetFriends(SelectedUser.Id, 0, 0, "photo_100");
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