using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using ZXing.Mobile;
using System.Text.RegularExpressions;
namespace MiniLibrary
{
    public class FirstADMainF : Android.Support.V4.App.Fragment
    {
        MobileBarcodeScanner scanner;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup p1, Bundle p2)
        {
            return inflater.Inflate(Resource.Layout.FirstAdmin, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            scanner = new MobileBarcodeScanner();

            this.View.FindViewById<Button>(Resource.Id.textViewBorrowB).Click += btnDefault_Click;
            this.View.FindViewById<Button>(Resource.Id.textViewReturnB).Click += btnCustom_Click;
        }

        async void btnDefault_Click(object sender, EventArgs e)
        {
            //不使用自定义界面
            scanner.UseCustomOverlay = false;

            //设置上下提示文字
            scanner.TopText = "上面的文字";
            scanner.BottomText = "下面的文字";

            var result = await scanner.Scan();

            HandleScanResult(result);
        }

        async void btnCustom_Click(object sender, EventArgs e)
        {
            View zxingOverlay;
            //使用自定义界面（可以给框内加个动画什么的，这个自由发挥）
            scanner.UseCustomOverlay = true;
            zxingOverlay = LayoutInflater.FromContext(this.Activity).Inflate(Resource.Layout.ZxingOverlay, null);
            scanner.CustomOverlay = zxingOverlay;

            var result = await scanner.Scan();

            HandleScanResult(result);
        }

        void HandleScanResult(ZXing.Result result)
        {
            if (result == null || string.IsNullOrEmpty(result.Text))
            {
                this.Activity.RunOnUiThread(() =>
                {
                    Toast.MakeText(this.Activity, "扫描已取消！", ToastLength.Short).Show();
                });
                return;
            }
            else
            {
                //扫描成功 偶尔扫描结果会是一串数字???
                this.Activity.RunOnUiThread(() =>
                {
                    Toast.MakeText(this.Activity, result.Text, ToastLength.Short).Show();
                });
            }
        }
    }
}