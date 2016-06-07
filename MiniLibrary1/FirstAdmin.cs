using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Content.PM;
using Android.Support.V4.App;

namespace MiniLibrary
{
    [Activity(Label = "FirstAdmin", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class FirstAdmin : Activity
    {
            protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.FirstAdmin);
            // Get our button from the layout resource,
            // and attach an event to it
            Button bt1 = FindViewById<Button>(Resource.Id.textViewBorrowB);
            SupportFragmentManager
                 .BeginTransaction()
                 .Replace(Resource.Id.FirstADcont_frame, new HomeFragment())
                 .CommitAllowingStateLoss();


        }
    }
}