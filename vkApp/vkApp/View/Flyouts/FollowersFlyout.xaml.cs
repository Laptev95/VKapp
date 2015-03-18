using System.Linq;
using System.Windows;
using System.Windows.Controls;
using vkApp.Controls;
using vkApp.ViewModel.Flyouts;
using vkApp.Neptune.Extensions;
using VkLib.Core.Users;

namespace vkApp.View.Flyouts
{
    public partial class FollowersFlyout : UserControl
    {
        private FollowersFlyoutViewModel _viewModel;
        public FollowersFlyout(VkProfile selected)
        {
            InitializeComponent();

            _viewModel = new FollowersFlyoutViewModel();
            this.DataContext = _viewModel;
            _viewModel.SelectedUser = selected;
        }
        public static void Close(bool now = false)
        {
            var flyout = Application.Current.MainWindow.GetVisualDescendents().FirstOrDefault(c => c is FlyoutControl) as FlyoutControl;
            if (flyout != null)
            {
                if (now)
                    flyout.CloseNow();
                else
                    flyout.Close();
            }
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
