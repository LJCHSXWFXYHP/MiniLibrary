using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using ZXing;
using ZXing.Common;



namespace MiniLibrary
{
    [Activity(Label = "BorrowReader", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class BorrowReader : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.BorrowReader);
            ImageView barcode = FindViewById<ImageView>(Resource.Id.BarCode);
            Bitmap bmp = GeneratorQrImage("232443545454");
            barcode.SetImageBitmap(bmp);

        }
        private Bitmap GeneratorQrImage(string contents)
        {
            MultiFormatWriter mutiWriter = new MultiFormatWriter();
            BitMatrix matrix = mutiWriter.encode(contents, BarcodeFormat.QR_CODE, 300, 300);
            int width = matrix.Width;
            int height = matrix.Height;
            //二维矩阵转为一维像素数组,也就是一直横着排了  
            int[] pixels = new int[width * height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (matrix[x, y])
                    {
                        pixels[y * width + x] = System.BitConverter.ToInt32(System.BitConverter.GetBytes(0xff000000), 0); ;
                    }

                }
            }

            Bitmap bitmap = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
            //通过像素数组生成bitmap,具体参考api  
            bitmap.SetPixels(pixels, 0, width, 0, 0, width, height);
            return bitmap;
        }

    }
}