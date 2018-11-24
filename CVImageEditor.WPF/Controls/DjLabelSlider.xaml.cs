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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CVImageEditor.WPF.Controls
{
	/// <summary>
	/// Interaction logic for DjLabelSlider.xaml
	/// </summary>
	public partial class DjLabelSlider : UserControl
	{
		#region PROPS
		public string LabelText
		{
			get { return (string)GetValue(LabelTextProperty); }
			set { SetValue(LabelTextProperty, value); }
		}

		public double SliderMinValue
		{
			get { return (double)GetValue(SliderMinValueProperty); }
			set { SetValue(SliderMinValueProperty, value); }
		}
		public double SliderMaxValue
		{
			get { return (double)GetValue(SliderMaxValueProperty); }
			set { SetValue(SliderMaxValueProperty, value); }
		}
		public double SliderIncrementValue
		{
			get { return (double)GetValue(SliderIncrementValueProperty); }
			set { SetValue(SliderIncrementValueProperty, value); }
		}
		public double SliderValue
		{
			get { return (double)GetValue(SliderValueProperty); }
			set { SetValue(SliderValueProperty, value);}
		}

		public ICommand SliderValueChanged
		{
			get { return (ICommand)GetValue(SliderValueChangedProperty); }
			set { SetValue(SliderValueChangedProperty, value); }
		}
		#endregion

		#region DEPS
		public static readonly DependencyProperty LabelTextProperty =
			DependencyProperty.Register("LabelText", typeof(string), typeof(DjLabelSlider), new PropertyMetadata("Example Text"));
		public static readonly DependencyProperty SliderMinValueProperty =
			DependencyProperty.Register("SliderMinValue", typeof(double), typeof(DjLabelSlider), new PropertyMetadata(0.0));
		public static readonly DependencyProperty SliderMaxValueProperty =
			DependencyProperty.Register("SliderMaxValue", typeof(double), typeof(DjLabelSlider), new PropertyMetadata(100.0));
		public static readonly DependencyProperty SliderIncrementValueProperty =
			DependencyProperty.Register("SliderIncrementValue", typeof(double), typeof(DjLabelSlider), new PropertyMetadata(1.0));
		public static readonly DependencyProperty SliderValueProperty =
			DependencyProperty.Register("SliderValue", typeof(double), typeof(DjLabelSlider), new PropertyMetadata(0.0));
		public static readonly DependencyProperty SliderValueChangedProperty = 
			DependencyProperty.Register("SliderValueChanged", typeof(ICommand), typeof(DjLabelSlider), new PropertyMetadata(null));
		#endregion

		public DjLabelSlider()
		{
			InitializeComponent();
		}
	}
}
