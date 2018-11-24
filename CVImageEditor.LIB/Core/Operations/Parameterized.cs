using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVImageEditor.LIB.Core.Operations
{
	public class Parameterized
	{
		public static Mat AdaptiveThresholdImage(Mat image, int blockSize, int c)
		{
			Mat result = new Mat();
			Cv2.AdaptiveThreshold(image, result, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, blockSize, c);
			return result;
		}
	}
}
