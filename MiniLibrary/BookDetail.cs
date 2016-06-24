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
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace MiniLibrary
{
    [Activity(Label = "BookDetail",WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class BookDetail : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BookDetail);
            Button borrowButton = FindViewById<Button>(Resource.Id.borrow1);
            Button reserveButton = FindViewById<Button>(Resource.Id.reserve1);
            Button collectionButton = FindViewById<Button>(Resource.Id.collection1);
            TabHost tab = FindViewById<TabHost>(Resource.Id.tabHost123);

            TextView bookSummary = FindViewById<TextView>(Resource.Id.textView_BookSummary); //内容概要
            TextView bookCatalog = FindViewById<TextView>(Resource.Id.textView_BookCatalog); //本书目录
            TextView bookClassId = FindViewById<TextView>(Resource.Id.textView_BookClassId);
            TextView bookPrice = FindViewById<TextView>(Resource.Id.textView_BookPrice);
            TextView bookPress = FindViewById<TextView>(Resource.Id.textView_BookPress);
            TextView bookClassification = FindViewById<TextView>(Resource.Id.textView_BookClassification);

            TextView bookAuthor = FindViewById<TextView>(Resource.Id.bookDetailAuthor);
            TextView bookName = FindViewById<TextView>(Resource.Id.bookDetailBookname);

            //这个“1”即为ID号
            string result = BookDetailData.Post("http://115.159.145.115/BookDetail.php/", "1");
            var book = JsonConvert.DeserializeObject<BookClass>(result);

          
            string bookclassId = book.BookClassId;
            bookAuthor.Text = book.BookAuthor; //标题：作者
            bookName.Text = book.BookName; //标题：书名
            bookSummary.Text = book.BookSummary;//Tab1:内容概要
            bookCatalog.Text = book.BookCatalog;//Tab2:本书目录
            bookClassId.Text = book.BookClassId;
            bookPrice.Text = book.BookPrice;
            bookPress.Text = book.BookPress;
            bookClassification.Text = book.BookClassification;

            tab.Setup();

            TabHost.TabSpec spec1 = tab.NewTabSpec("tab1");
            spec1.SetContent(Resource.Id.layoutBookSummary);
            spec1.SetIndicator("内容概要");

            TabHost.TabSpec spec2 = tab.NewTabSpec("tab2");
            spec2.SetContent(Resource.Id.layoutBookCatalog);
            spec2.SetIndicator("本书目录");

            TabHost.TabSpec spec3 = tab.NewTabSpec("tab3");
            spec3.SetContent(Resource.Id.layoutIntroduction);
            spec3.SetIndicator("发行简介");

           tab.AddTab(spec1);
           tab.AddTab(spec2);
           tab.AddTab(spec3);
            // Create your application here
            Random rad = new Random();//实例化随机数产生器rad；
            int value = rad.Next(10, 99);
            if (value % 2 == 0)
            {
                borrowButton.Text = "还书";
                reserveButton.Enabled = false;
                borrowButton.Click += (s, e) =>
                {
                    //对话框
                    var Dialog = new AlertDialog.Builder(this);

                    //对话框内容
                    Dialog.SetMessage("确认要还此书?");

                    //确认按钮
                    Dialog.SetNeutralButton("确认", delegate
                    {
                        Intent intent = new Intent(this, typeof(BorrowReader));
                        intent.PutExtra("BookClassId", bookclassId);
                        StartActivity(intent);
                    });

                    //取消按钮
                    Dialog.SetNegativeButton("取消", delegate { });

                    //显示对话框
                    Dialog.Show();
                };
            }
            else
            {
                borrowButton.Text = "借书";

                borrowButton.Click += (s, e) =>
                {
                //对话框
                var Dialog = new AlertDialog.Builder(this);

                //对话框内容
                Dialog.SetMessage("确认借阅此书?");

                //确认按钮
                Dialog.SetNeutralButton("确认", delegate
                    {
                        Intent ActLogin = new Intent(this, typeof(BorrowReader));
                        StartActivity(ActLogin);
                    });

                //取消按钮
                Dialog.SetNegativeButton("取消", delegate { });

                //显示对话框
                Dialog.Show();
                };
            }
            collectionButton.Click += (s, e) =>
            {
                //对话框
                var Dialog = new AlertDialog.Builder(this);

                //对话框内容
                Dialog.SetMessage("确认将此书加入书栏？");

                //确认按钮
                Dialog.SetNeutralButton("确认", delegate
                {
                    Toast.MakeText(this, "成功加入书栏！", ToastLength.Short).Show();
                });

                //取消按钮
                Dialog.SetNegativeButton("取消", delegate { });

                //显示对话框
                Dialog.Show();
            };
            reserveButton.Click += (s, e) =>
            {
                //对话框
                var Dialog = new AlertDialog.Builder(this);

                //对话框内容
                Dialog.SetMessage("确认预定此书?");

                //确认按钮
                Dialog.SetNeutralButton("确认", delegate
                {
                    Toast.MakeText(this, "预定成功！", ToastLength.Short).Show();
                });

                //取消按钮
                Dialog.SetNegativeButton("取消", delegate
                {
                });

                //显示对话框
                Dialog.Show();
            };


            



        }

        class BookClass
        {
            public string BookClassId { get; set; }
            public string BookAuthor { get; set; }
            public string BookName { get; set; }
            public string BookPress { get; set; }
            public string BookPrice { get; set; }
            public string BookSummary { get; set; }
            public string BookCatalog { get; set; }
            public string BookClassification { get; set; }


        }

        class BookDetailData
        {
            public static string Post(string url, string BookClassId)
            {
                string para = "BookClassId=" + BookClassId;
                HttpWebRequest httpWeb = (HttpWebRequest)WebRequest.Create(url);
                httpWeb.Timeout = 20000;
                httpWeb.Method = "POST";
                httpWeb.ContentType = "application/x-www-form-urlencoded";
                byte[] bytePara = Encoding.ASCII.GetBytes(para);
                using (Stream reqStream = httpWeb.GetRequestStream())
                {
                    reqStream.Write(bytePara, 0, para.Length);
                }
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWeb.GetResponse();
                Stream stream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
                string result = streamReader.ReadToEnd();
                stream.Close();

                return result;

            }
        }

    }
}