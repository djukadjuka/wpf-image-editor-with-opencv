using CVImageEditor.WPF.Commands;
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

namespace CVImageEditor.WPF.Model
{
    public class MainWindowVM : BaseModel
    {

        #region PROPS
        public Bitmap MainImage { get; set; }
        public Mat MainImageMat { get; set; }

        #endregion

        #region PROPFULLS
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
            
            // TODO: use path to load image here
            MainImageMat = new Mat(filename);
            MainImage = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(MainImageMat);
            MainImageSource = LIB.Core.ImageUtilities.CreateImageSourceFromImage(MainImage);
        }

        #endregion
    }
}
