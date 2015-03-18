using GalaSoft.MvvmLight;
using System;
using System.Threading;
using System.Threading.Tasks;
using vkApp.Services;
using VkLib.Core.Groups;

namespace vkApp.ViewModel.Selected
{
    public class GroupViewModel : ViewModelBase
    {

        private VkGroup _selectedGroup;
        private VkGroupById _group;
        private CancellationTokenSource _cancellationToken;

        public VkGroup SelectedGroup
        {
            get { return _selectedGroup; }
            set { Set(ref _selectedGroup, value); }
        }
        public VkGroupById Group
        {
            get { return _group; }
            set
            {
                if (_group == value)
                    return;

                _group = value;
                RaisePropertyChanged("Group");
            }
        }
        public async void Activate()
        {
            await LoadGroupInfo();
        }

        public async Task LoadGroupInfo()
        {
            ViewModelLocator.Main.IsWorking = true;
            try
            {
                Group = await DataService.GetGroupById(_selectedGroup.Id, "description");
            }
            catch (Exception ex)
            {
                LoggingService.Log(ex);
            }
            ViewModelLocator.Main.IsWorking = false;
        }

        public void Deactivate()
        {
            CancelAsync();
        }
        public GroupViewModel()
        {
            _cancellationToken = new CancellationTokenSource();
        }
        private void CancelAsync()
        {
            if (_cancellationToken != null)
                _cancellationToken.Cancel();

            _cancellationToken = new CancellationTokenSource();
        }

    }
}