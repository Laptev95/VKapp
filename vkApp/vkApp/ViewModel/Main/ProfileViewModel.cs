using GalaSoft.MvvmLight;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using vkApp.Services;
using VkLib.Core.Users;
using VkLib.Core.Friends;
using VkLib.Token;
using System.Collections.Generic;
using GalaSoft.MvvmLight.CommandWpf;
using vkApp.Neptune.Messages;
using vkApp.View.Flyouts;
using vkApp.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace vkApp.ViewModel.Main
{
    public class ProfileViewModel : ViewModelBase
    {
        private VkCount _profile;
        private CancellationTokenSource _cancellationToken;

        private bool _showHomeTown;
        private bool _showBDate;
        private bool _showStudyPlace;
        private bool _showCity;
        private bool _showOnline;
        private bool _showOnlineMobile;
        private bool _showLastSeen;

        public VkCount Profile
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

        public RelayCommand GoToFriendsView { get; private set; }
        public RelayCommand GoToGroupsView { get; private set; }
        public RelayCommand GoToMusicView { get; private set; }
        public RelayCommand GoToFollowersFlyout { get; private set; }
        private void InitializeCommands()
        {
            GoToFriendsView = new RelayCommand(() =>
            {
                Messenger.Default.Send(new NavigateToPageMessage()
                {
                    Page = "/Main.FriendsView"
                });
            });

            GoToGroupsView = new RelayCommand(() =>
            {
                Messenger.Default.Send(new NavigateToPageMessage()
                {
                    Page = "/Main.GroupsView"
                });
            });

            GoToMusicView = new RelayCommand(() =>
            {
                Messenger.Default.Send(new NavigateToPageMessage()
                {
                    Page = "/Main.MusicView"
                });
            });
            GoToFollowersFlyout = new RelayCommand(() =>
            {
                var flyout = new FlyoutControl();
                flyout.FlyoutContent = new FollowersFlyout(Profile);
                flyout.Show();
            });
        }
        public ProfileViewModel()
        {
            _cancellationToken = new CancellationTokenSource();
            InitializeCommands();
        }

        public async Task Activate()
        {
            await LoadUserInfo();
        }
        public void Deactivate()
        {
            CancelAsync();
        }
        public async Task LoadUserInfo()
        {
            ViewModelLocator.Main.IsWorking = true;

            var start = DateTime.Now;

            try
            {
                Profile = await DataService.GetProfile(Settings.Instance.AccessToken.UserId, "groups", "photo_100,home_town,bdate,online,online_mobile,last_seen,sex,education,schools,city");

                if (Profile != null)
                    await checkNull();
            }
            catch (Exception ex)
            {
                var flyout = new FlyoutControl();
                flyout.FlyoutContent = new CommonMessageView() { Header = "Profile Failed Error", Message = "Something goes wrong" };
                flyout.Show();

                LoggingService.Log(ex);
            }

            var end = DateTime.Now.Subtract(start).TotalSeconds;
            Console.WriteLine("Profile... Finish all in " + end + " second \n");

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
        private void CancelAsync()
        {
            if (_cancellationToken != null)
                _cancellationToken.Cancel();

            _cancellationToken = new CancellationTokenSource();
        }
    }
}