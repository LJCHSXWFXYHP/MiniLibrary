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

            BookInfo = new List<BookListViewInfo>();
            if (SearchType != "")
            {
                SearchMethod("http://115.159.145.115/SearchByType.php", SearchType);
            }

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

        private void SearchMethod(string url, string keyword)
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

        private void BookList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent ActBookDetail = new Intent(this, typeof(BookDetails));
            ActBookDetail.PutExtra("BookClassId", BookInfo[e.Position].BookClassId);
            StartActivity(ActBookDetail);
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