using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MiniLibrary
{
    [Activity(Label = "Library", MainLauncher = true, Icon = "@drawable/icon", WindowSoftInputMode = SoftInput.StateHidden|SoftInput.AdjustUnspecified,Theme = "@android:style/Theme.Holo.Light.NoActionBar",ScreenOrientation =Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button bt1 = FindViewById<Button>(Resource.Id.btnMain1);
            Button bt2 = FindViewById<Button>(Resource.Id.btnMain2);
            Button bt3 = FindViewById<Button>(Resource.Id.btnMain3);
            Button bt4 = FindViewById<Button>(Resource.Id.btnMain4);

            bt1.Click += delegate
            {
                Intent ActLogin = new Intent(this, typeof(Login));
                StartActivity(ActLogin);
            };
            bt2.Click += delegate
            {
                Intent ActLogin = new Intent(this, typeof(BookDetails));
                StartActivity(ActLogin);
            };
            bt3.Click += delegate
            {
                Intent ActLogin = new Intent(this, typeof(FirstAdmin));
                StartActivity(ActLogin);
            };
            bt4.Click += delegate
            {
                Intent ActLogin = new Intent(this, typeof(SecondAdmin));
                StartActivity(ActLogin);
            };
        }
    }
}
