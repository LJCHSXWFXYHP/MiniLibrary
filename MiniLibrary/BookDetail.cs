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
using Square.Picasso;

namespace MiniLibrary
{
    [Activity(Label = "BookDetail",WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class BookDetail : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BookDetail);
            string updateBookId="";

            Button borrowButton = FindViewById<Button>(Resource.Id.borrow1);
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

            bool totalbooknumber2=false;
            bool renewdays3=false;
            bool notrenewdays4=false;
            bool returncheck5=false;
            ISharedPreferences LoginSP = GetSharedPreferences("LoginData", FileCreationMode.Private);
            string PhoneNum = LoginSP.GetString("PhoneNum", null); //获取电话号码
           
            string thebookClassId=Intent.GetStringExtra("BookClassId");

           
            
            string PersonTotalBookResult = PersonalTotalBookData.Post("http://115.159.145.115/PersonalTotalBook.php/", PhoneNum);
            //检查个人借书总数是否超过规定
            string personaltotalbooknumber = PersonTotalBookResult;

            string RenewDaysResult = RenewDaysData.Post("http://115.159.145.115/RenewDays.php/", PhoneNum);
            //检查已续借的书是否过期
            string renewdays = RenewDaysResult;

            string NotRenewDaysResult = NotRenewDaysData.Post("http://115.159.145.115/NotRenewDays.php/", PhoneNum);
             //检查未续借的书是否过期
            string notrenewdays = NotRenewDaysResult;

            string result = BookDetailData.Post("http://115.159.145.115/BookDetail.php/", thebookClassId);
            var book = JsonConvert.DeserializeObject<BookClass>(result); //本类书详情
            string result1 = BookDetailData.Post("http://115.159.145.115/ReturnCheck.php/", thebookClassId);
            var returncheck= JsonConvert.DeserializeObject<List<ReturnCheck>>(result1); //读借书信息

            if(personaltotalbooknumber!=null)
            {
                int thetotalbooknumber = 0;
                int.TryParse(personaltotalbooknumber, out thetotalbooknumber);
                if(thetotalbooknumber >= 0 && thetotalbooknumber < 10)
                {
                    //符合规定，可以借书
                    totalbooknumber2 = true;
                }
                else
                {
                    //不能借书
                    totalbooknumber2 = false;
                }
            }
            if(renewdays!=null)
            {
                int therenewdays = 0;
                int.TryParse(renewdays, out therenewdays);
                if(therenewdays>=0 && therenewdays<=20)
                {
                    //符合规定，可以借书
                    renewdays3 = true;
                }
                else
                {
                    //超过续借日期，不能借书
                    renewdays3 = false;
                }
            }
            else
            {
                //可以借书
                renewdays3 = true;
            }
            if(notrenewdays!=null)
            {
                int thenotrenewdays = 0;
                int.TryParse(notrenewdays, out thenotrenewdays);
                if(thenotrenewdays>=0 && thenotrenewdays<=10)
                {
                    //可以借书
                    notrenewdays4 = true;
                }
                else
                {
                    //超期未还，不能借书
                    notrenewdays4 = false;
                }
            }
            else
            {
                //可以借书
                notrenewdays4 = true;
            }
            int judgePhoneNum = 0;
            int judge = 1; //判断该类书是否被借完
            int judgeRenew = 0; //判断是本书是否续借
            if (returncheck.Count == 0)
            {
                //无法传BookID
                string QueryIdResult = BookDetailData.Post("http://115.159.145.115/QueryId.php/", thebookClassId);
                var queryid = JsonConvert.DeserializeObject<List<QueryId>>(QueryIdResult);
                foreach (QueryId b in queryid)
                {
                    updateBookId = b.BookId;
                }
                returncheck5 = true;
            }
            else
            {
                foreach (ReturnCheck a in returncheck)
                {
                    if (a.ReturnFlag == "1")
                    {
                        updateBookId = a.BookId;
                        //可以借书
                        returncheck5 = true;

                    }
                    else if (a.PhoneNum == PhoneNum && a.ReturnFlag == "0")
                    {
                        if (a.IfRenew == "0")
                        {
                            judgeRenew = 0; //本书没有被续借
                        }
                        else
                        {
                            judgeRenew = 1; //本书已经被续借
                        }
                        updateBookId = a.BookId;
                        returncheck5 = false;
                        judgePhoneNum = 1;
                        //还书或续借
                    }
                    else
                    {
                        //又不可以借，又不可以还
                        //该类书已经被借完
                        judge = 0;
                    }
                }
            }
            

            bookAuthor.Text = book.BookAuthor; //标题：作者
            bookName.Text = book.BookName; //标题：书名
            bookSummary.Text = book.BookSummary;//Tab1:内容概要
            bookCatalog.Text = book.BookCatalog;//Tab2:本书目录
            bookClassId.Text = "ISBN ："+book.BookClassId;
            bookPrice.Text = "价  格："+book.BookPrice;
            bookPress.Text = "出版社："+book.BookPress;
            bookClassification.Text = "分  类："+book.BookClassification;
            Picasso.With(this).Load(book.ImageUrl).Into(FindViewById<ImageView>(Resource.Id.imageView_bookImage));

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

            if (returncheck5==false && judgePhoneNum==1)
            {
                borrowButton.Text = "还书";
                borrowButton.Click += (s, e) =>
                {
                    var Dialog = new AlertDialog.Builder(this);
                    Dialog.SetMessage("确认要还此书?");
                    Dialog.SetNeutralButton("确认", delegate
                    {
                        ThisBook thisbook = new ThisBook();
                        thisbook.BookId = updateBookId;
                        thisbook.PhoneNum = PhoneNum;
                        var ReturnJson = JsonConvert.SerializeObject(thisbook);
                        Intent intent = new Intent(this, typeof(ReturnReader));
                        intent.PutExtra("ReturnBook", "["+ReturnJson+"]");
                        StartActivity(intent);
                    });
                    Dialog.SetNegativeButton("取消", delegate { });
                    Dialog.Show();
                };
                if (judgeRenew == 0) //没有被续借
                {
                    collectionButton.Text = "续借";
                    collectionButton.Click += (s, e) =>
                      {
                          var Dialog = new AlertDialog.Builder(this);
                          Dialog.SetMessage("确认续借此书？");
                          Dialog.SetNeutralButton("确认", delegate
                           {
                               string theupdatesuccess = UpdateRenewData.Post("http://115.159.145.115/Renew.php/", updateBookId,PhoneNum);
                               
                           if (theupdatesuccess == "success")
                               {
                                   Toast.MakeText(this, "续借成功！", ToastLength.Short).Show();
                                   collectionButton.Enabled = false;
                               }
                               else
                               {
                                   Toast.MakeText(this, "抱歉，续借失败！", ToastLength.Short).Show();
                               }
                           });
                          Dialog.SetNegativeButton("取消", delegate { });
                          Dialog.Show();
                      };
                }
                else if(judgeRenew == 1)
                {
                    collectionButton.Text = "续借";
                    collectionButton.Enabled = false;
                    Toast.MakeText(this, "您已续借此书，无法再次续借！", ToastLength.Short).Show();
                }
            }
            else if(judge==1&&totalbooknumber2==true && renewdays3==true && notrenewdays4==true && returncheck5==true)
            {
                borrowButton.Text = "借书";

                borrowButton.Click += (s, e) =>
                {
                var Dialog = new AlertDialog.Builder(this);
                Dialog.SetMessage("确认借阅此书?");
                Dialog.SetNeutralButton("确认", delegate
                    {
                        ThisBook thisbook = new ThisBook();
                        thisbook.BookId = updateBookId;
                        thisbook.PhoneNum = PhoneNum;
                        var ReturnJson = JsonConvert.SerializeObject(thisbook);
                        Intent ActLogin = new Intent(this, typeof(BorrowReader));

                        ActLogin.PutExtra("BorrowInfo", "["+ReturnJson+"]");
                        StartActivity(ActLogin);
                    });
                Dialog.SetNegativeButton("取消", delegate { });
                Dialog.Show();
                };
                collectionButton.Text = "加入书篮";
                if (AddToBookBasketData.Post("http://115.159.145.115/IfInBookBasket.php/",PhoneNum, book.BookClassId) != "NotIn")
                {
                    collectionButton.Enabled = false;
                }
                collectionButton.Click += (s, e) =>
                {
                    
                    var Dialog = new AlertDialog.Builder(this);
                    Dialog.SetMessage("确认将此书加入书栏？");
                    Dialog.SetNeutralButton("确认", delegate
                    {
                        string res = AddToBookBasketData.Post("http://115.159.145.115/AddToBookBasket.php", PhoneNum, book.BookClassId);
                        if (res == "Success")
                        {
                            Toast.MakeText(this, "成功加入书栏！", ToastLength.Short).Show();
                            collectionButton.Enabled = false;
                        }
                    });
                    Dialog.SetNegativeButton("取消", delegate { });
                    Dialog.Show();
                };
            }
            else if(judge==0)
            {
                borrowButton.Text = "借书";
                collectionButton.Text = "加入书篮";
                borrowButton.Enabled = false;
                collectionButton.Enabled = false;
                Toast.MakeText(this, "抱歉，此类书已经被借完！您无法借阅此书！", ToastLength.Short).Show();
            }
            else if(totalbooknumber2==false)
            {
                borrowButton.Text = "借书";
                collectionButton.Text = "加入书篮";
                borrowButton.Enabled = false;
                collectionButton.Enabled = false;
                Toast.MakeText(this, "抱歉，您的借阅书本数量已满十本！您无法借阅此书！", ToastLength.Short).Show();
            }
            else if(renewdays3==false)
            {
                borrowButton.Text = "借书";
                collectionButton.Text = "加入书篮";
                borrowButton.Enabled = false;
                collectionButton.Enabled = false;
                Toast.MakeText(this, "抱歉，您有续借图书超期未还！您无法借阅此书！", ToastLength.Short).Show();
            }
            else if(notrenewdays4==false)
            {
                borrowButton.Text = "借书";
                collectionButton.Text = "加入书篮";
                borrowButton.Enabled = false;
                collectionButton.Enabled = false;
                Toast.MakeText(this, "抱歉，您有借阅图书超期未还！您无法借阅此书！", ToastLength.Short).Show();
            }
        }
        class AddToBookBasketData
        {
            public static string Post(string url, string PhoneNum,string BookClassId)
            {
                string para = "PhoneNum=" + PhoneNum+"&BookClassId="+BookClassId;
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
        class PersonalTotalBookData
        {
            public static string Post(string url, string PhoneNum)
            {
                string postString = "PhoneNum=" + PhoneNum;
                byte[] postData = Encoding.UTF8.GetBytes(postString);
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] responseData = webClient.UploadData(url, "POST", postData);
                string srcString = Encoding.UTF8.GetString(responseData);

                return srcString;

            }
        }
        
        class RenewDaysData
        {
            public static string Post(string url, string PhoneNum)
            {
                string para = "PhoneNum=" + PhoneNum;
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
        
        class NotRenewDaysData
        {
            public static string Post(string url, string PhoneNum)
            {
                string para = "PhoneNum=" + PhoneNum;
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
        class UpdateRenewData
        {
            public static string Post(string url, string BookId,string PhoneNum)
            {
                string para = "BookId=" + BookId+"&PhoneNum="+PhoneNum;
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
            public string ImageUrl { get; set; }


        }
        class ReturnCheck
        {
            public string BookId { get; set; }
            public string BorrowDate { get; set; }
            public string ReturnFlag { get; set; }
            public string PhoneNum { get; set; }
            public string IfRenew { get; set; }
     
        }

        class BookDetailData
        {
            public static string Post(string url, string BookClassId)
            {
                string postString = "BookClassId=" + BookClassId;
                byte[] postData = Encoding.UTF8.GetBytes(postString);
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] responseData = webClient.UploadData(url, "POST", postData);
                string srcString = Encoding.UTF8.GetString(responseData);

                return srcString;

            }
        }
        class ThisBook
        {
            public string PhoneNum { get; set; }
            public string BookId { get; set; }
        }

        class QueryId
        {
            public string BookId { get; set; }
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