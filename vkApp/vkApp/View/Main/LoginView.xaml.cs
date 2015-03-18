using vkApp.Controls;
using vkApp.ViewModel;
using vkApp.ViewModel.Main;

namespace vkApp.View.Main
{
    public partial class LoginView : PageBase
    {
        private readonly LoginViewModel _viewModel;
        public LoginView()
        {
            InitializeComponent();

            _viewModel = new LoginViewModel();
            this.DataContext = _viewModel;
        }
        public override void OnNavigatedTo()
        {
            ViewModelLocator.Main.ShowSidebar = false;
            ViewModelLocator.Main.ShowTopbar = false;
        }
    }
}
