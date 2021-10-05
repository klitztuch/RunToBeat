using Android.App;
using Android.Content.PM;
using Android.OS;

namespace RunToBeat.Android
{
    [Activity(Label = "RunToBeat", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            XF.Material.Droid.Material.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}