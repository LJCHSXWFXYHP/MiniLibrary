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

using Android.Support.V4.App;
using Java.Lang;
namespace MiniLibrary
{
    public class HomeFragment : Android.Support.V4.App.Fragment
    {
        private FragmentTabHost mTabHost;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup p1, Bundle p2)
        {
            return inflater.Inflate(Resource.Layout.FirstADHome, null);
        }
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            this.InitTabs();
        }
        private void InitTabs()
        {
            mTabHost = this.View.FindViewById<FragmentTabHost>(Android.Resource.Id.TabHost);
            mTabHost.Setup(this.Activity, this.Activity.SupportFragmentManager, Resource.Id.realtabcontent);

            TabHost.TabSpec tabSpec1 = this.SetIndicator(mTabHost.NewTabSpec("FirstADScanner"), "ɨһɨ");
            mTabHost.AddTab(tabSpec1, Class.FromType(typeof(FirstADScanF)), null);
            TabHost.TabSpec tabSpec2 = this.SetIndicator(mTabHost.NewTabSpec("FirstADMain"), "��������");
            mTabHost.AddTab(tabSpec2, Class.FromType(typeof(FirstADMainF)), null);
        }
        public TabHost.TabSpec SetIndicator(TabHost.TabSpec tabSpec, string text)
        {
            var view = LayoutInflater.FromContext(Application.Context).Inflate(Resource.Layout.FirstADTabInd, null);
            view.FindViewById<TextView>(Resource.Id.Text).Text = text;
            return tabSpec.SetIndicator(view);
        }
        public void SetCurrentTab(string currentTag)
        {
            if (mTabHost != null)
            {
                mTabHost.SetCurrentTabByTag(currentTag);
            }
        }
    }
}