using System.Linq;
using System.Windows;
using System.Windows.Controls;
using vkApp.Controls;
using vkApp.ViewModel.Flyouts;
using vkApp.Neptune.Extensions;
using VkLib.Core.Photo;
using VkLib.Core.Users;
using VkLib.Token;

namespace vkApp.View.Flyouts
{
    public partial class PhotoFlyout : UserControl
    {
        private PhotoFlyoutViewModel _viewModel;

        public PhotoFlyout(VkPhoto selectedPhoto)
        {
            InitializeComponent();

            _viewModel = new PhotoFlyoutViewModel();
            this.DataContext = _viewModel;
            _viewModel.SelectedPhoto = selectedPhoto;
            image.MaxHeight = VkLib.Token.Settings.Instance.Height - 100;
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

        private void image_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
