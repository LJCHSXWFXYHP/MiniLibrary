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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.BookListView);
            Scan = FindViewById<ImageView>(Resource.Id.ListimScan);
            Search = FindViewById<ImageView>(Resource.Id.ListimSearch);
            BookList = FindViewById<ListView>(Resource.Id.BookList);

            Scan.SetImageResource(Resource.Drawable.IconScan);
            Search.SetImageResource(Resource.Drawable.IconSearch);


            string SearchInfo = Intent.GetStringExtra("SearchInfo");

            BookInfo = new List<BookListViewInfo>();
            if (SearchInfo != "")
            {
                string SearchResult = SearchData.Post("http://115.159.145.115/SearchByKeyWord.php", SearchInfo);
                var ResultList = JsonConvert.DeserializeObject<List<BookClass>>(SearchResult);
                foreach(BookClass b in ResultList)
                {
                    BookInfo.Add(new BookListViewInfo { Title=b.BookName, Image = b.ImageUrl, Author = b.BookAuthor ,BookClassId=b.BookClassId});
                }
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
    }
}

