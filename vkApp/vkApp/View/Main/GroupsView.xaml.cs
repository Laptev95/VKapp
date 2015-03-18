using System.Windows;
using System.Windows.Controls;
using vkApp.ViewModel.Main;

namespace vkApp.View.Main
{
    public partial class GroupsView : Page
    {
        private GroupsViewModel _viewModel;
        public GroupsView()
        {
            InitializeComponent();

            _viewModel = new GroupsViewModel();
            this.DataContext = _viewModel;
        }

        private void GroupsView_OnLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Activate();
        }
    }
}
