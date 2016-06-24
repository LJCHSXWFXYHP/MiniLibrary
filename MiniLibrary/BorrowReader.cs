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
using System.IO;
using System.Net;
using Newtonsoft.Json;



namespace MiniLibrary
{
    [Activity(Label = "BorrowReader", WindowSoftInputMode = SoftInput.StateHidden | SoftInput.AdjustUnspecified, Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class BorrowReader : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            //tent intent =
            Bundle bundle = Intent.GetBundleExtra("bundle");
            string bookClassid = bundle.GetString("bookclassid");
            SetContentView(Resource.Layout.BorrowReader);
            ImageView barcode = FindViewById<ImageView>(Resource.Id.BarCode);

            string result = BarCodeData.Post("http://115.159.145.115/BookDetail.php/", "1");
            var book = JsonConvert.DeserializeObject<BookRecord>(result);

            string bookid = book.BookId;
            string borrowdate = book.BorrowDate;
            string returnflag = book.ReturnFlag;
            string phonenum = book.PhoneNum;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(bookid);
            sb.Append(borrowdate);
            sb.Append(returnflag);
            sb.Append(phonenum);
            string str = sb.ToString();
            Bitmap bmp = GeneratorQrImage(str);
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
        class BookRecord
        {
            public string BookId { get; set; }
            public string BorrowDate { get; set; }
            public string ReturnFlag { get; set; }
            public string PhoneNum { get; set; }
        }
        class BarCodeData
        {
            public static string Post(string url, string BookClassId)
            {
                string para = "BookClassId=" + BookClassId;
                HttpWebRequest httpWeb = (HttpWebRequest)WebRequest.Create(url);
                httpWeb.Timeout = 20000;
                httpWeb.Method = "POST";
                httpWeb.ContentType = "application/x-www-form-urlencoded";
                byte[] bytePara = Encoding.ASCII.GetBytes(para);
                using (Stream reqStream = httpWeb.GetRequestStream())
                {
                    reqStream.Write(bytePara, 0, para.Length);
                }
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWeb.GetResponse();
                Stream stream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
                string result = streamReader.ReadToEnd();
                stream.Close();

                return result;

            }
        }
    }
}