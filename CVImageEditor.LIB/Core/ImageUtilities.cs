using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CVImageEditor.LIB.Core
{
    public class ImageUtilities
    {
        public static ImageSource CreateImageSourceFromImage(Image image)
        {
            byte[] byteArray;
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                stream.Close();

                byteArray = stream.ToArray();
            }

            return (ImageSource)new ImageSourceConverter().ConvertFrom(byteArray);
        }
    }
}
