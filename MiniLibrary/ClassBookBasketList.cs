﻿using System.Collections.Generic;
using System;
using Android.Views;
using Android.Widget;
using Android.App;
using MiniLibrary;
using Square.Picasso;
using System.Net;
using System.Text;


using System.Diagnostics;

namespace BookBasketList
{
    public class BookBasketListInfo
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string BookClassId { get; set; }
        public string BookAuthor { get; set; }
        public string BookId { get; set; }
        public string PhoneNum { get; set; }
  
    }

    class BookBasketListAdapter : BaseAdapter<BookBasketListInfo>
    {
        bool flag = false;
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
            
            ImageView delete;
            var item = items[position];
            var view = convertView;
            
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.BookBasketItemCart,null);
            }
            view.FindViewById<TextView>(Resource.Id.ListTextBook).Text = item.Title;
            view.FindViewById<TextView>(Resource.Id.ListTextBookAuthor).Text = item.BookAuthor;
            delete = view.FindViewById<ImageView>(Resource.Id.ListDelete);
            delete.SetImageResource(Resource.Drawable.IconDelete);
            Picasso.With(context).Load(item.Image).Into(view.FindViewById<ImageView>(Resource.Id.listImbtnbook));
            if (flag == false)
            {
                delete.Click += delegate
                {

                string res = Post("http://115.159.145.115/DeleteBookBasketItem.php", item.PhoneNum, item.BookId);
                if (res == "Success")
                {
                        flag = true;
                        items.Remove(items[position]);
                        NotifyDataSetChanged();
                    }

                };
            }


            return view;
        }
        public  string Post(string url, string PhoneNum,string BookId)
        {
            string postString = "PhoneNum=" + PhoneNum + "&BookId=" + BookId;
            byte[] postData = Encoding.UTF8.GetBytes(postString);
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            byte[] responseData = webClient.UploadData(url, "POST", postData);
            string srcString = Encoding.UTF8.GetString(responseData);

            return srcString;

        }

    }
}