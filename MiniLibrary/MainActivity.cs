using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace MiniLibrary
{
    [Activity(Label = "MiniLibrary", MainLauncher = true, Icon = "@drawable/icon", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar.Fullscreen", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            ImageView start = FindViewById<ImageView>(Resource.Id.Start);
            start.SetImageResource(Resource.Drawable.Start);

            start.Click += Start_Click;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Intent ActLogin = new Intent(this, typeof(Login));
            Finish();
            StartActivity(ActLogin);
        }
    }
}
