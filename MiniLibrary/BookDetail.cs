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
            spec1.SetIndicator("���߽���");

            TabHost.TabSpec spec2 = tab.NewTabSpec("tab2");
            spec2.SetContent(Resource.Id.layoutIntroduction);
            spec2.SetIndicator("�鱾����");

            TabHost.TabSpec spec3 = tab.NewTabSpec("tab3");
            spec3.SetContent(Resource.Id.layoutEvaluate);
            spec3.SetIndicator("�������");

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
                        Intent ActLogin = new Intent(this, typeof(BorrowReader));
                        StartActivity(ActLogin);
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
                });

                //��ʾ�Ի���
                Dialog.Show();
            };


        }
    }
}