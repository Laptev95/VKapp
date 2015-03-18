using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using vkApp.Model;
using vkApp.Services;
using vkApp.ViewModel.Messages;
using VkLib.Core.Audio;
using GalaSoft.MvvmLight;
using VkLib;
using vkApp.Services.Media;
using VkLib.Token;
using System.Windows.Controls;
using vkApp.Neptune.Extensions;
using VkLib.Error;
using vkApp.Neptune.Messages;
using Yandex.Metrica;
using vkApp.Controls;
using vkApp.View;
using VkLib.Core.Users;
using vkApp.View.Flyouts;

namespace vkApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly MenuItemsCollection _mainMenuItems = new MenuItemsCollection()
        {
            //new MainMenuItem() {Group = MainResources.MainMenuLocalTitle, GroupIcon = Application.Current.Resources["DeviceIcon"], Page = "/Local.LocalCollectionView", Title =  MainResources.MainMenuCollection},
            new MainMenuItem() {Group = "Menu", Icon = Application.Current.Resources["User"], Page = "/Main.ProfileView", Title =  "Профиль"},
            new MainMenuItem() {Group = "Menu", Icon = Application.Current.Resources["Photos"], Page = "/Main.PhotosView", Title =  "Фотографии"},
            new MainMenuItem() {Group = "Menu", Icon = Application.Current.Resources["Music"], Page = "/Main.MusicView", Title =  "Аудиозаписи"},
            new MainMenuItem() {Group = "Menu", Icon = Application.Current.Resources["Friends"], Page = "/Main.FriendsView", Title =  "Друзья"},
            new MainMenuItem() {Group = "Menu", Icon = Application.Current.Resources["Groups"], Page = "/Main.GroupsView", Title =  "Группы"},
            new MainMenuItem() {Group = "Menu", Icon = Application.Current.Resources["SettingsIcon"], Page = "/Settings.SettingsView", Title =  "Настройки"}
        };
        private MainMenuItem _selectedMainMenuItem;
        private int _selectedMainMenuItemIndex;
        private bool _statusUpdated;
        private bool _canNavigate = true;
        private WindowState _windowState;
        private UIMode _currentUIMode;
        private bool _showSidebar;
        private bool _showTopbar;
        private bool _isWorking;

        private VkProfile _vkProfile;
        public VkProfile Profile
        {
            get { return _vkProfile; }
            set
            {
                if (_vkProfile == value)
                    return;

                _vkProfile = value;
                RaisePropertyChanged("Profile");
            }
        }
        public bool IsWorking
        {
            get { return _isWorking; }
            set
            {
                if (_isWorking == value)
                    return;

                _isWorking = value;
                RaisePropertyChanged("IsWorking");
            }
        }

        #region Commands

        public RelayCommand CloseWindowCommand { get; private set; }

        public RelayCommand MinimizeWindowCommand { get; private set; }

        public RelayCommand MaximizeWindowCommand { get; private set; }

        public RelayCommand<string> GoToPageCommand { get; private set; }

        public RelayCommand GoBackCommand { get; private set; }

        public RelayCommand<string> SearchCommand { get; private set; }

        public RelayCommand NextAudioCommand { get; private set; }

        public RelayCommand PrevAudioCommand { get; private set; }

        public RelayCommand PlayPauseCommand { get; private set; }

        public RelayCommand RestartCommand { get; private set; }

        public RelayCommand SwitchUIModeCommand { get; private set; }

        public RelayCommand<string> SwitchToUIModeCommand { get; private set; }

        public RelayCommand<vkApp.Model.VkAudio> AddRemoveAudioCommand { get; private set; }

        public RelayCommand<vkApp.Model.VkAudio> EditAudioCommand { get; private set; }

        public RelayCommand<vkApp.Model.VkAudio> ShareAudioCommand { get; private set; }

        public RelayCommand<vkApp.Model.VkAudio> ShowLyricsCommand { get; private set; }

        public RelayCommand<Audio> CopyInfoCommand { get; private set; }

        public RelayCommand<Audio> PlayAudioNextCommand { get; private set; }

        public RelayCommand<Audio> AddToNowPlayingCommand { get; private set; }

        public RelayCommand<Audio> RemoveFromNowPlayingCommand { get; private set; }

        public RelayCommand<string> ShowArtistInfoCommand { get; private set; }

        public RelayCommand<Audio> StartTrackRadioCommand { get; private set; }

        public RelayCommand<vkApp.Model.VkAudio> AddToAlbumCommand { get; private set; }

        public RelayCommand ShowLocalSearchCommand { get; private set; }

        #endregion

        public bool ShowSidebar
        {
            get
            {
                if (IsInDesignMode)
                    return true;
                return _showSidebar;
            }
            set
            {
                Set(ref _showSidebar, value);
            }
        }
        public bool ShowTopbar
        {
            get
            {
                if (IsInDesignMode)
                    return true;
                return _showTopbar;
            }
            set
            {
                Set(ref _showTopbar, value);
            }
        }
        public MenuItemsCollection MainMenuItems
        {
            get { return _mainMenuItems; }
        }
        public MainMenuItem SelectedMainMenuItem
        {
            get { return _selectedMainMenuItem; }
            set
            {
                if (Set(ref _selectedMainMenuItem, value) && value != null && _canNavigate)
                    OnNavigateToPage(new NavigateToPageMessage() { Page = value.Page });
            }
        }
        public int SelectedMainMenuItemIndex
        {
            get
            {
                return _selectedMainMenuItemIndex;
            }
            set
            {
                Set(ref _selectedMainMenuItemIndex, value);
            }
        }
        public Audio CurrentAudio
        {
            get
            {
                if (!IsInDesignMode)
                    return AudioService.CurrentAudio;
                else
                {
                    var a = new Audio() { Artist = "Artist", Title = "Title" };
                    return a;
                }
            }
        }
        public TimeSpan CurrentAudioPosition
        {
            get
            {
                if (IsInDesignMode)
                    return TimeSpan.Zero;
                return AudioService.CurrentAudioPosition;
            }
        }
        public double CurrentAudioPositionSeconds
        {
            get
            {
                if (IsInDesignMode)
                    return 0;
                return AudioService.CurrentAudioPosition.TotalSeconds;
            }
            set
            {
                AudioService.CurrentAudioPosition = TimeSpan.FromSeconds(value);
            }
        }
        public TimeSpan CurrentAudioDuration
        {
            get
            {
                if (AudioService.CurrentAudioDuration == TimeSpan.Zero)
                    return TimeSpan.FromMilliseconds(1000);
                return AudioService.CurrentAudioDuration;
            }
        }
        public bool IsPlaying
        {
            get { return AudioService.IsPlaying; }
            set
            {
                //leave empty, used to avoid binding errors
            }
        }
        public bool Shuffle
        {
            get { return AudioService.Shuffle; }
            set
            {
                if (AudioService.Shuffle == value)
                    return;

                AudioService.Shuffle = value;
                RaisePropertyChanged("Shuffle");
            }
        }
        public bool Repeat
        {
            get { return AudioService.Repeat; }
            set
            {
                if (AudioService.Repeat == value)
                    return;

                AudioService.Repeat = value;
                RaisePropertyChanged("Repeat");
            }
        }
        public float Volume
        {
            get { return (float)Math.Round(AudioService.Volume * 100.0f); }
            set
            {
                if (AudioService.Volume * 100 == value)
                    return;

                AudioService.Volume = value / 100;
                RaisePropertyChanged("Volume");
            }
        }
        public IList<Audio> CurrentPlaylist
        {
            get { return AudioService.Playlist; }
        }
        public bool EnableStatusBroadcasting
        {
            get { return Settings.Instance.EnableStatusBroadcasting; }
            set
            {
                if (Settings.Instance.EnableStatusBroadcasting == value)
                    return;

                Settings.Instance.EnableStatusBroadcasting = value;
                if (!value)
                {
                    DataService.SetMusicStatus(null);
                    _statusUpdated = false;
                }
                RaisePropertyChanged("EnableStatusBroadcasting");
            }
        }
        public UIMode CurrentUIMode
        {
            get { return _currentUIMode; }
            set { Set(ref _currentUIMode, value); }
        }

        //public bool ShowTrayIcon
        //{
        //    get { return Settings.Instance.EnableTrayIcon; }
        //}

        public WindowState WindowState
        {
            get { return _windowState; }
            set
            {
                if (_windowState == value)
                    return;

                _windowState = value;
                if (value == WindowState.Maximized)
                    Settings.Instance.IsWindowMaximized = true;
                else
                    Settings.Instance.IsWindowMaximized = false;
                RaisePropertyChanged("WindowState");
                RaisePropertyChanged("IsWindowMaximized");
            }
        }
        public bool IsWindowMaximized
        {
            get { return WindowState == WindowState.Maximized; }
        }
        public double WindowLeft
        {
            get
            {
                return Settings.Instance.Left;
            }
            set
            {
                Settings.Instance.Left = value;
            }
        }
        public double WindowTop
        {
            get { return Settings.Instance.Top; }
            set { Settings.Instance.Top = value; }
        }
        public double WindowWidth
        {
            get { return Settings.Instance.Width; }
            set { Settings.Instance.Width = value; }
        }
        public double WindowHeight
        {
            get { return Settings.Instance.Height; }
            set
            {
                Settings.Instance.Height = value;
            }
        }
        public bool CanGoBack
        {
            get
            {
                var frame = Application.Current.MainWindow.GetVisualDescendents().OfType<Frame>().FirstOrDefault();
                if (frame == null)
                    return false;
                return frame.CanGoBack;
            }
        }
        public MainViewModel()
        {
            InitializeCommands();
            InitializeMessageInterception();
        }
        public void Initialize()
        {
            WindowState = Settings.Instance.IsWindowMaximized
                              ? WindowState.Maximized
                              : WindowState.Normal;
        }
        private void InitializeCommands()
        {
            CloseWindowCommand = new RelayCommand(() => Application.Current.MainWindow.Close());

            MinimizeWindowCommand = new RelayCommand(() => WindowState = WindowState.Minimized);

            MaximizeWindowCommand = new RelayCommand(() => WindowState = IsWindowMaximized ? WindowState.Normal : WindowState.Maximized);

            GoToPageCommand = new RelayCommand<string>(page => OnNavigateToPage(new NavigateToPageMessage() { Page = page }));

            PrevAudioCommand = new RelayCommand(AudioService.Prev);

            NextAudioCommand = new RelayCommand(AudioService.SkipNext);

            PlayPauseCommand = new RelayCommand(() =>
            {
                if (IsPlaying)
                    AudioService.Pause();
                else
                    AudioService.Play();
            });

            GoBackCommand = new RelayCommand(() =>
            {
                var frame = Application.Current.MainWindow.GetVisualDescendents().OfType<Frame>().FirstOrDefault(f => f.Name == "RootFrame");
                if (frame == null)
                    return;

                if (frame.CanGoBack)
                    frame.GoBack();

                UpdateCanGoBack();
            });

            RestartCommand = new RelayCommand(() =>
            {
                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            });

            AddRemoveAudioCommand = new RelayCommand<vkApp.Model.VkAudio>(audio =>
            {
                MessageBox.Show("Add/Remove: " + audio);
            });

            //EditAudioCommand = new RelayCommand<vkApp.Model.VkAudio>(audio =>
            //{
            //    var flyout = new FlyoutControl();
            //    flyout.FlyoutContent = new EditAudioView(audio);
            //    flyout.Show();
            //});

            //ShowLyricsCommand = new RelayCommand<vkApp.Model.VkAudio>(audio =>
            //{
            //    var flyout = new FlyoutControl();
            //    flyout.FlyoutContent = new LyricsView(audio);
            //    flyout.Show();
            //});

            CopyInfoCommand = new RelayCommand<Audio>(audio =>
            {
                if (audio == null)
                    return;

                try
                {
                    Clipboard.SetData(DataFormats.UnicodeText, audio.Artist + " - " + audio.Title);
                }
                catch (Exception ex)
                {
                    LoggingService.Log(ex);
                }
            });

            PlayAudioNextCommand = new RelayCommand<Audio>(track =>
            {
                AudioService.PlayNext(track);
            });

            //AddToNowPlayingCommand = new RelayCommand<Audio>(track =>
            //{
            //    NotificationService.Notify(MainResources.NotificationAddedToNowPlaying);
            //    AudioService.Playlist.Add(track);
            //});

            RemoveFromNowPlayingCommand = new RelayCommand<Audio>(track =>
            {
                AudioService.Playlist.Remove(track);
            });

            //ShareAudioCommand = new RelayCommand<VkAudio>(audio =>
            //{
            //    ShowShareBar = true;

            //    //костыль #2
            //    var shareControl = Application.Current.MainWindow.GetVisualDescendent<ShareBarControl>();
            //    if (shareControl == null)
            //        return;

            //    var shareViewModel = ((ShareViewModel)((FrameworkElement)shareControl.Content).DataContext);
            //    shareViewModel.Tracks.Add(audio);
            //});
        }
        private void InitializeMessageInterception()
        {
            MessengerInstance.Register<NavigateToPageMessage>(this, OnNavigateToPage);
            //MessengerInstance.Register<LoginMessage>(this, OnLoginMessage);
            MessengerInstance.Register<CurrentAudioChangedMessage>(this, OnCurrentAudioChanged);
            MessengerInstance.Register<PlayerPositionChangedMessage>(this, OnPlayerPositionChanged);
            MessengerInstance.Register<PlayStateChangedMessage>(this, OnPlayStateChanged);
        }
        private void OnNavigateToPage(NavigateToPageMessage message)
        {
            Type type = Type.GetType("vkApp.View." + message.Page.Substring(1), false);
            if (type == null)
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
                return;
            }

            var frame = Application.Current.MainWindow.GetVisualDescendents().OfType<Frame>().FirstOrDefault();
            if (frame == null)
                return;

            if (typeof(PageBase).IsAssignableFrom(type))
            {
                var page = (PageBase)Activator.CreateInstance(type);
                page.NavigationContext.Parameters = message.Parameters;
                frame.Navigate(page);
            }
            else if (typeof(Page).IsAssignableFrom(type))
            {
                frame.Navigate(Activator.CreateInstance(type));
            }

            UpdateCanGoBack();
        }
        private void OnCurrentAudioChanged(CurrentAudioChangedMessage message)
        {
            RaisePropertyChanged("CurrentAudio");
            RaisePropertyChanged("IsPlaying");
            RaisePropertyChanged("CurrentPlaylist");
            RaisePropertyChanged("WindowTitle");

            _statusUpdated = false;


            if (Settings.Instance.ShowTrackNotifications && message.OldAudio != null) //disable show on first start by checking for null
                ShowTrackNotification(message.NewAudio);
        }
        private void ShowTrackNotification(Audio track)
        {
            if (track == null)
                return;

            //Window w;

            //if (CurrentUIMode == UIMode.Normal)
            //    w = Application.Current.MainWindow;
            //else
            //{
            //    var t = CurrentUIMode == UIMode.CompactLandscape ? typeof(CompactLandscapeView) : typeof(CompactView);
            //    w = CurrentUIMode == UIMode.CompactLandscape
            //        ? (Window)Application.Current.Windows.OfType<CompactLandscapeView>().FirstOrDefault()
            //        : (Window)Application.Current.Windows.OfType<CompactView>().FirstOrDefault();
            //}

            //if (w == null)
            //    return;

            //if (w.IsActive &&
            //    w.WindowState != WindowState.Minimized)
            //    return;

            var notificationView = Application.Current.Windows.OfType<TrackNotifcationView>().FirstOrDefault();
            if (notificationView == null)
            {
                notificationView = new TrackNotifcationView(track);
                notificationView.Show();
            }
            else
            {
                notificationView.Track = track;
            }
        }
        private async void OnPlayerPositionChanged(PlayerPositionChangedMessage message)
        {
            RaisePropertyChanged("CurrentAudioPosition");
            RaisePropertyChanged("CurrentAudioPositionSeconds");
            RaisePropertyChanged("CurrentAudioDuration");


            if (message.NewPosition.TotalSeconds >= 3)
            {
                if (!_statusUpdated)
                {
                    if (Settings.Instance.EnableStatusBroadcasting)
                    {
                        _statusUpdated = true;

                        try
                        {
                            await DataService.SetMusicStatus(CurrentAudio as vkApp.Model.VkAudio);
                        }
                        catch (VkAccessDeniedException ex)
                        {
                            AccountManager.LogOutVk();
                            LoggingService.Log(ex);
                        }
                        catch (VkStatusBroadcastDisabledException ex)
                        {
                            LoggingService.Log(ex);
                        }
                        catch (Exception ex)
                        {
                            LoggingService.Log(ex);
                        }
                    }
                }
            }
        }
        public bool EnableScrobbling
        {
            get { return Settings.Instance.EnableScrobbling; }
            set
            {
                if (Settings.Instance.EnableScrobbling == value)
                    return;

                Settings.Instance.EnableScrobbling = value;
                RaisePropertyChanged("EnableScrobbling");               
            }
        }
        private void OnPlayStateChanged(PlayStateChangedMessage message)
        {
            RaisePropertyChanged("IsPlaying");
        }
        public void UpdateCanGoBack()
        {
            RaisePropertyChanged("CanGoBack");


            var frame = Application.Current.MainWindow.GetVisualDescendents().OfType<Frame>().FirstOrDefault(f => f.Name == "RootFrame");
            if (frame != null && frame.Content != null)
            {
                var source = frame.Content.GetType().Name;
                _canNavigate = false;
                SelectedMainMenuItemIndex = _mainMenuItems.IndexOf(_mainMenuItems.FirstOrDefault(t => t.Page.EndsWith(source)));
                _canNavigate = true;
            }
        }

        //#region OLD
        //public RelayCommand PlayPauseCommand { get; private set; }

        //private CancellationTokenSource _cancellationToken;
        //private readonly Vkontakte _vkontakte;

        //private ObservableCollection<Audio> _tracks;
        //public ObservableCollection<Audio> Tracks
        //{
        //    get { return _tracks; }
        //    set { Set(ref _tracks, value); }
        //}
        //public MainViewModel()
        //{
        //    InitializeCommands();
        //    _cancellationToken = new CancellationTokenSource();
        //    _vkontakte = ViewModelLocator.Vkontakte;
        //}
        //public async Task Login()
        //{
        //    try
        //    {
        //        var token = await _vkontakte.Auth.Login();
        //        //Console.WriteLine("Settings: " + Settings.Instance.AccessToken.UserId);
        //        //Console.WriteLine("Token: " + token.UserId);
        //        //Console.WriteLine("vk: " + _vkontakte.AccessToken.UserId);
        //    }
        //    catch (NullReferenceException)
        //    {
        //        vk_auth auth = new vk_auth();
        //        auth.Show();
        //    }
        //}

        //public async Task LoadTracks()//CancellationToken token)
        //{
        //    try
        //    {
        //        var response = await DataService.GetUserTracks();
        //        if (response.Items != null && response.Items.Count > 0)
        //        {
        //            Tracks = new ObservableCollection<Audio>(response.Items);

        //            if (AudioService.CurrentAudio == null)
        //            {
        //                AudioService.SetCurrentPlaylist(Tracks.ToList());
        //                AudioService.CurrentAudio = Tracks.First();
        //                AudioService.CurrentAudio.IsPlaying = true;
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Tracks = null");
        //            Tracks = null;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Error response");
        //    }
        //}
        //private void CancelAsync()
        //{
        //    if (_cancellationToken != null)
        //        _cancellationToken.Cancel();

        //    _cancellationToken = new CancellationTokenSource();
        //}
        //public bool IsPlaying
        //{
        //    get { return AudioService.IsPlaying; }
        //    set
        //    {
        //        //leave empty, used to avoid binding errors
        //    }
        //}
        //private void InitializeCommands()
        //{
        //    PlayPauseCommand = new RelayCommand(() =>
        //    {
        //        if (IsPlaying)
        //            AudioService.Pause();
        //        else
        //            AudioService.Play();
        //    });
        //}
        //#endregion
        
    }
}