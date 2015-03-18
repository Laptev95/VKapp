using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using vkApp.Neptune.Messages;
using vkApp.Services;
using VkLib.Core.Groups;

namespace vkApp.ViewModel.Main
{
    public class GroupsViewModel : ViewModelBase
    {
        private List<VkGroup> _groups;
        public RelayCommand<VkGroup> GoToSocietyCommand { get; private set; }
        public List<VkGroup> Groups
        {
            get { return _groups; }
            set
            {
                if (_groups == value)
                    return;

                _groups = value;
                RaisePropertyChanged("Groups");
            }
        }

        public void Activate()
        {
            if (Groups == null || Groups.Count == 0)
                LoadGroups();
        }
        public GroupsViewModel()
        {
            InitializeCommands();
        }
        private void InitializeCommands()
        {
            GoToSocietyCommand = new RelayCommand<VkGroup>(group =>
            {
                MessengerInstance.Send(new NavigateToPageMessage()
                {
                    Page = "/Selected.GroupView",
                    Parameters = new Dictionary<string, object>()
                    {
                        {"group", group}
                    }
                });
            });
        }
        private async void LoadGroups()
        {
            ViewModelLocator.Main.IsWorking = true;
            try
            {
                var groups = await DataService.GetGroups(0, 0, 0, "photo,photo_100");
                Console.WriteLine(groups.TotalCount);
                if (groups.Items != null && groups.Items.Count > 0)
                {
                    Groups = groups.Items;
                }
                else
                {
                    Console.WriteLine("Groups are null");
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