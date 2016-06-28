using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BookListView;
using Newtonsoft.Json;
using ZXing.Mobile;

namespace MiniLibrary
{
    [Activity(Label = "BookListView_type", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class BookListView_type : Activity
    {
        private class BookClass
        {
            public string BookClassId { get; set; }
            public string BookName { get; set; }
            public string BookAuthor { get; set; }
            public string ImageUrl { get; set; }
        }
        private ImageView Scan;
        private ImageView Search;
        private EditText SearchEdit;
        private List<BookListViewInfo> BookInfo;
        private ListView BookList;
        private MobileBarcodeScanner scanner;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.BookListView);
            Scan = FindViewById<ImageView>(Resource.Id.ListimScan);
            Search = FindViewById<ImageView>(Resource.Id.ListimSearch);
            SearchEdit = FindViewById<EditText>(Resource.Id.ListEditSearch);
            BookList = FindViewById<ListView>(Resource.Id.BookList);

            Scan.SetImageResource(Resource.Drawable.IconScan);
            Search.SetImageResource(Resource.Drawable.IconSearch);

            string SearchType = Intent.GetStringExtra("SearchType");
            string SearchInfo = Intent.GetStringExtra("SearchInfo");

            BookInfo = new List<BookListViewInfo>();
            if (SearchType != "")
            {
                SearchMethod("http://115.159.145.115/SearchByType.php", SearchInfo,SearchType);
            }

            MobileBarcodeScanner.Initialize(Application);
            Button flashButton;
            View zxingOverlay;
            scanner = new MobileBarcodeScanner();
            Scan.Click += async delegate {
                scanner.UseCustomOverlay = true;

                //Inflate our custom overlay from a resource layout
                zxingOverlay = LayoutInflater.FromContext(this).Inflate(Resource.Layout.Scanning, null);

                //Find the button from our resource layout and wire up the click event
                flashButton = zxingOverlay.FindViewById<Button>(Resource.Id.buttonZxingFlash);
                flashButton.Click += (sender, e) => scanner.ToggleTorch();

                //Set our custom overlay
                scanner.CustomOverlay = zxingOverlay;

                //Start scanning!
                var result = await scanner.Scan();

                HandleScanResult(result);
            };

            Search.Click += delegate
            {
                if (SearchEdit.Text != "")
                {
                    Intent ActBookList = new Intent(this, typeof(BookListView_type));
                    ActBookList.PutExtra("SearchInfo", SearchEdit.Text);
                    ActBookList.PutExtra("SearchType", SearchType);
                    StartActivity(ActBookList);

                }
            };

        }

        private void SearchMethod(string url, string keyword,string type)
        {
            string SearchResult = SearchData.Post(url, keyword, type);
            var ResultList = JsonConvert.DeserializeObject<List<BookClass>>(SearchResult);
            foreach (BookClass b in ResultList)
            {
                BookInfo.Add(new BookListViewInfo { Title = b.BookName, Image = b.ImageUrl, Author = b.BookAuthor, BookClassId = b.BookClassId });
            }
            BookList.Adapter = new BookListViewAdapter(this, BookInfo);
            BookList.ItemClick += BookList_ItemClick;
        }

        public class SearchData
        {
            public static string Post(string url, string KeyWord, string type)
            {
                string postString = "KeyWord=" + KeyWord + "&type=" + type;
                byte[] postData = Encoding.UTF8.GetBytes(postString);
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] responseData = webClient.UploadData(url, "POST", postData);
                string srcString = Encoding.UTF8.GetString(responseData);

                return srcString;

            }
        }

        private void BookList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            ISharedPreferences LoginSP = GetSharedPreferences("LoginData", FileCreationMode.Private);
            if (LoginSP.GetString("RealName", "") != "")
            {
                Intent ActBookDetail = new Intent(this, typeof(BookDetail));
                ActBookDetail.PutExtra("BookClassId", BookInfo[e.Position].BookClassId);
                StartActivity(ActBookDetail);
            }
            else
            {
                Toast.MakeText(this, "请先去个人中心实名认证哦！", ToastLength.Short).Show();
            }
        }

        void HandleScanResult(ZXing.Result result)
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
                    Intent ActBookList = new Intent(this, typeof(BookListView));
                    ActBookList.PutExtra("SearchInfo", msg);
                    StartActivity(ActBookList);
                }
                else
                {
                    Toast.MakeText(this, "扫描取消", ToastLength.Short).Show();
                }
            });
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {

            if (keyCode == Keycode.Back)
            {
                Intent ActIndex = new Intent(this, typeof(Index));
                StartActivity(ActIndex);
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
    }
}