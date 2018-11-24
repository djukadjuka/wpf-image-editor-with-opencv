using CVImageEditor.WPF.Model;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        #endregion

        #region CTORS
        public ThresholdingDialogVM(Mat image)
        {
            ParentImage = image;
            TargetImage = ParentImage.Clone();
        }
        #endregion

        #region METHODS

        #endregion

    }
}
