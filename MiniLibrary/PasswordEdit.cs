using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
namespace MiniLibrary
{
    [Activity(Label = "PasswordEdit", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class PasswordEdit : Activity
    {
        private EditText code;
        private EditText psw;
        private EditText confirm;
        private Button submit;
        private Button sendCode;
        private LinearLayout layout;
        private AlertDialog.Builder builder;
        private TextView PhoneNum;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PasswardEdit);

            builder = new AlertDialog.Builder(this);
            code = FindViewById<EditText>(Resource.Id.SettingPswEditCode);
            psw = FindViewById<EditText>(Resource.Id.SettingEditPassword);
            confirm = FindViewById<EditText>(Resource.Id.SettingEditConfirm);
            submit = FindViewById<Button>(Resource.Id.SettingbtnSubmitPsw);
            sendCode = FindViewById<Button>(Resource.Id.SettingPswBtnSendcode);
            layout = FindViewById<LinearLayout>(Resource.Id.SettingPswLayout);
            PhoneNum = FindViewById<TextView>(Resource.Id.PasswordTextPhoneNum);

            submit.Click += delegate
            {
                if ((code.Text == "") || (psw.Text == "") || (confirm.Text == ""))
                {
                    Toast.MakeText(this, "请输入完整的修改信息！", ToastLength.Short).Show();
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
                    ISharedPreferences LoginSP = GetSharedPreferences("LoginData", FileCreationMode.Private);
                    PhoneNum.Text = LoginSP.GetString("PhoneNum", null);
                    string res = PasswordEditData.Post("http://115.159.145.115/PasswordEdit.php", psw.Text, PhoneNum.Text);
                    if (res == "Success")
                    {
                        builder.SetTitle("修改成功");
                        builder.SetMessage("请重新登录！");
                        builder.SetPositiveButton("确认", OK);
                        builder.SetCancelable(false);
                        builder.Show();
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
                sendcode = context.FindViewById<Button>(Resource.Id.SettingPswBtnSendcode);
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

        public class PasswordEditData
        {
            public static string Post(string url, string Password, string PhoneNum)
            {
                string para = "Password=" + Password + "&PhoneNum=" + PhoneNum;
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