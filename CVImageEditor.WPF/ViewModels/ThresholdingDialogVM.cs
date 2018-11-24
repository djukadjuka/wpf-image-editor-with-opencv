using CVImageEditor.WPF.Commands;
using CVImageEditor.WPF.Model;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace CVImageEditor.WPF.ViewModels
{
    public class ThresholdingDialogVM : BaseModel
    {

        #region PROPS

        #endregion

        #region PROPFULLS

        private Mat _parentImage;
        public Mat ParentImage
        {
            get
            {
                return _parentImage;
            }
            set
            {
                _parentImage = value;
                OnPropertyChanged("ParentImage");
            }
        }
        
        private Mat _targetImage;
        public Mat TargetImage
        {
            get
            {
                return _targetImage;
            }
            set
            {
                _targetImage = value;
                OnPropertyChanged("TargetImage");
                TargetImageSource = LIB.Core.ImageUtilities.CreateImageSourceFromMat(_targetImage);
            }
        }


        private ImageSource _targetImageSource;
        public ImageSource TargetImageSource
        {
            get
            {
                return _targetImageSource;
            }
            set
            {
                _targetImageSource = value;
                OnPropertyChanged("TargetImageSource");
            }
        }
		
		private double _c;
		public double C
		{
			get
			{
				return _c;
			}
			set
			{
				_c = value;
				OnPropertyChanged("C");
			}
		}
		
		private double _blockSize;
		public double BlockSize
		{
			get
			{
				return _blockSize;
			}
			set
			{
				_blockSize = value;
				OnPropertyChanged("BlockSize");
			}
		}
		
		#endregion

		#region CTORS
		public ThresholdingDialogVM(Mat image)
        {
			_blockSize = 3;
			_c = 0;
            ParentImage = image;
            TargetImage = ParentImage.Clone();
        }
		#endregion

		#region METHODS
		private ICommand _adaptiveThreshold;
		public ICommand AdaptiveThreshold
		{
			get
			{
				if(_adaptiveThreshold == null)
				{
					_adaptiveThreshold = new RelayCommand(x => AdaptiveThresholdFunction());
				}
				return _adaptiveThreshold;
			}
		}
		private void AdaptiveThresholdFunction()
		{
			TargetImage = LIB.Core.Operations.Parameterized.AdaptiveThresholdImage(ParentImage, (int)BlockSize, (int)C);
		}

		#endregion
	}
}
