using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu;
using Emgu.CV;

namespace CVImageEditor.LIB.Core
{
    public class Sandbox
    {
        public static void Run()
        {
            string imagePath = @"D:\Suckhead\WORKSPACES\C#\CVImageEditor\__Assets\Images\moja-slika.jpg";
            Mat targetImage = CvInvoke.Imread(imagePath);
            CvInvoke.Imshow("img", targetImage);
            CvInvoke.WaitKey();
            CvInvoke.DestroyAllWindows();
        }
    }
}
