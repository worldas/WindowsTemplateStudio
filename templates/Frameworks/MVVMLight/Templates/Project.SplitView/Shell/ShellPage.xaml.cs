using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using uct.ItemName.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace uct.ItemName.Shell
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShellPage : Page
    {
        public ShellPage()
        {
            this.InitializeComponent();
            NavigationService.SetNavigationFrame(frame);
        }

        ShellViewModel ViewModel => DataContext as ShellViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.InitializeNavigationItems(e.Parameter);
        }
    }
}
