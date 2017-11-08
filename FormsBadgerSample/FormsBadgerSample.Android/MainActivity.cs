using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xam.Plugin.Badger.Abstractions;
using Xam.Plugin.Badger.Droid;
using FormsSample.Shared;
using Xamarin.Forms;
using Plugin.Permissions;

namespace FormsSample.Droid
{
    [Activity(Label = "FormsSample", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);


            DependencyService.Register<IBadgerService, BadgerService>();
            DependencyService.Get<IBadgerService>().SetAndroidContext(this);

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

