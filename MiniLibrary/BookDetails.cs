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
                //�Ի���
                var Dialog = new AlertDialog.Builder(this);

                //�Ի�������
                Dialog.SetMessage("ȷ�Ͻ��Ĵ���?");

                //ȷ�ϰ�ť
                Dialog.SetNeutralButton("ȷ��", delegate
                {
                    Toast.MakeText(this, "���ĳɹ���", ToastLength.Short).Show();
                });

                //ȡ����ť
                Dialog.SetNegativeButton("ȡ��", delegate { });

                //��ʾ�Ի���
                Dialog.Show();
            };
            collectionButton.Click += (s, e) =>
            {
                //�Ի���
                var Dialog = new AlertDialog.Builder(this);

                //�Ի�������
                Dialog.SetMessage("ȷ�Ͻ��������������");

                //����ť
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
                    Toast.MakeText(this, "��ȡ��Ԥ����", ToastLength.Short).Show();
                });

                //��ʾ�Ի���
                Dialog.Show();
            };

        }
    }
}