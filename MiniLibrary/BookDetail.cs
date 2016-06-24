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

            TextView bookSummary = FindViewById<TextView>(Resource.Id.textView_BookSummary); //���ݸ�Ҫ
            TextView bookCatalog = FindViewById<TextView>(Resource.Id.textView_BookCatalog);
            //TextView authorSummary = FindViewById<TextView>(Resource.Id.textView_Author);
            TextView bookId = FindViewById<TextView>(Resource.Id.textView_BookId);
            TextView bookPrice = FindViewById<TextView>(Resource.Id.textView_BookPrice);
            TextView bookPress = FindViewById<TextView>(Resource.Id.textView_BookPress);

            TextView bookAuthor = FindViewById<TextView>(Resource.Id.bookDetailAuthor);
            TextView bookName = FindViewById<TextView>(Resource.Id.bookDetailBookname);

            //�����1����ΪID��
            string result = BookDetailData.Post("http://115.159.145.115/BookDetail.php/", "1");
            var book = JsonConvert.DeserializeObject<BookClass>(result);

            bookSummary.Text = book.BookSummary;//���ݸ�Ҫ
            bookCatalog.Text = book.BookCatalog;//����Ŀ¼


            string bookclassId = book.BookClassId;
            bookAuthor.Text = book.BookAuthor; //���⣺����
            bookName.Text = book.BookName; //���⣺����
            authorSummary.Text = book.AuthorSummary;//Tab1:���ݸ�Ҫ
            bookSummary.Text = book.BookSummary;//Tab2:����Ŀ¼
            bookCatalog.Text = book.BookCatalog;//Tab3:���м��
            bookId.Text = book.BookClassId;
            bookPrice.Text = book.BookPrice;
            bookPress.Text = book.BookPress;

            tab.Setup();

            TabHost.TabSpec spec1 = tab.NewTabSpec("tab1");
            spec1.SetContent(Resource.Id.layoutBookSummary);
            spec1.SetIndicator("���ݸ�Ҫ");

            TabHost.TabSpec spec2 = tab.NewTabSpec("tab2");
            spec2.SetContent(Resource.Id.layoutBookCatalog);
            spec2.SetIndicator("����Ŀ¼");

            TabHost.TabSpec spec3 = tab.NewTabSpec("tab3");
            spec3.SetContent(Resource.Id.layoutIntroduction);
            spec3.SetIndicator("���м��");

           tab.AddTab(spec1);
           tab.AddTab(spec2);
           tab.AddTab(spec3);
            // Create your application here
            Random rad = new Random();//ʵ���������������rad��
            int value = rad.Next(10, 99);
            if (value % 2 == 0)
            {
                borrowButton.Text = "����";
                reserveButton.Enabled = false;
                borrowButton.Click += (s, e) =>
                {
                    //�Ի���
                    var Dialog = new AlertDialog.Builder(this);

                    //�Ի�������
                    Dialog.SetMessage("ȷ��Ҫ������?");

                    //ȷ�ϰ�ť
                    Dialog.SetNeutralButton("ȷ��", delegate
                    {
                        Intent intent = new Intent(this, typeof(BorrowReader));
                        Bundle bundle = new Bundle();
                        bundle.PutString("bookclassid", bookclassId);
                        intent.PutExtra("bundle", bundle);
                        StartActivity(intent);
                    });

                    //ȡ����ť
                    Dialog.SetNegativeButton("ȡ��", delegate { });

                    //��ʾ�Ի���
                    Dialog.Show();
                };
            }
            else
            {
                borrowButton.Text = "����";

                borrowButton.Click += (s, e) =>
                {
                //�Ի���
                var Dialog = new AlertDialog.Builder(this);

                //�Ի�������
                Dialog.SetMessage("ȷ�Ͻ��Ĵ���?");

                //ȷ�ϰ�ť
                Dialog.SetNeutralButton("ȷ��", delegate
                    {
                        Intent ActLogin = new Intent(this, typeof(BorrowReader));
                        StartActivity(ActLogin);
                    });

                //ȡ����ť
                Dialog.SetNegativeButton("ȡ��", delegate { });

                //��ʾ�Ի���
                Dialog.Show();
                };
            }
            collectionButton.Click += (s, e) =>
            {
                //�Ի���
                var Dialog = new AlertDialog.Builder(this);

                //�Ի�������
                Dialog.SetMessage("ȷ�Ͻ��������������");

                //ȷ�ϰ�ť
                Dialog.SetNeutralButton("ȷ��", delegate
                {
                    Toast.MakeText(this, "�ɹ�����������", ToastLength.Short).Show();
                });

                //ȡ����ť
                Dialog.SetNegativeButton("ȡ��", delegate { });

                //��ʾ�Ի���
                Dialog.Show();
            };
            reserveButton.Click += (s, e) =>
            {
                //�Ի���
                var Dialog = new AlertDialog.Builder(this);

                //�Ի�������
                Dialog.SetMessage("ȷ��Ԥ������?");

                //ȷ�ϰ�ť
                Dialog.SetNeutralButton("ȷ��", delegate
                {
                    Toast.MakeText(this, "Ԥ���ɹ���", ToastLength.Short).Show();
                });

                //ȡ����ť
                Dialog.SetNegativeButton("ȡ��", delegate
                {
                });

                //��ʾ�Ի���
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