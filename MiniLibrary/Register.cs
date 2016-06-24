using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
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
        private Button register;
        private Button sendCode;
        private EditText number;
        private EditText code;
        private EditText psw;
        private EditText confirm;
        private LinearLayout regLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);

            register = FindViewById<Button>(Resource.Id.regBtnRegister);
            sendCode = FindViewById<Button>(Resource.Id.regBtnSendcode);
            number = FindViewById<EditText>(Resource.Id.regEditNumber);
            code = FindViewById<EditText>(Resource.Id.regEditCode);
            psw = FindViewById<EditText>(Resource.Id.regEditPassword);
            confirm = FindViewById<EditText>(Resource.Id.regEditConfirm);
            regLayout = FindViewById<LinearLayout>(Resource.Id.regLayout);

            register.Click += delegate
            {
                if ((number.Text == "") || (code.Text == "") || (psw.Text == "") || (confirm.Text == ""))
                {
                    Toast.MakeText(this, "请输入完整的注册信息！", ToastLength.Short).Show();
                }
                else if (number.Text.Length != 11 || !Regex.IsMatch(number.Text, @"^[+-]?\d*$"))
                {
                    Toast.MakeText(this, "手机号码格式不正确", ToastLength.Short).Show();
                }
                else if ((psw.Text != confirm.Text))
                {
                    Toast.MakeText(this, "两次输入的密码不一致！", ToastLength.Short).Show();
                }
                else if (code.Text != "123456")
                {
                    Toast.MakeText(this, "验证码错误！", ToastLength.Short).Show();
                }
                else
                {
                    string res = RegisterData.Post("http://115.159.145.115/Register.php/", number.Text, psw.Text);
                    if (res == "0")
                    {
                        Toast.MakeText(this, "该号码已被注册！", ToastLength.Short).Show();
                    }
                    else if (res == "1")
                    {
                        Intent ActSuccess = new Intent(this, typeof(RegisterSuccess));
                        StartActivity(ActSuccess);
                    }
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

        class RegisterData
        {
            public static string Post(string url, string PhoneNum, string Password)
            {
                string para = "PhoneNum=" + PhoneNum + "&Password=" + Password;
                HttpWebRequest httpWeb = (HttpWebRequest)WebRequest.Create(url);
                httpWeb.Timeout = 20000;
                httpWeb.Method = "POST";
                httpWeb.ContentType = "application/x-www-form-urlencoded";
                byte[] bytePara = Encoding.ASCII.GetBytes(para);
                using (Stream reqStream = httpWeb.GetRequestStream())
                {
                    reqStream.Write(bytePara, 0, para.Length);
                }
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWeb.GetResponse();
                Stream stream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
                string result = streamReader.ReadToEnd();
                stream.Close();

                return result;

            }
        }
    }
}