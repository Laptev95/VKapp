using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using vkApp.Behaviours;
using vkApp.Model;
using vkApp.Services.Media;
using vkApp.ViewModel;
using vkApp.ViewModel.Main;

namespace vkApp.View.Main
{
    /// <summary>
    /// Interaction logic for MusicView.xaml
    /// </summary>
    public partial class MusicView : Page
    {
        private MusicViewModel _viewModel;
        
        public MusicView()
        {
            InitializeComponent();

            _viewModel = new MusicViewModel();
            this.DataContext = _viewModel;
        }
        private async void MusicView_OnLoaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.Activate();

           
            //LocalSearchBox.Filter = Filter;
        }
        private void MusicView_OnUnloaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Deactivate();
        }

        //private bool Filter(object o)
        //{
        //    var track = (Audio)o;
        //    var query = LocalSearchBox.Query.ToLower();
        //    return track.Title.ToLower().Contains(query) || track.Artist.ToLower().Contains(query);
        //}
    }
}
