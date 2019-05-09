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

namespace WpfApp_View
{
	/// <summary>
	/// Interaction logic for StyleSample.xaml
	/// </summary>
	public partial class StyleSample : UserControl
	{
		public StyleSample()
		{
			InitializeComponent();
		}
	}

	// TODO: Can this code-behind go somewhere else? Or is this something the ViewModel should not know about
	//       because it is specific to this particular View implementation? Or extract to separate file?
	public class NegativeColorSelector : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			// Getting at the properties of 'value' takes a couple of steps.
			int itemValue1 = (int)value;

			if (itemValue1 < 0)
				return "Red";
			else
				return "Black";
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException("ConvertBack not supported");
		}
	}

	public class NegativeTextSelector : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value.GetType().Name == typeof(int).Name)
			{
				int itemValue1 = (int)value;

				if (itemValue1 < 0)
					return "(" + (itemValue1 * -1).ToString() + ")";
				else
					return itemValue1.ToString();
			}
			else if (value.GetType().Name == typeof(decimal).Name)
			{
				decimal val = (decimal)value;
				if (val < 0.0M)
					return "(" + (val * -1).ToString() + ")";
				else
					return val.ToString();
			}
			else if (value.GetType().Name == typeof(float).Name)
			{
				float val = (float)value;
				if (val < 0.0f)
					return "(" + (val * -1).ToString() + ")";
				else
					return val.ToString();
			}

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException("ConvertBack not supported");
		}
	}

}
