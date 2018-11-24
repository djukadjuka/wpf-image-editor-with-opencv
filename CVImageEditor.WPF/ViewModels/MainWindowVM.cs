using CVImageEditor.WPF.Commands;
using CVImageEditor.WPF.Model;
using CVImageEditor.WPF.Windows;
using Microsoft.Win32;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CVImageEditor.WPF.ViewModels
{
    public class MainWindowVM : BaseModel
    {

        #region PROPS

        public bool ImageExists { get => MainImageMat != null; }
        #endregion

        #region PROPFULLS
        private Mat _mainImageMat;
        public Mat MainImageMat
        {
            get
            {
                return _mainImageMat;
            }
            set
            {
                _mainImageMat = value;
                MainImageSource = LIB.Core.ImageUtilities.CreateImageSourceFromMat(_mainImageMat);
            }
        }
        
        private ImageSource _mainImageSource;
        public ImageSource MainImageSource
        {
            get
            {
                return _mainImageSource;
            }
            set
            {
                _mainImageSource = value;
                OnPropertyChanged("MainImageSource");
                OnPropertyChanged("ImageExists");
            }
        }

        #endregion

        #region CTORS

        #endregion

        #region METHODS
        private ICommand _openImageCommand;
        public ICommand OpenImageCommand
        {
            get
            {
                if(_openImageCommand == null)
                {
                    _openImageCommand = new RelayCommand((x) => true, (x) => OpenImageCommandFunction());
                }
                return _openImageCommand;
            }
        }
        public void OpenImageCommandFunction()
        {
            // setup
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".jpg";
            openFileDialog.InitialDirectory = @"D:\Suckhead\WORKSPACES\C#\CVImageEditor\__Assets\Images";
            openFileDialog.Filter = "BMP Files (*.bmp)|*.bmp|JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";

            // handle if image does not exist or other errors
            bool? result = openFileDialog.ShowDialog();
            string filename = "";
            if(result != true)
            {
                MessageBox.Show("Error");
                return;
            }
            filename = openFileDialog.FileName;
            
            MainImageMat = new Mat(filename);
        }

        private ICommand _grayscaleCommand;
        public ICommand GrayscaleCommand
        {
            get
            {
                if(_grayscaleCommand == null)
                {
                    _grayscaleCommand = new RelayCommand(x => GrayscaleCommandFunction());
                }
                return _grayscaleCommand;
            }
        }
        public void GrayscaleCommandFunction()
        {
            MainImageMat = LIB.Core.Operations.Unparameterized.GrayscaleImage(MainImageMat);
        }

        private ICommand _thresholdingCommand;
        public ICommand ThresholdingCommand
        {
            get
            {
                if(_thresholdingCommand == null)
                {
                    _thresholdingCommand = new RelayCommand(x => ThresholdingCommandFunction());
                }
                return _thresholdingCommand;
            }
        }
        public void ThresholdingCommandFunction()
        {
            if(MainImageMat.Channels() != 1)
            {
                MessageBox.Show("Image must be grayscaled first");
                return;
            }
            ThresholdingDialog thresholdingDialog = new ThresholdingDialog(MainImageMat);
            thresholdingDialog.ShowDialog();
        }
        #endregion
    }
}
