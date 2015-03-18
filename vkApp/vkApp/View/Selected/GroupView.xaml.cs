using System.Windows;
using vkApp.Controls;
using vkApp.ViewModel.Selected;
using VkLib.Core.Groups;

namespace vkApp.View.Selected
{
    public partial class GroupView : PageBase
    {
        private GroupViewModel _viewModel;
        public GroupView()
        {
            InitializeComponent();

            _viewModel = new GroupViewModel();
            this.DataContext = _viewModel;
        }
        public override void OnNavigatedTo()
        {
            var society = (VkGroup)NavigationContext.Parameters["group"];
            _viewModel.SelectedGroup = society;

            _viewModel.Activate();
        }
        private void GroupView_OnUnloaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Deactivate();
        }
    }
}
