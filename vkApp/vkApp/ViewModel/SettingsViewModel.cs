using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using vkApp.Services;
using VkLib.Token;

namespace vkApp.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly Dictionary<string, string> _menuItems = new Dictionary<string, string>()
        {
            //{MainResources.SettingsMenuUI, "/View/Settings/SettingsUIView.xaml"},
            //{MainResources.SettingsMenuHotkeys, "/View/Settings/SettingsHotkeysView.xaml"},
            {"Аккаунт", "/View/Settings/SettingsAccountsView.xaml"},
            //{MainResources.SettingsMenuUpdates, "/View/Settings/SettingsUpdatesView.xaml"},
            //{MainResources.SettingsMenuAbout, "/View/Settings/SettingsAboutView.xaml"}
        };

        private bool _restartRequired;
        private bool _canSave;
        private bool _enableNotifications;

        #region Commands

        public RelayCommand CloseSettingsCommand { get; private set; }

        public RelayCommand SaveCommand { get; private set; }

        public RelayCommand SaveRestartCommand { get; private set; }

        public RelayCommand SignOutVkCommand { get; private set; }

        public RelayCommand LoginLastFmCommand { get; private set; }

        public RelayCommand SignOutLastFmCommand { get; private set; }

        public RelayCommand CheckUpdatesCommand { get; private set; }

        public RelayCommand ClearCacheCommand { get; private set; }

        public RelayCommand TellCommand { get; private set; }

        #endregion
        public Dictionary<string, string> MenuItems
        {
            get { return _menuItems; }
        }
        public bool RestartRequired
        {
            get { return _restartRequired; }
            set { Set(ref _restartRequired, value); }
        }

        public bool CanSave
        {
            get { return _canSave; }
            set { Set(ref _canSave, value); }
        }
        public bool EnableNotifications
        {
            get { return _enableNotifications; }
            set
            {
                if (Set(ref _enableNotifications, value))
                    CanSave = true;
            }
        }
        public SettingsViewModel()
        {
            InitializeCommands();

            _enableNotifications = Settings.Instance.ShowTrackNotifications;
        }
        public async void Activate()
        {
            //check cache
            //if (Directory.Exists("Cache"))
            //{
            //    var cacheSize = await CalculateFolderSizeAsync("Cache");
            //    CacheSize = StringHelper.FormatSize(Math.Round(cacheSize, 1));
            //}
        }
        private void InitializeCommands()
        {
            CloseSettingsCommand = new RelayCommand(() =>
            {
                ViewModelLocator.Main.ShowSidebar = true;
                ViewModelLocator.Main.ShowTopbar = true;
                ViewModelLocator.Main.GoBackCommand.Execute(null);
            });

            SaveCommand = new RelayCommand(SaveSettings);

            SaveRestartCommand = new RelayCommand(() =>
            {
                SaveSettings();

                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            });

            SignOutVkCommand = new RelayCommand(AccountManager.LogOutVk);
        }
        private void SaveSettings()
        {
            Settings.Instance.ShowTrackNotifications = EnableNotifications;

            Settings.Instance.Save();

            CloseSettingsCommand.Execute(null);
        }
    }
}