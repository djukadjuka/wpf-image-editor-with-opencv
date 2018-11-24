using CVImageEditor.WPF.ViewModels;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CVImageEditor.WPF.Windows
{
    /// <summary>
    /// Interaction logic for ThresholdingDialog.xaml
    /// </summary>
    public partial class ThresholdingDialog : System.Windows.Window
    {
        public ThresholdingDialog(Mat targetImage)
        {
            InitializeComponent();
            this.DataContext = new ThresholdingDialogVM(targetImage);
        }
    }
}
