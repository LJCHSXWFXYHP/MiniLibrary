using System.Collections.Generic;
using System.Net;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Android.App;
using MiniLibrary;
using Square.Picasso;

namespace BookListView
{
    public class MyBookListViewInfo
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string BookClassId { get; set; }
        public string BookId { get; set; }
        public int ReturnFlag { get; set; }
        public string BorrowDate { get; set; }
        public bool selected { get; set; }
    }

    class MyBookListViewAdapter : BaseAdapter<MyBookListViewInfo>
    {
        List<MyBookListViewInfo> items;
        CheckBox checkBox;
        private ListView listview;
        string method;
        Activity context;

        public MyBookListViewAdapter(Activity context, List<MyBookListViewInfo> items,ListView listview, string method) : base()
        {
            this.method = method;
            this.context = context;
            this.items = items;
            this.listview = listview;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override MyBookListViewInfo this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.BookListViewMyBookItemCart, null);
            }
            view.FindViewById<TextView>(Resource.Id.MyBookTextBook).Text = item.Title;
            view.FindViewById<TextView>(Resource.Id.MyBookAuthor).Text = item.Author;
            Picasso.With(context).Load(item.Image).Into(view.FindViewById<ImageView>(Resource.Id.MyBookImBook));
            view.FindViewById<TextView>(Resource.Id.MyBookId).Text = "书本ID:"+item.BookId;
            view.FindViewById<TextView>(Resource.Id.MyBookDate).Text = item.BorrowDate;
            checkBox = view.FindViewById<CheckBox>(Resource.Id.MyBookCheck);

            if (method == "MyBookAll")
            {
                checkBox.Visibility = ViewStates.Invisible;
            }
            else
            {
                checkBox.Tag = position;
                checkBox.Checked = listview.IsItemChecked(position);
                checkBox.CheckedChange += CheckBox_CheckedChange;
            }

            return view;
        }

        private void CheckBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            var cbSelect = sender as CheckBox;
            if (cbSelect != null)
            {
                var position = (int)cbSelect.Tag;
                listview.SetItemChecked(position, cbSelect.Checked);
                items[position].selected = cbSelect.Checked;
            }
        }
    }
}