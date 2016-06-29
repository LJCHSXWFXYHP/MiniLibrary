using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ZXing.Mobile;
using Newtonsoft.Json;


namespace MiniLibrary
{
    [Activity(Label = "Admin", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Admin : Activity
    {
        private class BookInfo
        {
            public string BookId { get; set; }
            public string PhoneNum { get; set; }
        }

        private ImageView More;
        private TextView PhoneNum;
        private LinearLayout BorrowScan;
        private LinearLayout ReturnScan;
        private LinearLayout BookList;
        private LinearLayout Search;
        private MobileBarcodeScanner scanner;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Admin);
            More = FindViewById<ImageView>(Resource.Id.AdminMore);
            PhoneNum = FindViewById<TextView>(Resource.Id.AdminPhoneNum);
            BorrowScan = FindViewById<LinearLayout>(Resource.Id.AdminBorrow);
            ReturnScan = FindViewById<LinearLayout>(Resource.Id.AdminReturn);
            BookList = FindViewById<LinearLayout>(Resource.Id.AdminSearch);
            Search = FindViewById<LinearLayout>(Resource.Id.AdminSearch);
            
            More = FindViewById<ImageView>(Resource.Id.AdminMore);
            More.SetImageResource(Resource.Drawable.IconMore);
            More.Click += delegate
            {
                PopupMenu menu = new PopupMenu(this, More);
                menu.Inflate(Resource.Menu.MoreMenu);
                menu.Show();
                menu.MenuItemClick += Menu_MenuItemClick;

            };

            ISharedPreferences LoginSP = GetSharedPreferences("LoginData", FileCreationMode.Private);
            PhoneNum.Text = LoginSP.GetString("PhoneNum", "");

            MobileBarcodeScanner.Initialize(Application);
            Button flashButton;
            TextView ScanText;
            View zxingOverlay;
            scanner = new MobileBarcodeScanner();
            BorrowScan.Click += async delegate {
                
                scanner.UseCustomOverlay = true;

                //Inflate our custom overlay from a resource layout
                zxingOverlay = LayoutInflater.FromContext(this).Inflate(Resource.Layout.Scanning, null);

                //Find the button from our resource layout and wire up the click event

                ScanText = zxingOverlay.FindViewById<TextView>(Resource.Id.ScanText);
                ScanText.Text = "扫描二维码完成借书操作";
                flashButton = zxingOverlay.FindViewById<Button>(Resource.Id.buttonZxingFlash);
                flashButton.Click += (sender, e) => scanner.ToggleTorch();

                //Set our custom overlay
                scanner.CustomOverlay = zxingOverlay;

                //Start scanning!
                var result = await scanner.Scan();

                HandleScanResult_Borrow(result);
            };
            ReturnScan.Click += async delegate {
                scanner.UseCustomOverlay = true;

                //Inflate our custom overlay from a resource layout
                zxingOverlay = LayoutInflater.FromContext(this).Inflate(Resource.Layout.Scanning, null);

                //Find the button from our resource layout and wire up the click event
                ScanText = zxingOverlay.FindViewById<TextView>(Resource.Id.ScanText);
                ScanText.Text = "扫描二维码完成还书操作";
                flashButton = zxingOverlay.FindViewById<Button>(Resource.Id.buttonZxingFlash);
                flashButton.Click += (sender, e) => scanner.ToggleTorch();

                //Set our custom overlay
                scanner.CustomOverlay = zxingOverlay;

                //Start scanning!
                var result = await scanner.Scan();

                HandleScanResult_Return(result);
            };
            BookList.Click += delegate
            {
                Intent ActList = new Intent(this, typeof(BookListViewAdmin));
                ActList.PutExtra("SearchInfo", "");
                StartActivity(ActList);
            };
        }

        void HandleScanResult_Borrow(ZXing.Result result)
        {
            string msg = "";

            if (result != null && !string.IsNullOrEmpty(result.Text))
                msg = result.Text;
            else
                msg = "-1";


            RunOnUiThread(() =>
            {
                if (msg != "-1")
                {
                    if (Regex.IsMatch(result.Text, "borrow::"))
                    {
                        string scanResult = result.Text.Replace("borrow::", "");
                        var borrowInfo = JsonConvert.DeserializeObject<List<BookInfo>>(scanResult);
                        foreach (BookInfo a in borrowInfo)
                        {
                            string res = Data.Post("http://115.159.145.115/BorrowAdmin.php", a.PhoneNum, a.BookId);
                        }
                        Toast.MakeText(this, "借书成功！", ToastLength.Short).Show();
                    }
                    else
                    {
                        Toast.MakeText(this, "二维码不正确,扫描取消", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "扫描取消", ToastLength.Short).Show();
                }
            });
        }

        void HandleScanResult_Return(ZXing.Result result)
        {
            string msg = "";

            if (result != null && !string.IsNullOrEmpty(result.Text))
                msg = result.Text;
            else
                msg = "-1";


            RunOnUiThread(() =>
            {
                if (msg != "-1")
                {
                    if (Regex.IsMatch(result.Text, "return::"))
                    {
                        string scanResult = result.Text.Replace("return::", "");
                        var returnInfo = JsonConvert.DeserializeObject<List<BookInfo>>(scanResult);
                        foreach (BookInfo a in returnInfo)
                        {
                            string res = Data.Post("http://115.159.145.115/ReturnAdmin.php", a.PhoneNum, a.BookId);
                          
                        }
                        Toast.MakeText(this, "还书成功！", ToastLength.Short).Show();

                    }
                    else
                    {
                        Toast.MakeText(this, "二维码不正确,扫描取消", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "扫描取消", ToastLength.Short).Show();
                }
            });
        }

        public class Data
        {
            public static string Post(string url, string PhoneNum, string BookId)
            {
                string postString = "PhoneNum=" + PhoneNum + "&BookId=" + BookId;
                byte[] postData = Encoding.UTF8.GetBytes(postString);
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] responseData = webClient.UploadData(url, "POST", postData);
                string srcString = Encoding.UTF8.GetString(responseData);

                return srcString;

            }
        }

        private void Menu_MenuItemClick(object sender, PopupMenu.MenuItemClickEventArgs e)
        {
            if (e.Item.ItemId == Resource.Id.Logout)
            {
                Intent ActLogin = new Intent(this, typeof(Login));
                StartActivity(ActLogin);
                Finish();
            }
            else if (e.Item.ItemId == Resource.Id.about)
            {
                Toast.MakeText(this, "林静晨 杨昊澎 王福超 黄世贤", ToastLength.Long).Show();
            }
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {

            if (keyCode == Keycode.Back)
            {
                
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }

    }
}