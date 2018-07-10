using Prism.Navigation;

namespace ListAppFinal.ViewModels
{
    public class MainPageViewModel : VmBase
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Main Page";
        }
    }
}