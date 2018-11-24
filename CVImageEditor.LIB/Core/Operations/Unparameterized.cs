using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVImageEditor.LIB.Core.Operations
{
    public class Unparameterized
    {
        public static Mat GrayscaleImage(Mat image)
        {
            Mat grayscale = new Mat();
            Cv2.CvtColor(image, grayscale, ColorConversionCodes.BGR2GRAY);
            return grayscale;
        }
    }
}
