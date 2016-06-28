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

            TextView bookSummary = FindViewById<TextView>(Resource.Id.textView_BookSummary); //���ݸ�Ҫ
            TextView bookCatalog = FindViewById<TextView>(Resource.Id.textView_BookCatalog); //����Ŀ¼
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
            string PhoneNum = LoginSP.GetString("PhoneNum", null); //��ȡ�绰����
           
            string thebookClassId=Intent.GetStringExtra("BookClassId");

           
            
            string PersonTotalBookResult = PersonalTotalBookData.Post("http://115.159.145.115/PersonalTotalBook.php/", PhoneNum);
            //�����˽��������Ƿ񳬹��涨
            string personaltotalbooknumber = PersonTotalBookResult;

            string RenewDaysResult = RenewDaysData.Post("http://115.159.145.115/RenewDays.php/", PhoneNum);
            //�������������Ƿ����
            string renewdays = RenewDaysResult;

            string NotRenewDaysResult = NotRenewDaysData.Post("http://115.159.145.115/NotRenewDays.php/", PhoneNum);
             //���δ��������Ƿ����
            string notrenewdays = NotRenewDaysResult;

            string result = BookDetailData.Post("http://115.159.145.115/BookDetail.php/", thebookClassId);
            var book = JsonConvert.DeserializeObject<BookClass>(result); //����������
            string result1 = BookDetailData.Post("http://115.159.145.115/ReturnCheck.php/", thebookClassId);
            var returncheck= JsonConvert.DeserializeObject<List<ReturnCheck>>(result1); //��������Ϣ

            if(personaltotalbooknumber!=null)
            {
                int thetotalbooknumber = 0;
                int.TryParse(personaltotalbooknumber, out thetotalbooknumber);
                if(thetotalbooknumber >= 0 && thetotalbooknumber < 10)
                {
                    //���Ϲ涨�����Խ���
                    totalbooknumber2 = true;
                }
                else
                {
                    //���ܽ���
                    totalbooknumber2 = false;
                }
            }
            if(renewdays!=null)
            {
                int therenewdays = 0;
                int.TryParse(renewdays, out therenewdays);
                if(therenewdays>=0 && therenewdays<=20)
                {
                    //���Ϲ涨�����Խ���
                    renewdays3 = true;
                }
                else
                {
                    //�����������ڣ����ܽ���
                    renewdays3 = false;
                }
            }
            else
            {
                //���Խ���
                renewdays3 = true;
            }
            if(notrenewdays!=null)
            {
                int thenotrenewdays = 0;
                int.TryParse(notrenewdays, out thenotrenewdays);
                if(thenotrenewdays>=0 && thenotrenewdays<=10)
                {
                    //���Խ���
                    notrenewdays4 = true;
                }
                else
                {
                    //����δ�������ܽ���
                    notrenewdays4 = false;
                }
            }
            else
            {
                //���Խ���
                notrenewdays4 = true;
            }
            int judgePhoneNum = 0;
            int judge = 1; //�жϸ������Ƿ񱻽���
            int judgeRenew = 0; //�ж��Ǳ����Ƿ�����
            if (returncheck.Count == 0)
            {
                //�޷���BookID
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
                        //���Խ���
                        returncheck5 = true;

                    }
                    else if (a.PhoneNum == PhoneNum && a.ReturnFlag == "0")
                    {
                        if (a.IfRenew == "0")
                        {
                            judgeRenew = 0; //����û�б�����
                        }
                        else
                        {
                            judgeRenew = 1; //�����Ѿ�������
                        }
                        updateBookId = a.BookId;
                        returncheck5 = false;
                        judgePhoneNum = 1;
                        //���������
                    }
                    else
                    {
                        //�ֲ����Խ裬�ֲ����Ի�
                        //�������Ѿ�������
                        judge = 0;
                    }
                }
            }
            

            bookAuthor.Text = book.BookAuthor; //���⣺����
            bookName.Text = book.BookName; //���⣺����
            bookSummary.Text = book.BookSummary;//Tab1:���ݸ�Ҫ
            bookCatalog.Text = book.BookCatalog;//Tab2:����Ŀ¼
            bookClassId.Text = "ISBN ��"+book.BookClassId;
            bookPrice.Text = "��  ��"+book.BookPrice;
            bookPress.Text = "�����磺"+book.BookPress;
            bookClassification.Text = "��  �ࣺ"+book.BookClassification;
            Picasso.With(this).Load(book.ImageUrl).Into(FindViewById<ImageView>(Resource.Id.imageView_bookImage));

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

            if (returncheck5==false && judgePhoneNum==1)
            {
                borrowButton.Text = "����";
                borrowButton.Click += (s, e) =>
                {
                    var Dialog = new AlertDialog.Builder(this);
                    Dialog.SetMessage("ȷ��Ҫ������?");
                    Dialog.SetNeutralButton("ȷ��", delegate
                    {
                        ThisBook thisbook = new ThisBook();
                        thisbook.BookId = updateBookId;
                        thisbook.PhoneNum = PhoneNum;
                        var ReturnJson = JsonConvert.SerializeObject(thisbook);
                        Intent intent = new Intent(this, typeof(ReturnReader));
                        intent.PutExtra("ReturnBook", "["+ReturnJson+"]");
                        StartActivity(intent);
                    });
                    Dialog.SetNegativeButton("ȡ��", delegate { });
                    Dialog.Show();
                };
                if (judgeRenew == 0) //û�б�����
                {
                    collectionButton.Text = "����";
                    collectionButton.Click += (s, e) =>
                      {
                          var Dialog = new AlertDialog.Builder(this);
                          Dialog.SetMessage("ȷ��������飿");
                          Dialog.SetNeutralButton("ȷ��", delegate
                           {
                               string theupdatesuccess = UpdateRenewData.Post("http://115.159.145.115/Renew.php/", updateBookId,PhoneNum);
                               
                           if (theupdatesuccess == "success")
                               {
                                   Toast.MakeText(this, "����ɹ���", ToastLength.Short).Show();
                                   collectionButton.Enabled = false;
                               }
                               else
                               {
                                   Toast.MakeText(this, "��Ǹ������ʧ�ܣ�", ToastLength.Short).Show();
                               }
                           });
                          Dialog.SetNegativeButton("ȡ��", delegate { });
                          Dialog.Show();
                      };
                }
                else if(judgeRenew == 1)
                {
                    collectionButton.Text = "����";
                    collectionButton.Enabled = false;
                    Toast.MakeText(this, "����������飬�޷��ٴ����裡", ToastLength.Short).Show();
                }
            }
            else if(judge==1&&totalbooknumber2==true && renewdays3==true && notrenewdays4==true && returncheck5==true)
            {
                borrowButton.Text = "����";

                borrowButton.Click += (s, e) =>
                {
                var Dialog = new AlertDialog.Builder(this);
                Dialog.SetMessage("ȷ�Ͻ��Ĵ���?");
                Dialog.SetNeutralButton("ȷ��", delegate
                    {
                        ThisBook thisbook = new ThisBook();
                        thisbook.BookId = updateBookId;
                        thisbook.PhoneNum = PhoneNum;
                        var ReturnJson = JsonConvert.SerializeObject(thisbook);
                        Intent ActLogin = new Intent(this, typeof(BorrowReader));

                        ActLogin.PutExtra("BorrowInfo", "["+ReturnJson+"]");
                        StartActivity(ActLogin);
                    });
                Dialog.SetNegativeButton("ȡ��", delegate { });
                Dialog.Show();
                };
                collectionButton.Text = "��������";
                if (AddToBookBasketData.Post("http://115.159.145.115/IfInBookBasket.php/",PhoneNum, book.BookClassId) != "NotIn")
                {
                    collectionButton.Enabled = false;
                }
                collectionButton.Click += (s, e) =>
                {
                    
                    var Dialog = new AlertDialog.Builder(this);
                    Dialog.SetMessage("ȷ�Ͻ��������������");
                    Dialog.SetNeutralButton("ȷ��", delegate
                    {
                        string res = AddToBookBasketData.Post("http://115.159.145.115/AddToBookBasket.php", PhoneNum, book.BookClassId);
                        if (res == "Success")
                        {
                            Toast.MakeText(this, "�ɹ�����������", ToastLength.Short).Show();
                            collectionButton.Enabled = false;
                        }
                    });
                    Dialog.SetNegativeButton("ȡ��", delegate { });
                    Dialog.Show();
                };
            }
            else if(judge==0)
            {
                borrowButton.Text = "����";
                collectionButton.Text = "��������";
                borrowButton.Enabled = false;
                collectionButton.Enabled = false;
                Toast.MakeText(this, "��Ǹ���������Ѿ������꣡���޷����Ĵ��飡", ToastLength.Short).Show();
            }
            else if(totalbooknumber2==false)
            {
                borrowButton.Text = "����";
                collectionButton.Text = "��������";
                borrowButton.Enabled = false;
                collectionButton.Enabled = false;
                Toast.MakeText(this, "��Ǹ�����Ľ����鱾��������ʮ�������޷����Ĵ��飡", ToastLength.Short).Show();
            }
            else if(renewdays3==false)
            {
                borrowButton.Text = "����";
                collectionButton.Text = "��������";
                borrowButton.Enabled = false;
                collectionButton.Enabled = false;
                Toast.MakeText(this, "��Ǹ����������ͼ�鳬��δ�������޷����Ĵ��飡", ToastLength.Short).Show();
            }
            else if(notrenewdays4==false)
            {
                borrowButton.Text = "����";
                collectionButton.Text = "��������";
                borrowButton.Enabled = false;
                collectionButton.Enabled = false;
                Toast.MakeText(this, "��Ǹ�����н���ͼ�鳬��δ�������޷����Ĵ��飡", ToastLength.Short).Show();
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