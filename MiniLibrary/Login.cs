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
    [Activity(Label = "Login",WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Login : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);
            Button register = FindViewById<Button>(Resource.Id.logBtnRegister);
            Button login = FindViewById<Button>(Resource.Id.logBtnLogin);
            Button forget = FindViewById<Button>(Resource.Id.logBtnForget);
            EditText number = FindViewById<EditText>(Resource.Id.logEditNumber);
            EditText psw = FindViewById<EditText>(Resource.Id.logEditPassword);
            LinearLayout mainLayout = FindViewById<LinearLayout>(Resource.Id.logLayout);

            register.Click += delegate
            {
                Intent ActRegister = new Intent(this, typeof(Register));
                StartActivity(ActRegister);
            };
            login.Click += delegate
            {
                if (number.Text == "")
                {
                    Toast.MakeText(this, "«Î ‰»Î ÷ª˙∫≈", ToastLength.Short).Show();
                }
                if (psw.Text == "")
                {
                    Toast.MakeText(this, "«Î ‰»Î√‹¬Î", ToastLength.Short).Show();
                }

            };
            mainLayout.Click += delegate
            {
                Android.Views.InputMethods.InputMethodManager imm = (Android.Views.InputMethods.InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(number.WindowToken, 0);
                imm.HideSoftInputFromWindow(psw.WindowToken, 0);
            };
        }
    }
}