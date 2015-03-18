using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Threading;
using System.Threading.Tasks;
using vkApp.Controls;
using vkApp.Services;
using vkApp.View.Flyouts;
using VkLib.Core.Users;
using VkLib.Token;

namespace vkApp.ViewModel.Selected
{
    public class UserViewModel : ViewModelBase
    {
        private VkProfile _selectedUser;
        private VkProfile _profile;

        private bool _showHomeTown;
        private bool _showBDate;
        private bool _showStudyPlace;
        private bool _showCity;
        private bool _showOnline;
        private bool _showOnlineMobile;
        private bool _showLastSeen;
        private CancellationTokenSource _cancellationToken;

        public VkProfile SelectedUser
        {
            get { return _selectedUser; }
            set { Set(ref _selectedUser, value); }
        }
        public VkProfile Profile
        {
            get { return _profile; }
            set
            {
                if (_profile == value)
                    return;

                _profile = value;
                RaisePropertyChanged("Profile");
            }
        }

        #region bool ShowInfo
        public bool ShowHomeTown
        {
            get
            {
                if (IsInDesignMode)
                    return true;
                return _showHomeTown;
            }
            set
            {
                Set(ref _showHomeTown, value);
            }
        }
        public bool ShowCity
        {
            get
            {
                if (IsInDesignMode)
                    return true;
                return _showCity;
            }
            set
            {
                Set(ref _showCity, value);
            }
        }
        public bool ShowBDate
        {
            get
            {
                if (IsInDesignMode)
                    return true;
                return _showBDate;
            }
            set
            {
                Set(ref _showBDate, value);
            }
        }
        public bool ShowStudyPlace
        {
            get
            {
                if (IsInDesignMode)
                    return true;
                return _showStudyPlace;
            }
            set
            {
                Set(ref _showStudyPlace, value);
            }
        }
        public bool ShowOnline
        {
            get
            {
                if (IsInDesignMode)
                    return true;
                return _showOnline;
            }
            set
            {
                Set(ref _showOnline, value);
            }
        }
        public bool ShowOnlineMobile
        {
            get
            {
                if (IsInDesignMode)
                    return true;
                return _showOnlineMobile;
            }
            set
            {
                Set(ref _showOnlineMobile, value);
            }
        }
        public bool ShowLastSeen
        {
            get
            {
                if (IsInDesignMode)
                    return true;
                return _showLastSeen;
            }
            set
            {
                Set(ref _showLastSeen, value);
            }
        }
        #endregion

        public RelayCommand FriendsFlyout { get; private set; }
        private void InitializeCommands()
        {
            FriendsFlyout = new RelayCommand(() =>
            {
                var flyout = new FlyoutControl();
                flyout.FlyoutContent = new FriendsFlyout(SelectedUser);
                flyout.Show();
            });
        }
        public async void Activate()
        {
            await LoadUserInfo();
        }
        public async Task LoadUserInfo()
        {
            ViewModelLocator.Main.IsWorking = true;
            try
            {
                Profile = await DataService.GetProfile(SelectedUser.Id,Settings.Instance.AccessToken.UserId.ToString(), "photo_100,home_town,bdate,online,online_mobile,last_seen,sex,education,schools,city");
                if (Profile != null)
                    await checkNull();
            }
            catch (Exception ex)
            {
                var flyout = new FlyoutControl();
                flyout.FlyoutContent = new CommonMessageView() { Header = "Profile Failed Error", Message = "Error" };
                flyout.Show();

                LoggingService.Log(ex);
            }
            ViewModelLocator.Main.IsWorking = false;
        }
        public async Task checkNull()
        {
            if (!String.IsNullOrEmpty(Profile.HomeTown))
                ShowHomeTown = true;
            if (Profile.City != null && String.IsNullOrEmpty(Profile.HomeTown))
                ShowCity = true;
            if (Profile.BirthDay != null)
                ShowBDate = true;
            if (Profile.StudyPlace != null)
                ShowStudyPlace = true;
            if (Profile.IsOnlineMobile)
                ShowOnlineMobile = true;
            else if (Profile.IsOnline)
                ShowOnline = true;
            if (!Profile.IsOnline && !Profile.IsOnlineMobile && Profile.LastSeen != null)
                ShowLastSeen = true;
        }

        public void Deactivate()
        {
            CancelAsync();
        }
        public UserViewModel()
        {
            _cancellationToken = new CancellationTokenSource();

            InitializeCommands();
        }
        private void CancelAsync()
        {
            if (_cancellationToken != null)
                _cancellationToken.Cancel();

            _cancellationToken = new CancellationTokenSource();
        }
    }
}