using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MiniLibrary
{
    [Activity(Label = "Library", MainLauncher = true, Icon = "@drawable/icon", WindowSoftInputMode = SoftInput.StateHidden|SoftInput.AdjustUnspecified,Theme = "@android:style/Theme.Holo.Light.NoActionBar")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button register = FindViewById<Button>(Resource.Id.mainBtnRegister);
            Button login = FindViewById<Button>(Resource.Id.mainBtnLogin);
            Button forget = FindViewById<Button>(Resource.Id.mainBtnForget);
            EditText number = FindViewById<EditText>(Resource.Id.mainEditNumber);
            EditText psw = FindViewById<EditText>(Resource.Id.mainEditPassword);
            

            register.Click += delegate
            {
                Intent ActRegister = new Intent(this, typeof(Register));
                StartActivity(ActRegister);
            };
            login.Click += delegate
            {
                if (number.Text == "")
                {
                    Toast.MakeText(this, "请输入手机号", ToastLength.Short).Show();
                }
                if (psw.Text == "")
                {
                    Toast.MakeText(this, "请输入密码", ToastLength.Short).Show();
                }

            };
        }
    }
}
