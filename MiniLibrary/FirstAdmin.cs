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

using Android.Support.V4.App;
using Android.Content.PM;

namespace MiniLibrary
{
    [Activity(Label = "FirstAdmin", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class FirstAdmin : FragmentActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FirstADmin);

            Button setup = FindViewById<Button>(Resource.Id.SetUpB);
            Button BorrowB = FindViewById<Button>(Resource.Id.textViewBorrowB);
            Button returnB = FindViewById<Button>(Resource.Id.textViewReturnB);
            Button renew = FindViewById<Button>(Resource.Id.renewBook);
            Button rinfoq = FindViewById<Button>(Resource.Id.ReaderInformationQuery);
            Button mpinfo = FindViewById<Button>(Resource.Id.Modifypersonalinfo);
            setup.Click += delegate
            {
                Intent ActRegister = new Intent(this, typeof(FirstSetUp));
                StartActivity(ActRegister);
            };
            rinfoq.Click += delegate
            {
                Intent ActRegister = new Intent(this, typeof(FirstReaderInfoQ));
                StartActivity(ActRegister);
            };
            mpinfo.Click += delegate
            {
                Intent ActRegister = new Intent(this, typeof(PersonalSetting));
                StartActivity(ActRegister);
            };
            renew.Click += delegate
            {
                Intent ActRegister = new Intent(this, typeof(FirstRenew));
                StartActivity(ActRegister);
            };
            //SupportFragmentManager
            // .BeginTransaction()
            // .Replace(Resource.Id.content_frame, new HomeFragment())
            // .CommitAllowingStateLoss();
        }
    }
}