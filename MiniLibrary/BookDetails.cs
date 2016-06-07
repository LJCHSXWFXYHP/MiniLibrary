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
using ZXing;
using System.Collections;
namespace MiniLibrary
{
    public class QR
    {

    }
    [Activity(Label = "BookDetails", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class BookDetails : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.BookDetails);
            Button borrowButton = FindViewById<Button>(Resource.Id.borrow);
            Button reserveButton = FindViewById<Button>(Resource.Id.reserve);
            Button collectionButton = FindViewById<Button>(Resource.Id.collection);
            borrowButton.Click += (s, e) =>
            {
                //对话框
                var Dialog = new AlertDialog.Builder(this);

                //对话框内容
                Dialog.SetMessage("确认借阅此书?");

                //确认按钮
                Dialog.SetNeutralButton("确认", delegate
                {
                    Toast.MakeText(this, "借阅成功！", ToastLength.Short).Show();
                });

                //取消按钮
                Dialog.SetNegativeButton("取消", delegate { });

                //显示对话框
                Dialog.Show();
            };
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
                    Toast.MakeText(this, "已取消预订！", ToastLength.Short).Show();
                });

                //显示对话框
                Dialog.Show();
            };

        }
    }
}