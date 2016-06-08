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

namespace MiniLibrary
{
    [Activity(Label = "Library", Icon = "@drawable/icon", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class SecondAdmin : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.BookManage);

            ImageButton imb = FindViewById<ImageButton>(Resource.Id.imageButton1);
            imb.Click += delegate
            {
                Intent ActLogin = new Intent(this, typeof(EditBook));
                StartActivity(ActLogin);
            };

            Button imb2 = FindViewById<Button>(Resource.Id.button2);
            imb2.Click += delegate
            {
                Intent ActLogin = new Intent(this, typeof(EditBook));
                StartActivity(ActLogin);
            };

        }
    }
}