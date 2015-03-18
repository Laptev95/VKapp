using System.Windows;
using GalaSoft.MvvmLight.Threading;
using vkApp.Services.Media;
using Yandex.Metrica;
using VkLib.Token;
using vkApp.Services;
using System.Reflection;
using System;

namespace vkApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            //LoggingService.Log("Meridian v" + Assembly.GetExecutingAssembly().GetName().Version + " started. OS: " + Environment.OSVersion);

            DispatcherHelper.Initialize();

            Settings.Load();

            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            //AudioService.Load();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            //RemoveTrayIcon();

            AudioService.Save();
            AudioService.Dispose();

        }
        //public void AddTrayIcon()
        //{
        //    if (_trayIcon != null)
        //    {
        //        return;
        //    }

        //    _trayIcon = new NotifyIcon
        //    {
        //        Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location),
        //        Text = "Meridian " + Assembly.GetExecutingAssembly().GetName().Version.ToString(2)
        //    };
        //    _trayIcon.MouseClick += TrayIconOnMouseClick;
        //    _trayIcon.Visible = true;

        //    _trayIcon.ContextMenu = new ContextMenu();
        //    var closeItem = new System.Windows.Forms.MenuItem();
        //    closeItem.Text = MainResources.Close;
        //    closeItem.Click += (s, e) =>
        //    {
        //        foreach (Window window in Windows)
        //        {
        //            window.Close();
        //        }
        //    };
        //    _trayIcon.ContextMenu.MenuItems.Add(closeItem);
        //}
    }
}
