using System.Windows;
using System.Windows.Controls.Primitives;
using vkApp.Controls;
using vkApp.Model;
using vkApp.ViewModel;
using vkApp.ViewModel.Selected;
using VkLib.Core.Users;

namespace vkApp.View.Selected
{
    public partial class UserView : PageBase
    {
        private UserViewModel _viewModel;
        public UserView()
        {
            InitializeComponent();

            _viewModel = new UserViewModel();
            this.DataContext = _viewModel;
        }

        public override void OnNavigatedTo()
        {
            var user = (VkProfile)NavigationContext.Parameters["user"];
            _viewModel.SelectedUser = user;

            _viewModel.Activate();
        }
    }
}
