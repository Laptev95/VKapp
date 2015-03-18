using System;
using System.Windows.Controls;
using vkApp.ViewModel;
using vkApp.ViewModel.Main;
namespace vkApp.View.Main
{
    public partial class ProfileView : Page
    {
        private ProfileViewModel _viewModel;
        public ProfileView()
        {
            InitializeComponent();

            _viewModel = new ProfileViewModel();
            this.DataContext = _viewModel;
        }

        private async void ProfileView_OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await _viewModel.LoadUserInfo();
            ViewModelLocator.Main.Profile = _viewModel.Profile;
        }
        private void ProfileView_OnUnloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewModel.Deactivate();
        }
    }
}
