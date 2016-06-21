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
using System.Text.RegularExpressions;

namespace MiniLibrary
{
    [Activity(Label = "RealName", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class RealName : Activity
    {
        EditText name;
        EditText id;
        Button submit;
        AlertDialog.Builder builder;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RealName);

            builder = new AlertDialog.Builder(this);
            name = FindViewById<EditText>(Resource.Id.RealNameEditName);
            id = FindViewById<EditText>(Resource.Id.RealNameEditID);
            submit = FindViewById<Button>(Resource.Id.RealNamebtnSubmit);

            submit.Click += Submit_Click;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (id.Text.Length != 18 || !Regex.IsMatch(id.Text, @"^[+-]?\d*$"))
            {
                Toast.MakeText(this, "��������ȷ�����֤���룡", ToastLength.Short).Show();
            }
            else if(id.Text==""||name.Text=="")
            {
                Toast.MakeText(this, "��Ϣ������Ϊ�գ�", ToastLength.Short).Show();
            }
            else
            {
                
                builder.SetMessage("ʵ����֤��Ϣһ���ύ֮�󲻿��޸ģ�");
                builder.SetTitle("��ʾ");
                builder.SetPositiveButton("ȷ��", OK);
                builder.SetNegativeButton("ȡ��", delegate { });
                builder.SetCancelable(true);
                builder.Show();
            }
        }
        private void OK(object sender,EventArgs e)
        {
            Intent ActSuccess = new Intent(this, typeof(RealNameSuccess));
            StartActivity(ActSuccess);
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {

            if (keyCode == Keycode.Back)
            {
                Intent ActSetting = new Intent(this, typeof(PersonalSetting));
                StartActivity(ActSetting);
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
    }
}