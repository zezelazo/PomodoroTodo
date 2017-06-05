using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PomodoroTodo.Droid
{
  [Activity(Label = "PomodoroTodo", Icon = "@drawable/icon", Theme = "@android:style/Theme.Holo.Light", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
  {
    protected override void OnCreate(Bundle bundle)
    {
      //TabLayoutResource = Resource.Layout.Tabbar;
      //ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(bundle);
      Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

      UserDialogs.Init(this);

      global::Xamarin.Forms.Forms.Init(this, bundle);

      LoadApplication(new App());
    }
  }
}

