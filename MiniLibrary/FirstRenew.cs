using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;



namespace MiniLibrary
{
    [Activity(Label = "FirstRenew", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class FirstRenew : Activity          //ListActivity
    {
       // private TextView text;
       // private ListView listView;
        //protected string[] items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            //SetContentView(Resource.Layout.FirstRenew);
            // listView = new ListView(this);
            /* text = FindViewById<TextView>(Resource.Id.Renewapplication);
              listView = FindViewById<ListView>(Resource.Id.Renewalapplication);
              items = new string[]{
                 "First","Second","Third"
            };
              ListAdapter = new ArrayAdapter<String>(this, Resource.Layout.FirstListItemF, items);*/
            SetContentView(Resource.Layout.FirstRenew);
            //ListView.setAdapter(new ArrayAdapter<String>(this,Android.Resource.Layout.FirstListItemF, items));
            //setContentView(listView);
            /*ArrayList<HashMap<String, String>> mylist = new ArrayList<HashMap<String, String>>();
            for (int i = 0; i < 30; i++)
            {
                HashMap<String, String> map = new HashMap<String, String>();
                map.put("ItemTitle", "This is Title.....");
                map.put("ItemText", "This is text.....");
                mylist.add(map);
            }
            //生成适配器，数组===》ListItem  
            SimpleAdapter mSchedule = new SimpleAdapter(this, //没什么解释  
                                                        mylist,//数据来源   
                                                        Resource.Layout.my_listitem,//ListItem的XML实现  

                                                        //动态数组与ListItem对应的子项          
                                                        new String[] { "ItemTitle", "ItemText" },

                                                        //ListItem的XML文件里面的两个TextView ID  
                                                        new int[] { Resource.Id.ItemTitle, Resource.Id.ItemText });
            //添加并且显示  
            listView.setAdapter(mSchedule);*/
        }
    }
}