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
    
    [Activity(Label = "RegisterSuccess",Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class RegisterSuccess : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RegisterSuccess);
            
        }
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            
            if (keyCode == Keycode.Back)
            {
                Intent ActRegsc = new Intent(this, typeof(Login));
                StartActivity(ActRegsc);
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
    }

}