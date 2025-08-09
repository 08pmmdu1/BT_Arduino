using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;

namespace BTArduino
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            //InTheHand.AndroidActivity.CurrentActivity = Platform.CurrentActivity;
            base.OnCreate(savedInstanceState);
            InTheHand.AndroidActivity.CurrentActivity = this;
            RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.BluetoothAdmin, Manifest.Permission.BluetoothConnect, Manifest.Permission.BluetoothScan }, 1);
        }
    }

}
