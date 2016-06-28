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
using MyBookListView;
using Newtonsoft.Json;
using ZXing.Mobile;


namespace MiniLibrary
{
    [Activity(Label = "BookListViewAdmin", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]

    public class BookListViewAdmin : Activity
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


            string SearchInfo = Intent.GetStringExtra("SearchInfo");

            BookInfo = new List<BookListViewInfo>();
            if (SearchInfo != "")
            {

                SearchMethod("http://115.159.145.115/SearchByKeyWord.php", SearchInfo);
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
                    Intent ActBookList = new Intent(this, typeof(BookListViewAdmin));
                    Bundle bundle = new Bundle();
                    ActBookList.PutExtra("SearchInfo", SearchEdit.Text);
                    ActBookList.PutExtras(bundle);
                    StartActivity(ActBookList);
                }
            };

        }

        private void SearchMethod(string url, string keyword)
        {
            string SearchResult = SearchData.Post(url, keyword);
            var ResultList = JsonConvert.DeserializeObject<List<BookClass>>(SearchResult);
            
            foreach (BookClass b in ResultList)
            {
                string Count = BorrowData.Post("http://115.159.145.115/BookBasketBorrowCheck.php/", b.BookClassId);
                BookInfo.Add(new BookListViewInfo { Title = b.BookName, Image = b.ImageUrl, Author = b.BookAuthor, BookClassId = b.BookClassId,count=Count});
            }
            BookList.Adapter = new BookListViewAdapter(this, BookInfo);

        }

        public class SearchData
        {
            public static string Post(string url, string KeyWord)
            {
                string postString = "KeyWord=" + KeyWord;
                byte[] postData = Encoding.UTF8.GetBytes(postString);
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] responseData = webClient.UploadData(url, "POST", postData);
                string srcString = Encoding.UTF8.GetString(responseData);

                return srcString;

            }
        }
        public class BorrowData
        {
            public static string Post(string url, string BookCLassId)
            {
                string postString = "BookClassId=" + BookCLassId;
                byte[] postData = Encoding.UTF8.GetBytes(postString);
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] responseData = webClient.UploadData(url, "POST", postData);
                string srcString = Encoding.UTF8.GetString(responseData);

                return srcString;

            }
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {

            if (keyCode == Keycode.Back)
            {
                Intent ActAdmin = new Intent(this, typeof(Admin));
                StartActivity(ActAdmin);
            }
            return base.OnKeyDown(keyCode, e);
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
                    Intent ActBookList = new Intent(this, typeof(BookListViewAdmin));
                    ActBookList.PutExtra("SearchInfo", msg);
                    StartActivity(ActBookList);
                }
                else
                {
                    Toast.MakeText(this, "…®√Ë»°œ˚", ToastLength.Short).Show();
                }
            });
        }
    }
}

