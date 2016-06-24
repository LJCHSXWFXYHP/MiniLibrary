using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
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
        private TextView PhoneNum;
        private AlertDialog.Builder builder;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.DataEdit);

            builder = new AlertDialog.Builder(this);
            number = FindViewById<EditText>(Resource.Id.SettingEditNumber);
            code = FindViewById<EditText>(Resource.Id.SettingNumberEditCode);
            sendCode = FindViewById<Button>(Resource.Id.SettingNumberBtnSendcode);
            submit = FindViewById<Button>(Resource.Id.SettingbtnSubmitNumber);
            layout = FindViewById<LinearLayout>(Resource.Id.SettingNumberLayout);
            PhoneNum = FindViewById<TextView>(Resource.Id.DataEditTextPhoneNum);

            ISharedPreferences LoginSP = GetSharedPreferences("LoginData", FileCreationMode.Private);
            PhoneNum.Text = LoginSP.GetString("PhoneNum", null);

            submit.Click += delegate
            {
                if ((code.Text == "") || (number.Text == ""))
                {
                    Toast.MakeText(this, "请输入完整的修改信息！", ToastLength.Short).Show();
                }
                else if (number.Text.Length != 11 || !Regex.IsMatch(number.Text, @"^[+-]?\d*$"))
                {
                    Toast.MakeText(this, "手机号码格式不正确", ToastLength.Short).Show();
                }
                else if (code.Text != "123456")
                {
                    Toast.MakeText(this, "验证码错误！", ToastLength.Short).Show();
                }
                else
                {
                    string res = DataEditData.Post("http://115.159.145.115/DataEdit.php", number.Text,PhoneNum.Text);
                    if (res == "Success")
                    {
                        builder.SetTitle("修改成功");
                        builder.SetMessage("请重新登录！");
                        builder.SetPositiveButton("确认", OK);
                        builder.SetCancelable(false);
                        builder.Show();
                    }
                    else if(res=="Failed")
                    {
                        Toast.MakeText(this, "手机号已被注册！", ToastLength.Short).Show();
                    }
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

        public class DataEditData
        {
            public static string Post(string url, string PhoneNum, string OldPhoneNum)
            {
                string para = "PhoneNum=" + PhoneNum + "&OldPhoneNum=" + OldPhoneNum;
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

        private void OK(object sender, EventArgs e)
        {
            Intent ActLogin = new Intent(this, typeof(Login));
            StartActivity(ActLogin);
        }
    }
}