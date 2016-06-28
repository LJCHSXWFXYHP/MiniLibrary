using System.Collections.Generic;
using System.Net;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Android.App;
using MiniLibrary;
using Square.Picasso;

namespace MyBookListView
{
    public class BookListViewInfo
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string BookClassId { get; set; }
        public string ReturnFlag { get; set; }
        public string BorrowDate { get; set; }
        public string count { get; set; }
    }

    class BookListViewAdapter : BaseAdapter<BookListViewInfo>
    {
        List<BookListViewInfo> items;

        Activity context;

        public BookListViewAdapter(Activity context, List<BookListViewInfo> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override BookListViewInfo this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.BookListViewAdminCart, null);
            }
            view.FindViewById<TextView>(Resource.Id.count).Text = "¿â´æ:" + item.count;
            view.FindViewById<TextView>(Resource.Id.BklistTextBook).Text = item.Title;
            view.FindViewById<TextView>(Resource.Id.BklistAuthor).Text = item.Author;
            Picasso.With(context).Load(item.Image).Into(view.FindViewById<ImageView>(Resource.Id.BklistImBook));
            return view;
        }
    }
}