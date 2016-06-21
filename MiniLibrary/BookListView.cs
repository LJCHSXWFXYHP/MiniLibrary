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
using BookListView;

namespace MiniLibrary
{
    [Activity(Label = "BookListView", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class BookListView : Activity
    {
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

            BookInfo = new List<BookListViewInfo>();
            BookInfo.Add(new BookListViewInfo { Title = "°ÙÄê¹Â¶À", Image = "http://cover1.bookday.cn/73/52/9787544253994.jpg", BookNumber = "111" });
            BookInfo.Add(new BookListViewInfo { Title = "123", Image = "http://cover1.bookday.cn/73/52/9787544253994.jpg", BookNumber = "222" });
            BookInfo.Add(new BookListViewInfo { Title = "123", Image = "http://cover1.bookday.cn/73/52/9787544253994.jpg", BookNumber = "222" });
            BookInfo.Add(new BookListViewInfo { Title = "123", Image = "http://cover1.bookday.cn/73/52/9787544253994.jpg", BookNumber = "222" });
            BookInfo.Add(new BookListViewInfo { Title = "123", Image = "http://cover1.bookday.cn/73/52/9787544253994.jpg", BookNumber = "222" });
            BookInfo.Add(new BookListViewInfo { Title = "123", Image = "http://cover1.bookday.cn/73/52/9787544253994.jpg", BookNumber = "222" });

            BookList.Adapter = new BookListViewAdapter(this, BookInfo);
        }
    }
}

