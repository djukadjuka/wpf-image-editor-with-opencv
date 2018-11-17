using CVImageEditor.WPF.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CVImageEditor.WPF.Model
{
    public class MainWindowVM : BaseModel
    {

        #region PROPS

        #endregion

        #region PROPFULLS

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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".jpg";
            openFileDialog.InitialDirectory = @"D:\Suckhead\WORKSPACES\C#\CVImageEditor\__Assets\Images";
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";

            bool? result = openFileDialog.ShowDialog();
            if(result == true)
            {
                string filename = openFileDialog.FileName;
                MessageBox.Show(filename);
            }
        }

        #endregion
    }
}
