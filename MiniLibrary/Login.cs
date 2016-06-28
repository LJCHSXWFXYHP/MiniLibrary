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
using Newtonsoft.Json;
using System.Net;
using System.IO;
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
            ImageView title = FindViewById<ImageView>(Resource.Id.Title);

            title.SetImageResource(Resource.Drawable.Cover);

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
                else if (psw.Text == "")
                {
                    Toast.MakeText(this, "«Î ‰»Î√‹¬Î", ToastLength.Short).Show();
                }
                else
                {
                    string res;
                    
                    res = LoginData.Post("http://115.159.145.115/Login.php/", number.Text, psw.Text);
                    
                    if (res == "1")
                    {
                        Intent ActIndex = new Intent(this, typeof(Index));
                        ISharedPreferences LoginSP = GetSharedPreferences("LoginData", FileCreationMode.Private);
                        ISharedPreferencesEditor editor = LoginSP.Edit();
                        editor.Clear();
                        editor.PutString("PhoneNum", number.Text);
                        editor.PutString("RealName", RealNameCheckData.Post("http://115.159.145.115/RealNameCheck.php", number.Text));
                        editor.Commit();
                        StartActivity(ActIndex);
                        

                    }
                    else if (res == "2")
                    {
                        Intent Actadm = new Intent(this, typeof(Admin));
                        ISharedPreferences LoginSP = GetSharedPreferences("LoginData", FileCreationMode.Private);
                        ISharedPreferencesEditor editor = LoginSP.Edit();
                        editor.Clear();
                        editor.PutString("PhoneNum", number.Text);
                        editor.Commit();
                        StartActivity(Actadm);
                    }
                    else
                    {
                        Toast.MakeText(this, "’À∫≈ªÚ√‹¬Î¥ÌŒÛ£°", ToastLength.Short).Show();
                    }
                }

            };
            mainLayout.Click += delegate
            {
                Android.Views.InputMethods.InputMethodManager imm = (Android.Views.InputMethods.InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(number.WindowToken, 0);
                imm.HideSoftInputFromWindow(psw.WindowToken, 0);
            };
        }
        class LoginData
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
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {

            if (keyCode == Keycode.Back)
            {
                return true;
            }
            return false;
        }
        public class RealNameCheckData
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
    }
    
}