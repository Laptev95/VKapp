using System;
using System.Windows.Controls;
using vkApp.ViewModel.Main;


namespace vkApp.View.Main
{
    public partial class PhotosView : Page
    {
        private PhotosViewModel _viewModel;
        public PhotosView()
        {
            InitializeComponent();

            _viewModel = new PhotosViewModel();
            this.DataContext = _viewModel;
        }

        private void PhotosView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewModel.Activate();
        }

        private void photoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (photoList.SelectedIndex == -1)
                return;

            //_viewModel.index = photoList.SelectedIndex;
            _viewModel.gotophoto(photoList.SelectedIndex);

            photoList.SelectedIndex = -1;
        }
    }
}
