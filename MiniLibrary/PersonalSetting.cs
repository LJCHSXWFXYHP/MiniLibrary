using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
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
        private LinearLayout RealNameEdit;
        private TextView PhoneNum;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PersonalSetting);
            DataEdit = FindViewById<LinearLayout>(Resource.Id.SettingDataEdit);
            PasswordEdit = FindViewById<LinearLayout>(Resource.Id.SettingPasswardEdit);
            RealNameEdit = FindViewById<LinearLayout>(Resource.Id.SettingRealNameEdit);
            PhoneNum = FindViewById<TextView>(Resource.Id.PersonalSettingTextPhoneNum);

            ISharedPreferences LoginSP = GetSharedPreferences("LoginData", FileCreationMode.Private);
            PhoneNum.Text = LoginSP.GetString("PhoneNum", null);

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
            RealNameEdit.Click += delegate
            {
                string res=RealNameData.Post("http://115.159.145.115/IfRealName.php", PhoneNum.Text);
                if (res == "Failed")
                {
                    Toast.MakeText(this, "已认证，快去借书吧！", ToastLength.Short).Show();
                }
                else
                {
                    Intent ActRealName = new Intent(this, typeof(RealName));
                    StartActivity(ActRealName);
                }
            };
        }

        public class RealNameData
        {
            public static string Post(string url, string PhoneNum)
            {
                string postString = "PhoneNum=" + PhoneNum;
                byte[] postData = Encoding.UTF8.GetBytes(postString);
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] responseData = webClient.UploadData(url, "POST", postData);
                string srcString = Encoding.UTF8.GetString(responseData);

                return srcString;

            }
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {

            if (keyCode == Keycode.Back)
            {
                Finish();
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
    }
}