using Controls.Buttons;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ListAppFinal.Pages;
using ListAppFinal.ViewModels;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ListAppFinal
{
	public partial class App : PrismApplication
	{
	    public App() : this(null) { }

	    public App(IPlatformInitializer initializer) : base(initializer) { }

	    protected override async void OnInitialized()
	    {
	        var t = new ImageButton();

	        InitializeComponent();
        

	        await NavigationService.NavigateAsync("NavigationPage/MainPage");
	    }

	    protected override void RegisterTypes(IContainerRegistry containerRegistry)
	    {
	        containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
	    }

        
	}
}
