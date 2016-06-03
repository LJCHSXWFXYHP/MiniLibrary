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

            
        }
    }
}