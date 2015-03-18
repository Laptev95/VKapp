using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using vkApp.Helpers;
using vkApp.Neptune.Messages;
using vkApp.Services.Media;
using vkApp.View.Main;
using vkApp.ViewModel;
using vkApp.ViewModel.Main;
using VkLib;
using VkLib.Core.Users;
using VkLib.Token;

namespace vkApp
{
    public partial class MainWindow : Window
    {
        private IntPtr _windowHandle;
        private bool _clearStack;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.GetPosition(this).Y < 30)
            {
                if (WindowState == WindowState.Maximized)
                {
                    Top = -e.GetPosition(this).Y / 2;
                    WindowState = WindowState.Normal;
                }
                else
                {
                    DragMove();


                    ViewModelLocator.Main.WindowLeft = Left;
                    ViewModelLocator.Main.WindowTop = Top;
                }
            }
        }
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _windowHandle = new WindowInteropHelper(Application.Current.MainWindow).Handle;

            RootFrame.Navigated += RootFrame_Navigated;
            RootFrame.Navigating += RootFrame_Navigating;

            Top = Settings.Instance.Top;
            Left = Settings.Instance.Left;
            Width = Settings.Instance.Width;
            Height = Settings.Instance.Height;
            
            if (Settings.Instance.AccessToken != null && !Settings.Instance.AccessToken.HasExpired)
            {
                ViewModelLocator.Vkontakte.AccessToken = Settings.Instance.AccessToken;
                ViewModelLocator.Main.ShowSidebar = true;
                ViewModelLocator.Main.ShowTopbar = true;

                Messenger.Default.Send(new NavigateToPageMessage()
                {
                    Page = "/Main.ProfileView"
                });

                //Console.WriteLine(Profile.FirstName);
                //if (!Settings.Instance.TellRequestShown && (DateTime.Now - Settings.Instance.FirstStart).TotalDays >= 3)
                //{
                //    Settings.Instance.TellRequestShown = true;
                //    Settings.Instance.Save();
                //    TellFriendsRequest();
                //}
            }
            else
            {
                Messenger.Default.Send(new NavigateToPageMessage()
                {
                    Page = "/Main.LoginView"
                });
            }

            ViewModelLocator.Main.Initialize();
            //NotificationService.Initialize(NotificationControl);

            //BackgroundArtControl.Effect = Settings.Instance.BlurBackground ? new BlurEffect() { RenderingBias = RenderingBias.Quality, Radius = 35 } : null;
        }
        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            Settings.Instance.Save();
        }

        void RootFrame_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (RootFrame.Content is LoginView)
            {
                _clearStack = true;
            }
        }

        void RootFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (_clearStack)
            {
                _clearStack = false;

                while (RootFrame.CanGoBack)
                {
                    RootFrame.RemoveBackEntry();
                }
            }

            ViewModelLocator.Main.UpdateCanGoBack();
        }
        private void ResizeGripMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                NativeMethods.SizeWindow(_windowHandle);
                ViewModelLocator.Main.WindowWidth = Width;
                ViewModelLocator.Main.WindowHeight = Height;
            }
        }  
    }
}