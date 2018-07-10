using System.Reflection;
using Android.App;
using Android.Content.PM;
using Android.OS;
using ListAppFinal.Droid.ImageLoadingExtentions;
using Prism;
using Prism.Ioc;
using Debug = System.Diagnostics.Debug;

namespace ListAppFinal.Droid
{
    [Activity(Label = "ListAppFinal", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            LoadEmbeddedResourceExtension.Init(Assembly.GetAssembly(typeof(App)));

            global::Xamarin.Forms.Forms.Init(this, bundle);

            try
            {
                LoadApplication(new App(new AndroidInitializer()));
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
            
        }
    }
}

