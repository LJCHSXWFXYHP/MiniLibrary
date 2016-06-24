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
    [Activity(Label = "FirstReaderInfoQ", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class FirstReaderInfoQ : Activity
    {
        private ImageView imagef;
        private EditText number;
        private ImageView images;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.FirstReaderInfoQ);

            //imagef = FindViewById<ImageView>(Resource.Id.backimage);
            number = FindViewById<EditText>(Resource.Id.inputnumber);
            //images = FindViewById<ImageView>(Resource.Id.searchimage);
            imagef.Click += delegate
            {
                Intent ActRegister = new Intent(this, typeof(FirstAdmin));
                StartActivity(ActRegister);
            };
        }
    }
}