using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using vkApp.Controls;
using vkApp.ViewModel;

namespace vkApp.View.Settings
{
    public partial class SettingsView : PageBase
    {
        private SettingsViewModel _viewModel;
        public SettingsView()
        {
            InitializeComponent();

            _viewModel = new SettingsViewModel();
            this.DataContext = _viewModel;
        }
        private void SettingsView_OnLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Activate();
        }
        public override void OnNavigatedTo()
        {
            ViewModelLocator.Main.ShowSidebar = false;
            ViewModelLocator.Main.ShowTopbar = false;

            var p = NavigationContext.Parameters;
            if (p.ContainsKey("section"))
            {
                if ((string)p["section"] == "accounts")
                {
                    MenuListBox.SelectedItem = _viewModel.MenuItems.First(i => i.Value.EndsWith("SettingsAccountsView.xaml"));
                }
            }
        }
        public override void OnNavigatedFrom()
        {
            ViewModelLocator.Main.ShowSidebar = true;
            ViewModelLocator.Main.ShowTopbar = true;
        }
        private void SettingsFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            SettingsFrame.RemoveBackEntry();

            var content = SettingsFrame.Content as FrameworkElement;
            if (content == null)
                return;

            content.DataContext = _viewModel;
        }
    }
}
