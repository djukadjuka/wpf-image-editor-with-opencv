using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CVImageEditor.LIB.Core
{
    public class ImageUtilities
    {
        public static ImageSource CreateImageSourceFromMat(Mat image)
        {
            Bitmap bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
            byte[] byteArray;
            using(MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Bmp);
                stream.Close();

                byteArray = stream.ToArray();
            }

            return (ImageSource)new ImageSourceConverter().ConvertFrom(byteArray);
        }
    }
}
