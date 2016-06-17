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
using Android.Support.V4.View;
using BookBasketList;

namespace MiniLibrary
{
    [Activity(Label = "Index", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Index : Activity
    {
        private ImageView Scan;
        private ImageView Search;
        private ImageButton Type1;
        private ImageButton Type2;
        private ImageButton Type3;
        private ImageButton Type4;
        private ImageButton Type5;
        private ImageButton Type6;
        private LinearLayout TabIndexLayout;
        private EditText searchEdit;

        private List<BookBasketListInfo> BookInfo;
        private ListView BookList;
        private TextView PhoneNum;

        private LinearLayout PersonalSetting;
        
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
            Scan = FindViewById<ImageView>(Resource.Id.TabIndeximScan);
            Search = FindViewById<ImageView>(Resource.Id.TabIndeximSearch);
            Type1 = FindViewById<ImageButton>(Resource.Id.type1);
            Type2 = FindViewById<ImageButton>(Resource.Id.type2);
            Type3 = FindViewById<ImageButton>(Resource.Id.type3);
            Type4 = FindViewById<ImageButton>(Resource.Id.type4);
            Type5 = FindViewById<ImageButton>(Resource.Id.type5);
            Type6 = FindViewById<ImageButton>(Resource.Id.type6);
            TabIndexLayout = FindViewById<LinearLayout>(Resource.Id.TabIndexLayout);
            searchEdit = FindViewById<EditText>(Resource.Id.TabIndexEditSearch);

            Scan.SetImageResource(Resource.Drawable.IconScan);
            Search.SetImageResource(Resource.Drawable.IconSearch);

            Type1.Click += delegate
            {
                Intent ActList = new Intent(this, typeof(BookListView));
                StartActivity(ActList);
            };
            TabIndexLayout.Click += delegate
            {
                Android.Views.InputMethods.InputMethodManager imm = (Android.Views.InputMethods.InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(searchEdit.WindowToken, 0);
            };
        }

        private void TabBookBasket()
        {
            BookList = FindViewById<ListView>(Resource.Id.TabBookBasketList);
            BookInfo = new List<BookBasketListInfo>();
            BookInfo.Add(new BookBasketListInfo { Title = "百年孤独", Image = "http://cover1.bookday.cn/73/52/9787544253994.jpg" ,BookNumber="111"});
            BookInfo.Add(new BookBasketListInfo { Title = "123",Image= "http://cover1.bookday.cn/73/52/9787544253994.jpg",BookNumber="222" });
            BookList.Adapter = new BookBasketListAdapter(this, BookInfo);

        }

        private void TabPrivate()
        {
            PhoneNum = FindViewById<TextView>(Resource.Id.TabTextPhoneNum);
            PersonalSetting = FindViewById<LinearLayout>(Resource.Id.TablayoutPersonSetting);
            ISharedPreferences LoginSP = GetSharedPreferences("LoginData", FileCreationMode.Private);
            PhoneNum.Text = LoginSP.GetString("PhoneNum", "");
            PersonalSetting.Click += delegate
            {
                Intent ActPersonSetting = new Intent(this, typeof(PersonalSetting));
                StartActivity(ActPersonSetting);
            };
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {

            if (keyCode == Keycode.Back)
            {
                return true;
            }
            return false;
        }

    }
}