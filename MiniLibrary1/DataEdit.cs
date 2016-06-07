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
    [Activity(Label = "DataEdit", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class DataEdit : Activity
    {
        private EditText number;
        private EditText code;
        private Button sendCode;
        private Button submit;
        private LinearLayout layout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.DataEdit);

            number = FindViewById<EditText>(Resource.Id.SettingEditNumber);
            code = FindViewById<EditText>(Resource.Id.SettingNumberEditCode);
            sendCode = FindViewById<Button>(Resource.Id.SettingNumberBtnSendcode);
            submit = FindViewById<Button>(Resource.Id.SettingbtnSubmitNumber);
            layout = FindViewById<LinearLayout>(Resource.Id.SettingNumberLayout);

            submit.Click += delegate
            {
                if ((code.Text == "") || (number.Text == ""))
                {
                    Toast.MakeText(this, "请输入完整的修改信息！", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "修改成功！", ToastLength.Short).Show();
                }
            };
            sendCode.Click += delegate
            {
                MyCount mc = new MyCount(this, 60000, 1000);
                mc.Start();

            };
            layout.Click += delegate
            {
                Android.Views.InputMethods.InputMethodManager imm = (Android.Views.InputMethods.InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(code.WindowToken, 0);
                imm.HideSoftInputFromWindow(number.WindowToken, 0);
            };

        }
        public class MyCount : CountDownTimer
        {

            Button sendcode;
            private Activity context = null;
            public MyCount(Activity acticity, long millisInFuture, long countDownInterval) : base(millisInFuture, countDownInterval)
            {
                this.context = acticity;
                sendcode = context.FindViewById<Button>(Resource.Id.SettingNumberBtnSendcode);
            }
            public override void OnTick(long millisUntilFinished)
            {

                sendcode.Clickable = false;
                DateTime date = new DateTime(millisUntilFinished);
                string str = date.ToString();
                Console.WriteLine(str);
                sendcode.Text = string.Format("" + millisUntilFinished / 1000 + "");

            }
            public override void OnFinish()
            {
                sendcode.Clickable = true;
                sendcode.Text = string.Format("重新发送");
            }

        }
    }
}