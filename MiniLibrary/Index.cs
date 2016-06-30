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
using Android.Support.V4.App;
using Android.Support.V4.View;
using BookBasketList;
using Newtonsoft.Json;
using ZXing.Mobile;
using Square.Picasso;

namespace MiniLibrary
{
    [Activity(Label = "Index", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Index : Activity
    {
        private class BookClass
        {
            public string BookClassId { get; set; }
            public string BookId { get; set; }
            public string BookName { get; set; }
            public string BookAuthor { get; set; }
            public string ImageUrl { get; set; }
        }
        private class Book
        {
            public string BookId { get; set; }
            public string ReturnFlag { get; set; }
        }
        private class BorrowList
        {
            public string BookId { get; set; }
            public string PhoneNum { get; set; }
        }

        private ViewPager Advp;
        private ImageView ad1;
        private ImageView ad2;
        private ImageView ad3;
        private ImageView Scan;
        private ImageView Search;
        private ImageView Type1;
        private ImageView Type2;
        private ImageView Type3;
        private ImageView Type4;
        private ImageView Type5;
        private ImageView Type6;
        private ImageView Type7;
        private ImageView Type8;
        private ImageView Type9;
        private LinearLayout TabIndexLayout;
        private EditText searchEdit;
        private MobileBarcodeScanner scanner;

        private List<BookBasketListInfo> BookInfo;
        private ListView BookList;
        private TextView PhoneNum;
        private Button BorrowAll;

        private LinearLayout MyBook;
        private LinearLayout MyBookAll;
        private LinearLayout PersonalSetting;
        private ImageView more;

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Index);

            TabHost tab = FindViewById<TabHost>(Resource.Id.tabHost1);
            tab.Setup();

            TabHost.TabSpec spec1 = tab.NewTabSpec("主页");
            spec1.SetContent(Resource.Id.layoutIndex);
            spec1.SetIndicator("主页");

            TabHost.TabSpec spec2 = tab.NewTabSpec("书篮");
            spec2.SetContent(Resource.Id.layoutBookbasket);
            spec2.SetIndicator("书篮");

            TabHost.TabSpec spec3 = tab.NewTabSpec("个人中心");
            spec3.SetContent(Resource.Id.layoutPrivate);
            spec3.SetIndicator("个人中心");

            tab.AddTab(spec1);
            tab.AddTab(spec2);
            tab.AddTab(spec3);

            TabBookBasket();
            TabIndex();
            TabPrivate();

        }

        private void TabIndex()
        {

            Advp = FindViewById<ViewPager>(Resource.Id.viewpager);
            
            Scan = FindViewById<ImageView>(Resource.Id.TabIndeximScan);
            Search = FindViewById<ImageView>(Resource.Id.TabIndeximSearch);
            Type1 = FindViewById<ImageView>(Resource.Id.type1);
            Type2 = FindViewById<ImageView>(Resource.Id.type2);
            Type3 = FindViewById<ImageView>(Resource.Id.type3);
            Type4 = FindViewById<ImageView>(Resource.Id.type4);
            Type5 = FindViewById<ImageView>(Resource.Id.type5);
            Type6 = FindViewById<ImageView>(Resource.Id.type6);
            Type7 = FindViewById<ImageView>(Resource.Id.type7);
            Type8 = FindViewById<ImageView>(Resource.Id.type8);
            Type9 = FindViewById<ImageView>(Resource.Id.type9);
            TabIndexLayout = FindViewById<LinearLayout>(Resource.Id.TabIndexLayout);
            searchEdit = FindViewById<EditText>(Resource.Id.TabIndexEditSearch);

            Scan.SetImageResource(Resource.Drawable.IconScan);
            Search.SetImageResource(Resource.Drawable.IconSearch);

            Type1.SetImageResource(Resource.Drawable.IndexIcon_1);
            Type2.SetImageResource(Resource.Drawable.IndexIcon_8);
            Type3.SetImageResource(Resource.Drawable.IndexIcon_7);
            Type4.SetImageResource(Resource.Drawable.IndexIcon_5);
            Type5.SetImageResource(Resource.Drawable.IndexIcon_9);
            Type6.SetImageResource(Resource.Drawable.IndexIcon_2);
            Type7.SetImageResource(Resource.Drawable.IndexIcon_4);
            Type8.SetImageResource(Resource.Drawable.IndexIcon_3);
            Type9.SetImageResource(Resource.Drawable.IndexIcon_6);

            View v1, v2, v3;
            List<View> viewList;
            ViewPagerAdapter AdvpAdapter;
            var li = LayoutInflater.From(this);
            v1 = li.Inflate(Resource.Layout.ViewPager_1, null);
            v2 = li.Inflate(Resource.Layout.ViewPager_2, null);
            v3 = li.Inflate(Resource.Layout.ViewPager_3, null);
            viewList = new List<View>();
            viewList.Add(v1);
            viewList.Add(v2);
            viewList.Add(v3);
            ad1 = v1.FindViewById<ImageView>(Resource.Id.Vpimage_1);
            ad2 = v2.FindViewById<ImageView>(Resource.Id.Vpimage_2);
            ad3 = v3.FindViewById<ImageView>(Resource.Id.Vpimage_3);
            Picasso.With(this).Load("http://115.159.145.115/ads/ad1.png").Into(ad1);
            Picasso.With(this).Load("http://115.159.145.115/ads/ad2.png").Into(ad2);
            Picasso.With(this).Load("http://115.159.145.115/ads/ad3.png").Into(ad3);
            AdvpAdapter = new ViewPagerAdapter(viewList);
            Advp.Adapter = AdvpAdapter;

            MobileBarcodeScanner.Initialize(Application);
            scanner = new MobileBarcodeScanner();

            Button flashButton;
            View zxingOverlay;
            Scan.Click += async delegate {
                scanner.UseCustomOverlay = true;

                //Inflate our custom overlay from a resource layout
                zxingOverlay = LayoutInflater.FromContext(this).Inflate(Resource.Layout.Scanning, null);

                //Find the button from our resource layout and wire up the click event
                flashButton = zxingOverlay.FindViewById<Button>(Resource.Id.buttonZxingFlash);
                flashButton.Click += (sender, e) => scanner.ToggleTorch();

                //Set our custom overlay
                scanner.CustomOverlay = zxingOverlay;

                //Start scanning!
                var result = await scanner.Scan();

                HandleScanResult(result);
            };
            Search.Click += delegate
            {
                if (searchEdit.Text != "")
                {
                    Intent ActBookList = new Intent(this, typeof(BookListView));
                    Bundle bundle = new Bundle();
                    ActBookList.PutExtra("SearchInfo", searchEdit.Text);
                    ActBookList.PutExtras(bundle);
                    StartActivity(ActBookList);
                                                            
                }
            };

            Type1.Click += delegate
            {
                Intent ActList = new Intent(this, typeof(BookListView_type));
                Bundle bundle = new Bundle();
                ActList.PutExtra("SearchType", "计算机");
                ActList.PutExtra("SearchInfo", "");
                ActList.PutExtras(bundle);
                StartActivity(ActList);
            };
            Type2.Click += delegate
            {
                Intent ActList = new Intent(this, typeof(BookListView_type));
                Bundle bundle = new Bundle();
                ActList.PutExtra("SearchType", "文学");
                ActList.PutExtra("SearchInfo", "");
                ActList.PutExtras(bundle);
                StartActivity(ActList);
            };
            Type3.Click += delegate
            {
                Intent ActList = new Intent(this, typeof(BookListView_type));
                Bundle bundle = new Bundle();
                ActList.PutExtra("SearchType", "社会科学");
                ActList.PutExtra("SearchInfo", "");
                ActList.PutExtras(bundle);
                StartActivity(ActList);
            };
            Type4.Click += delegate
            {
                Intent ActList = new Intent(this, typeof(BookListView_type));
                Bundle bundle = new Bundle();
                ActList.PutExtra("SearchType", "历史");
                ActList.PutExtra("SearchInfo", "");
                ActList.PutExtras(bundle);
                StartActivity(ActList);
            };
            Type5.Click += delegate
            {
                Intent ActList = new Intent(this, typeof(BookListView_type));
                Bundle bundle = new Bundle();
                ActList.PutExtra("SearchType", "文化");
                ActList.PutExtra("SearchInfo", "");
                ActList.PutExtras(bundle);
                StartActivity(ActList);
            };
            Type6.Click += delegate
            {
                Intent ActList = new Intent(this, typeof(BookListView_type));
                Bundle bundle = new Bundle();
                ActList.PutExtra("SearchType", "教材");
                ActList.PutExtra("SearchInfo", "");
                ActList.PutExtras(bundle);
                StartActivity(ActList);
            };
            Type7.Click += delegate
            {
                Intent ActList = new Intent(this, typeof(BookListView_type));
                Bundle bundle = new Bundle();
                ActList.PutExtra("SearchType", "科普");
                ActList.PutExtra("SearchInfo", "");
                ActList.PutExtras(bundle);
                StartActivity(ActList);
            };
            Type8.Click += delegate
            {
                Intent ActList = new Intent(this, typeof(BookListView_type));
                Bundle bundle = new Bundle();
                ActList.PutExtra("SearchType", "经济");
                ActList.PutExtra("SearchInfo", "");
                ActList.PutExtras(bundle);
                StartActivity(ActList);
            };
            Type9.Click += delegate
            {
                Intent ActList = new Intent(this, typeof(BookListView_type));
                Bundle bundle = new Bundle();
                ActList.PutExtra("SearchType", "其他");
                ActList.PutExtra("SearchInfo", "");
                ActList.PutExtras(bundle);
                StartActivity(ActList);
            };
            
            TabIndexLayout.Click += delegate
            {
                Android.Views.InputMethods.InputMethodManager imm = (Android.Views.InputMethods.InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(searchEdit.WindowToken, 0);
            };
        }

        void HandleScanResult(ZXing.Result result)
        {
            string msg = "";

            if (result != null && !string.IsNullOrEmpty(result.Text))
                msg = result.Text;
            else
                msg = "-1";


            RunOnUiThread(() =>
            {
                if (msg != "-1")
                {
                    Intent ActBookList = new Intent(this, typeof(BookListView));
                    ActBookList.PutExtra("SearchInfo", msg);
                    StartActivity(ActBookList);
                }
                else
                {
                    Toast.MakeText(this, "扫描取消", ToastLength.Short).Show();
                }
            });
        }


        private void TabBookBasket()
        {
            BookList = FindViewById<ListView>(Resource.Id.TabBookBasketList);
            BorrowAll = FindViewById<Button>(Resource.Id.BorrowAll);

            BookInfo = new List<BookBasketListInfo>();
            ISharedPreferences LoginSP = GetSharedPreferences("LoginData", FileCreationMode.Private);
            string SearchResult = SearchData.Post("http://115.159.145.115/BookBasket.php", LoginSP.GetString("PhoneNum",""));
            var ResultList = JsonConvert.DeserializeObject<List<BookClass>>(SearchResult);
            foreach (BookClass b in ResultList)
            {
                BookInfo.Add(new BookBasketListInfo { Title = b.BookName, Image = b.ImageUrl, BookAuthor = b.BookAuthor, BookClassId = b.BookClassId ,PhoneNum= LoginSP.GetString("PhoneNum", "") });
            }
            BookList.Adapter = new BookBasketListAdapter(this, BookInfo);

            BookList.ItemClick += BookList_ItemClick;

            BorrowAll.Click +=delegate{

                string res = BorrowData.Post("http://115.159.145.115/BorrowCheck.php", LoginSP.GetString("PhoneNum", ""), BookInfo.Count);
                string days = SearchData.Post("http://115.159.145.115/NotRenewDays.php", LoginSP.GetString("PhoneNum", ""));
                if (int.Parse(days) < 10)
                {
                    if (res == "Success")
                    {
                        List<BorrowList> borrowList = new List<BorrowList>();
                        foreach (BookBasketListInfo b in BookInfo)
                        {
                            string AllocResult = BorrowData.Post("http://115.159.145.115/AllocateBookId.php/", b.BookClassId);
                            var AllocResultList = JsonConvert.DeserializeObject<List<Book>>(AllocResult);
                            foreach (Book c in AllocResultList)
                            {
                                if (c.ReturnFlag == null || c.ReturnFlag == "1")
                                {
                                    borrowList.Add(new BorrowList { BookId = c.BookId, PhoneNum = LoginSP.GetString("PhoneNum", "") });
                                    break;
                                }
                            }

                        }

                        if (borrowList.Count != 0)
                        {
                            var BorrowJson = JsonConvert.SerializeObject(borrowList);
                            Intent ActBorrowReader = new Intent(this, typeof(BorrowReader));
                            ActBorrowReader.PutExtra("BorrowInfo", BorrowJson);
                            StartActivity(ActBorrowReader);
                        }
                    }
                    else if (res == "Fail")
                    {
                        Toast.MakeText(this, "一个人最多借十本书哦！", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "您有图书超过十天没有归还，请续借或者归还后再借书！", ToastLength.Long).Show();
                }
            };

        }

        private void BookList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent ActBookDetail = new Intent(this, typeof(BookDetail));
            ActBookDetail.PutExtra("BookClassId", BookInfo[e.Position].BookClassId);
            StartActivity(ActBookDetail);
        }

        private void TabPrivate()
        {
            MyBook = FindViewById<LinearLayout>(Resource.Id.TablayoutMyBook);
            MyBookAll = FindViewById<LinearLayout>(Resource.Id.TablayoutMyBookAll);
            PhoneNum = FindViewById<TextView>(Resource.Id.TabTextPhoneNum);
            PersonalSetting = FindViewById<LinearLayout>(Resource.Id.TablayoutPersonSetting);
            more = FindViewById<ImageView>(Resource.Id.TabPrivateMore);

            more.SetImageResource(Resource.Drawable.IconMore);

            more.Click += delegate
            {
                PopupMenu menu = new PopupMenu(this, more);
                menu.Inflate(Resource.Menu.MoreMenu);
                menu.Show();
                menu.MenuItemClick += Menu_MenuItemClick;

            };

            MyBook.Click += delegate
            {
                Intent ActMyBookList = new Intent(this, typeof(BookListView_MyBook));
                ActMyBookList.PutExtra("flag", "MyBook");
                StartActivity(ActMyBookList);
            };
            MyBookAll.Click += delegate
            {
                Intent ActMyBookList = new Intent(this, typeof(BookListView_MyBook));
                ActMyBookList.PutExtra("flag", "MyBookAll");
                StartActivity(ActMyBookList);
            };


            
            ISharedPreferences LoginSP = GetSharedPreferences("LoginData", FileCreationMode.Private);

            PhoneNum.Text = LoginSP.GetString("PhoneNum", "");
            PersonalSetting.Click += delegate
            {
                Intent ActPersonSetting = new Intent(this, typeof(PersonalSetting));
                StartActivity(ActPersonSetting);
            };
        }

        private void Menu_MenuItemClick(object sender, PopupMenu.MenuItemClickEventArgs e)
        {
            if (e.Item.ItemId == Resource.Id.Logout)
            {
                Intent ActLogin = new Intent(this, typeof(Login));
                StartActivity(ActLogin);
                Finish();
            }
            else if(e.Item.ItemId==Resource.Id.about)
            {
                Toast.MakeText(this, "林静晨 杨昊澎 王福超 黄世贤", ToastLength.Long).Show();
            }
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {

            if (keyCode == Keycode.Back)
            {
                return true;
            }
            return false;
        }

        internal class ViewPagerAdapter : PagerAdapter
        {
            private readonly List<View> viewLists;
            public override bool IsViewFromObject(View view, Java.Lang.Object objectValue)
            {
                return view == objectValue;
            }
            public ViewPagerAdapter(List<View> _viewList)
            {
                viewLists = _viewList;
            }
            public override int Count
            {
                get
                {
                    return viewLists.Count();
                }
            }
            public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
            {
                container.AddView(viewLists[position]);
                return viewLists[position];
            }
            public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object objectValue)
            {
                container.RemoveView(viewLists[position]);
            }
        }

        public class SearchData
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

        public class BorrowData
        {
            public static string Post(string url, string PhoneNum,int count)
            {
                string postString = "PhoneNum=" + PhoneNum+"&count="+count;
                byte[] postData = Encoding.UTF8.GetBytes(postString);
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] responseData = webClient.UploadData(url, "POST", postData);
                string srcString = Encoding.UTF8.GetString(responseData);

                return srcString;

            }

            public static string Post(string url, string BookCLassId)
            {
                string postString = "BookClassId=" + BookCLassId;
                byte[] postData = Encoding.UTF8.GetBytes(postString);
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] responseData = webClient.UploadData(url, "POST", postData);
                string srcString = Encoding.UTF8.GetString(responseData);

                return srcString;

            }
        }

        
    }
}