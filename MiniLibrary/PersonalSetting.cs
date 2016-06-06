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
    [Activity(Label = "PersonalSetting", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class PersonalSetting : Activity
    {
        private LinearLayout DataEdit;
        private LinearLayout PasswordEdit;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PersonalSetting);
            DataEdit = FindViewById<LinearLayout>(Resource.Id.SettingDataEdit);
            PasswordEdit = FindViewById<LinearLayout>(Resource.Id.SettingPasswardEdit);

            DataEdit.Click += delegate
            {
                Intent ActDataEdit = new Intent(this, typeof(DataEdit));
                StartActivity(ActDataEdit);
            };
            PasswordEdit.Click += delegate
            {
                Intent ActPasswordEdit = new Intent(this, typeof(PasswordEdit));
                StartActivity(ActPasswordEdit);
            };
        }
    }
}