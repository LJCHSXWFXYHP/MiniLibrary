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


namespace MiniLibrary
{
    [Activity(Label = "Index", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Index : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Index);

            TabHost tab = FindViewById<TabHost>(Resource.Id.tabHost1);
            tab.Setup();

            TabHost.TabSpec spec1 = tab.NewTabSpec("��ҳ");
            spec1.SetContent(Resource.Id.layoutIndex);
            spec1.SetIndicator("��ҳ");

            TabHost.TabSpec spec2 = tab.NewTabSpec("����");
            spec2.SetContent(Resource.Id.layoutBookbasket);
            spec2.SetIndicator("����");

            TabHost.TabSpec spec3 = tab.NewTabSpec("��������");
            spec3.SetContent(Resource.Id.layoutPrivate);
            spec3.SetIndicator("��������");

            tab.AddTab(spec1);
            tab.AddTab(spec2);
            tab.AddTab(spec3);

            
        }
    }
}