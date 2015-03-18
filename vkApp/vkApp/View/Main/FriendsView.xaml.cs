using System.Windows;
using System.Windows.Controls;
using vkApp.ViewModel.Main;

namespace vkApp.View.Main
{
    public partial class FriendsView : Page
    {
        private FriendsViewModel _viewModel;
        public FriendsView()
        {
            InitializeComponent();

            _viewModel = new FriendsViewModel();
            this.DataContext = _viewModel;
        }

        private void FriendsView_OnLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Activate();
        }
    }
}
