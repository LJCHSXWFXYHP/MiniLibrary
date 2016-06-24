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
using BookListView;
using Newtonsoft.Json;
using ZXing.Mobile;


namespace MiniLibrary
{
    [Activity(Label = "BookListView", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]

    public class BookListView : Activity
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
            if(SearchInfo!="")
            {

                SearchMethod("http://115.159.145.115/SearchByKeyWord.php", SearchInfo);
            }

            MobileBarcodeScanner.Initialize(Application);
            scanner = new MobileBarcodeScanner();
            Scan.Click += async delegate {

                //Tell our scanner to use the default overlay
                scanner.UseCustomOverlay = false;

                //We can customize the top and bottom text of the default overlay
                scanner.TopText = "请保持条形码与手机镜头15厘米";
                scanner.BottomText = "扫描书本条形码快速搜索";

                //Start scanning
                var result = await scanner.Scan();

                HandleScanResult(result);
            };

            Search.Click += delegate
            {
                if (SearchEdit.Text != "")
                {
                    Intent ActBookList = new Intent(this, typeof(BookListView));
                    Bundle bundle = new Bundle();
                    ActBookList.PutExtra("SearchInfo", SearchEdit.Text);
                    ActBookList.PutExtras(bundle);
                    StartActivity(ActBookList);
                }
            };

        }

        private void SearchMethod(string url,string keyword)
        {
            string SearchResult = SearchData.Post(url, keyword);
            var ResultList = JsonConvert.DeserializeObject<List<BookClass>>(SearchResult);
            foreach (BookClass b in ResultList)
            {
                BookInfo.Add(new BookListViewInfo { Title = b.BookName, Image = b.ImageUrl, Author = b.BookAuthor, BookClassId = b.BookClassId });
            }
            BookList.Adapter = new BookListViewAdapter(this, BookInfo);

            BookList.ItemClick += BookList_ItemClick;
        }

        private void BookList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent ActBookDetail = new Intent(this, typeof(BookDetails));
            ActBookDetail.PutExtra("BookClassId", BookInfo[e.Position].BookClassId);
            StartActivity(ActBookDetail);
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

        void HandleScanResult(ZXing.Result result)
        {
            RunOnUiThread(() => {
                Intent ActBookList = new Intent(this, typeof(BookListView));
                ActBookList.PutExtra("SearchInfo", result.Text);
                StartActivity(ActBookList);
            });
        }
    }
}

