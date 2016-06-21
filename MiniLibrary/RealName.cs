using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    [Activity(Label = "RealName", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class RealName : Activity
    {
        EditText name;
        EditText id;
        Button submit;
        TextView PhoneNum;
        AlertDialog.Builder builder;
        private string result;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RealName);

            builder = new AlertDialog.Builder(this);
            name = FindViewById<EditText>(Resource.Id.RealNameEditName);
            id = FindViewById<EditText>(Resource.Id.RealNameEditID);
            submit = FindViewById<Button>(Resource.Id.RealNamebtnSubmit);
            PhoneNum = FindViewById<TextView>(Resource.Id.RealNameTextPhoneNum);

            ISharedPreferences LoginSP = GetSharedPreferences("LoginData", FileCreationMode.Private);
            PhoneNum.Text = LoginSP.GetString("PhoneNum", null);
            submit.Click += Submit_Click;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (id.Text.Length != 18 || !Regex.IsMatch(id.Text, @"^[+-]?\d*$"))
            {
                Toast.MakeText(this, "请输入正确的身份证号码！", ToastLength.Short).Show();
            }
            else if(id.Text==""||name.Text=="")
            {
                Toast.MakeText(this, "信息不允许为空！", ToastLength.Short).Show();
            }
            else
            {
                byte[] bytes = Encoding.UTF8.GetBytes(name.Text);
                string NameStr = Encoding.UTF8.GetString(bytes);
                result = RealNameData.Post("http://115.159.145.115/RealName.php/", NameStr, id.Text, PhoneNum.Text);
                builder.SetTitle("提示");
                builder.SetMessage("实名认证信息一旦提交之后不可修改！");
                builder.SetPositiveButton("确认", OK);
                builder.SetNegativeButton("取消", delegate { });
                builder.SetCancelable(true);
                builder.Show();
            }
        }
        private void OK(object sender,EventArgs e)
        {
            if (result == "Success")
            {
                Intent ActSuccess = new Intent(this, typeof(RealNameSuccess));
                StartActivity(ActSuccess);
            }
            else
            {
                Toast.MakeText(this, "认证失败", ToastLength.Short).Show();
            }
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {

            if (keyCode == Keycode.Back)
            {
                Intent ActSetting = new Intent(this, typeof(PersonalSetting));
                StartActivity(ActSetting);
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }

        public class RealNameData
        {
            public static string Post(string url, string Name, string ID, string PhoneNum)
            {
                string para = "Name=" + Name + "&ID=" + ID +"&PhoneNum="+PhoneNum;
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