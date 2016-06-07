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
using Android.OS;
using Android.Views.Animations;
using Android.Graphics;
using Android.Telephony;
using System.Text.RegularExpressions;

namespace MiniLibrary
{
    public class FirstADScanF : Android.Support.V4.App.Fragment
    {
        ZXingScannerFragment scanFragment;
        View zxingOverlay;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup p1, Bundle p2)
        {
            return inflater.Inflate(Resource.Layout.Scanner, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            zxingOverlay = LayoutInflater.FromContext(this.Activity).Inflate(Resource.Layout.ZxingOverlay, null);

            scanFragment = new ZXingScannerFragment(ScanResultCallback);
            scanFragment.UseCustomView = true;
            scanFragment.CustomOverlayView = zxingOverlay;

            this.Activity.SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.fragment_container, scanFragment)
                .Commit();
        }

        private void ScanResultCallback(ZXing.Result result)
        {
            if (result == null || string.IsNullOrEmpty(result.Text))
            {
                this.Activity.RunOnUiThread(() =>
                {
                    Toast.MakeText(this.Activity, "ɨ����ȡ����", ToastLength.Short).Show();
                    ((HomeFragment)this.FragmentManager.Fragments[0]).SetCurrentTab("Main");
                });
                return;
            }
            else
            {
                //ɨ��ɹ�  ż��ɨ��������һ������???
                this.Activity.RunOnUiThread(() =>
                {
                    //��
                    Vibrator vibrator = (Vibrator)Application.Context.GetSystemService(Context.VibratorService);
                    long[] pattern = { 0, 350, 220, 350 };
                    vibrator.Vibrate(pattern, -1);

                    Console.WriteLine(result.Text);

                    //�˴����϶�ά��ĸ�ʽҪ�����������Ҫ�󣬾ͼ���ɨ�裨���������ж��Ƿ����ֻ����룩
                    if (IsTelephone(result.Text))
                    {
                        //�����ر�����ͷ����ֹ�ظ�ɨ��
                        scanFragment.Shutdown();

                        Toast.MakeText(this.Activity, result.Text, ToastLength.Short).Show();
                        ((HomeFragment)this.FragmentManager.Fragments[0]).SetCurrentTab("Main");
                    }
                    else
                    {
                        Toast.MakeText(this.Activity, "ɨ��Ķ�ά���ʽ����ȷ��", ToastLength.Short).Show();
                    }
                });
                return;
            }
        }

        /// <summary>
        /// ��֤�ֻ�����ĸ�ʽ
        /// </summary>
        public bool IsTelephone(string str_telephone)
        {
            return Regex.IsMatch(str_telephone, @"^(0|86|17951)?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$");
        }
    } 
}