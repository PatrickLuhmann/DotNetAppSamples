using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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

namespace WpfApp_View
{
	/// <summary>
	/// Interaction logic for ValueConverterSamples.xaml
	/// </summary>
	public partial class ValueConverterSamples : Window
	{
		public ValueConverterSamples()
		{
			InitializeComponent();
		}
	}

	public class ValueConverter_ViewModel
	{
		private ObservableCollection<TwoInts> listOurData;
		public ObservableCollection<TwoInts> ListOurData { get { return listOurData; } }

		public ValueConverter_ViewModel()
		{
			listOurData = new ObservableCollection<TwoInts>();
			listOurData.Add(new TwoInts { Value1 = 1, Value2 = 2, Index = 0 });
			listOurData.Add(new TwoInts { Value1 = 29, Value2 = 69, Index = 1 });
		}
	}

	public class TwoInts
	{
		public int Value1 { get; set; }
		public int Value2 { get; set; }
		public int Index { get; set; }
		public string Color { get { return "Red"; } }
	}

	public class MyTwoIntsAdder : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			// Getting at the properties of 'value' takes a couple of steps.
			Type itemType = value.GetType();
			PropertyInfo itemPropInfo = itemType.GetProperty("Value1");
			int itemValue1 = (int)itemPropInfo.GetValue(value, null);

			int itemValue2 = (int)value.GetType().GetProperty("Value2").GetValue(value, null);

			return itemValue1 + itemValue2;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return -1;
		}
	}

	public class MyTwoIntsColorSelector : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			// Getting at the properties of 'value' takes a couple of steps.
			Type itemType = value.GetType();
			PropertyInfo itemPropInfo = itemType.GetProperty("Value1");
			int itemValue1 = (int)itemPropInfo.GetValue(value, null);

			int itemValue2 = (int)value.GetType().GetProperty("Value2").GetValue(value, null);

			if (((itemValue1 + itemValue2) & 0x1) == 1)
				return "Green";
			else
				return "Red";
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return -1;
		}
	}
}
