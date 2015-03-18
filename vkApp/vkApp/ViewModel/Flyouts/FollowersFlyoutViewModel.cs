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
    public class FollowersFlyoutViewModel : ViewModelBase
    {
        private List<VkProfile> _followers;
        private VkProfile _selectedUser;
        public RelayCommand<VkProfile> GoToUserCommand { get; private set; }
        public FollowersFlyoutViewModel()
        {
            InitializeCommands();
        }
        public List<VkProfile> Followers
        {
            get { return _followers; }
            set { Set(ref _followers, value); }
        }
        public VkProfile SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (Set(ref _selectedUser, value))
                    LoadFollowers();
            }
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
        private async void LoadFollowers()
        {
            ViewModelLocator.Main.IsWorking = true;
            try
            {
                var followers = await DataService.GetFollowers(SelectedUser.Id);
                if (followers.Items != null && followers.Items.Count > 0)
                {
                    Followers = followers.Items;
                }
                else
                {
                    Console.WriteLine("Followers are null");
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