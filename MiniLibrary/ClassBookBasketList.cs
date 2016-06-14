using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Android.App;
using MiniLibrary;
using Square.Picasso;

namespace BookBasketList
{
    public class BookBasketListInfo
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public string BookNumber { get; set; }
  
    }

    class BookBasketListAdapter : BaseAdapter<BookBasketListInfo>
    {
        List<BookBasketListInfo> items;

        Activity context;

        public BookBasketListAdapter(Activity context,List<BookBasketListInfo> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override BookBasketListInfo this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.BookBasketItemCart,null);
            }
            view.FindViewById<TextView>(Resource.Id.ListTextBook).Text = item.Title;
            view.FindViewById<TextView>(Resource.Id.ListTextBookNumber).Text = item.BookNumber;
            Picasso.With(context).Load(item.Image).Into(view.FindViewById<ImageView>(Resource.Id.listImbtnbook));
            return view;
        }

    }
}