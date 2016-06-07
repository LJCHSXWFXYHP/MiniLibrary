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
            tab.Setup();

            TabHost.TabSpec spec1 = tab.NewTabSpec("tab1");
            spec1.SetContent(Resource.Id.layoutWriter);
            spec1.SetIndicator("作者介绍");

            TabHost.TabSpec spec2 = tab.NewTabSpec("tab2");
            spec2.SetContent(Resource.Id.layoutIntroduction);
            spec2.SetIndicator("书本介绍");

            TabHost.TabSpec spec3 = tab.NewTabSpec("tab3");
            spec3.SetContent(Resource.Id.layoutEvaluate);
            spec3.SetIndicator("本书简评");

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
                        Intent ActLogin = new Intent(this, typeof(BorrowReader));
                        StartActivity(ActLogin);
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

                //拨打按钮
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
    }
}