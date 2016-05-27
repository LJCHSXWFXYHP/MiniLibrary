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
    [Activity(Label = "Register", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar",ScreenOrientation =Android.Content.PM.ScreenOrientation.Portrait)]
    public class Register : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);

            Button register = FindViewById<Button>(Resource.Id.regBtnRegister);
            Button sendCode = FindViewById<Button>(Resource.Id.regBtnSendcode);
            EditText number = FindViewById<EditText>(Resource.Id.regEditNumber);
            EditText code = FindViewById<EditText>(Resource.Id.regEditCode);
            EditText psw = FindViewById<EditText>(Resource.Id.regEditPassword);
            EditText confirm = FindViewById<EditText>(Resource.Id.regEditConfirm);
            LinearLayout regLayout = FindViewById<LinearLayout>(Resource.Id.regLayout);

            register.Click += delegate
            {
                if ((number.Text == "") || (code.Text == "") || (psw.Text == "") || (confirm.Text == ""))
                {
                    Toast.MakeText(this, "请输入完整的注册信息！", ToastLength.Short).Show();
                }
                else
                {
                    Intent ActRegsuccess = new Intent(this, typeof(RegisterSuccess));
                    StartActivity(ActRegsuccess);
                }

            };
            sendCode.Click += delegate
            {
                MyCount mc = new MyCount(this,60000, 1000);
                mc.Start();
                
            };
            regLayout.Click += delegate
            {
                Android.Views.InputMethods.InputMethodManager imm = (Android.Views.InputMethods.InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(number.WindowToken, 0);
                imm.HideSoftInputFromWindow(code.WindowToken, 0);
                imm.HideSoftInputFromWindow(psw.WindowToken, 0);
                imm.HideSoftInputFromWindow(confirm.WindowToken, 0);
            };
            
        }
        public class MyCount : CountDownTimer
        {

            Button sendcode;
            private Activity context = null;
            public MyCount(Activity acticity, long millisInFuture, long countDownInterval) : base(millisInFuture, countDownInterval)
            {
                this.context = acticity;
                sendcode = context.FindViewById<Button>(Resource.Id.regBtnSendcode);
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