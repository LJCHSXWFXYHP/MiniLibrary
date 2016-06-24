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
    [Activity(Label = "BookListView_MyBook", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class BookListView_MyBook : Activity
    {

        private class ReturnList
        {
            public string BookId { get; set; }
            public string PhoneNum { get; set; }
            public string BorrowDate { get; set; }
        }
        private class BookClass
        {
            public string BookClassId { get; set; }
            public string BookName { get; set; }
            public string BookAuthor { get; set; }
            public string ImageUrl { get; set; }
            public string BookId { get; set; }
            public int ReturnFlag { get; set;}
            public string BorrowDate { get; set; }
        }
        private Button ReturnAll;
        private List<MyBookListViewInfo> BookInfo;
        private ListView BookList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.BookListViewMyBook);
            ReturnAll = FindViewById<Button>(Resource.Id.ReturnAll);
            BookList = FindViewById<ListView>(Resource.Id.TabBookBasketList);

            ISharedPreferences LoginSP = GetSharedPreferences("LoginData", FileCreationMode.Private);
            var PhoneNum = LoginSP.GetString("PhoneNum", null);

            BookInfo = new List<MyBookListViewInfo>();

            if (Intent.GetStringExtra("flag") == "MyBook")
            {
                SearchMethod("http://115.159.145.115/MyBook.php", PhoneNum,"MyBook");
            }
            if(Intent.GetStringExtra("flag") == "MyBookAll")
            {
                SearchMethod("http://115.159.145.115/MyBook.php", PhoneNum, "MyBookAll");
            }
            ReturnAll.Click += delegate
            {
                List<ReturnList> returnList = new List<ReturnList>();
                foreach (MyBookListViewInfo b in BookInfo)
                {
                    if (b.selected == true) {
                        returnList.Add(new ReturnList { BookId = b.BookId, PhoneNum = LoginSP.GetString("PhoneNum", ""), BorrowDate = b.BorrowDate });
                    }
                }
                var BorrowJson = JsonConvert.SerializeObject(returnList);
                Toast.MakeText(this, BorrowJson, ToastLength.Long).Show();
            };
            

        }

        private void SearchMethod(string url, string keyword,string method)
        {
            string SearchResult = SearchData.Post(url, keyword);
            var ResultList = JsonConvert.DeserializeObject<List<BookClass>>(SearchResult);
            if (method == "MyBook")
            {
                foreach (BookClass b in ResultList)
                {
                    if (b.ReturnFlag == 0)
                    {
                        BookInfo.Add(new MyBookListViewInfo { Title = b.BookName, Image = b.ImageUrl, Author = b.BookAuthor, BookClassId = b.BookClassId, ReturnFlag = b.ReturnFlag, BookId = b.BookId, BorrowDate = b.BorrowDate });
                    }
                }
                BookList.Adapter = new MyBookListViewAdapter(this, BookInfo, BookList, "MyBook");
            }
            else if (method == "MyBookAll")
            {
                ReturnAll.Visibility = ViewStates.Invisible;
                foreach (BookClass b in ResultList)
                {
                    BookInfo.Add(new MyBookListViewInfo { Title = b.BookName, Image = b.ImageUrl, Author = b.BookAuthor, BookClassId = b.BookClassId, ReturnFlag = b.ReturnFlag, BookId = b.BookId, BorrowDate = b.BorrowDate });

                }
                BookList.Adapter = new MyBookListViewAdapter(this, BookInfo, BookList, "MyBookAll");
            }
            
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
            ActBookDetail.PutExtra("z", BookInfo[e.Position].BookClassId);
            StartActivity(ActBookDetail);
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {

            if (keyCode == Keycode.Back)
            {
                Finish();
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
    }
}