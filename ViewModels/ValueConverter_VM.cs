﻿using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Reflection;
using System.Windows.Media;
using System.Linq;
using GalaSoft.MvvmLight;

namespace ViewModels
{
	public class ValueConverter_VM : ViewModelBase
	{
		private ObservableCollection<TwoInts> listOurData;
		public ObservableCollection<TwoInts> ListOurData
		{
			get { return listOurData; }
			set { listOurData = value; }
		}

		public void Increase()
		{
			listOurData[0].Value1++;
			RaisePropertyChanged("ListOurData");
		}

		public void Decrease()
		{
			listOurData[0].Value1--;
			RaisePropertyChanged("ListOurData");
		}

		public ValueConverter_VM()
		{
			listOurData = new ObservableCollection<TwoInts>();
			listOurData.Add(new TwoInts { Value1 = 1, Value2 = 2, Index = 0 });
			listOurData.Add(new TwoInts { Value1 = 29, Value2 = 69, Index = 1 });
			listOurData.Add(new TwoInts { Value1 = 3, Value2 = 0, Index = 2 });
		}
	}

	public class TwoInts : INotifyPropertyChanged
	{
		private int value1;
		public int Value1
		{
			get { return value1; }
			set
			{
				value1 = value;
				NotifyPropertyChanged();
			}
		}

		private int value2;
		public int Value2
		{
			get { return value2; }
			set
			{
				value2 = value;
				NotifyPropertyChanged();
			}
		}

		public int Index { get; set; }
		public string Color { get { return "Red"; } }

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}

	// TODO: Should Converters be in the ViewModel? IValueConverter is in System.Windows.Data
	// so it is meant to be with the GUI code, and the ViewModel is not meant to know about the GUI.
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

	public class MyTwoIntsDiffColorSelector : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			// Getting at the properties of 'value' takes a couple of steps.
			int itemValue1 = (int)value.GetType().GetProperty("Value1").GetValue(value, null);
			int itemValue2 = (int)value.GetType().GetProperty("Value2").GetValue(value, null);

			if (itemValue1 <= itemValue2)
				return "LightGoldenrodYellow";
			else
				return "LightBlue";
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return -1;
		}
	}

	public class MySimple18Converter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return "18";
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return -1;
		}
	}

	public class MyMultiAdder : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			System.Diagnostics.Debug.WriteLine("This is MyMultiAdder.Convert");
			System.Diagnostics.Debug.WriteLine("Number of values: " + values.Count());
			System.Diagnostics.Debug.WriteLine("value[0] Type: " + values[0].GetType().Name);
			System.Diagnostics.Debug.WriteLine("value[1] Type: " + values[1].GetType().Name);
			System.Diagnostics.Debug.WriteLine("parameter: " + ((parameter != null) ? parameter.ToString() : "<null>"));
			System.Diagnostics.Debug.WriteLine("parameter Type: " + ((parameter != null) ? parameter.GetType().Name : "<null>"));

			// I should really have separate converters for different functions, but this
			// is good enough for a sample.
			if (values[0].GetType().Name == typeof(TwoInts).Name)
			{
				int val1 = (int)values[0].GetType().GetProperty("Value1").GetValue(values[0], null);
				int val2 = (int)values[0].GetType().GetProperty("Value2").GetValue(values[0], null);
				if (((val1 + val2) & 0x1) == 1)
					return Brushes.Green;
				else
					return Brushes.Red;
			}
			else if (values[0].GetType().Name == typeof(ObservableCollection<>).Name)
			{
				int val1 = (int)values[1].GetType().GetProperty("Value1").GetValue(values[1], null);
				int val2 = (int)values[1].GetType().GetProperty("Value2").GetValue(values[1], null);
				return (val1 + val2).ToString();
			}
			return 0;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class MyMultiBackgroundConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			System.Diagnostics.Debug.WriteLine("This is MyMultiBackgroundConverter.Convert");
			System.Diagnostics.Debug.WriteLine("Number of values: " + values.Count());
			System.Diagnostics.Debug.WriteLine("value[0] Type: " + values[0].GetType().Name);
			//System.Diagnostics.Debug.WriteLine("value[1] Type: " + values[1].GetType().Name);
			System.Diagnostics.Debug.WriteLine("parameter: " + ((parameter != null) ? parameter.ToString() : "<null>"));
			System.Diagnostics.Debug.WriteLine("parameter Type: " + ((parameter != null) ? parameter.GetType().Name : "<null>"));

			if (values[0].GetType().Name == typeof(TwoInts).Name)
			{
				int val1 = (int)values[0].GetType().GetProperty("Value1").GetValue(values[0], null);
				int val2 = (int)values[0].GetType().GetProperty("Value2").GetValue(values[0], null);

				if (val1 <= val2)
					return Brushes.LightGoldenrodYellow;
				else
					return Brushes.LightBlue;
			}
#if false
			if (values[1].GetType().Name == typeof(ObservableCollection<>).Name)
			{
				int myIdx = (int)values[0].GetType().GetProperty("Index").GetValue(values[0], null);
				System.Diagnostics.Debug.WriteLine("  My index is: {0}", myIdx);

				int accum = 0;
				ObservableCollection<TwoInts> theList = (ObservableCollection<TwoInts>)values[1];
				for (int i = 0; i < theList.Count; i++)
				{
					accum += theList[i].Value2;
					if (i == myIdx)
						break;
				}

				//return accum.ToString();
				if ((myIdx & 0x1) == 1)
					return Brushes.Gray;
				else
					return Brushes.Cyan;
			}
#endif
#if false
			string one = values[0] as string;
			string two = values[1] as string;
			string three = values[2] as string;
			if (!string.IsNullOrEmpty(one) && !string.IsNullOrEmpty(two) && !string.IsNullOrEmpty(three))
			{
				return one + two + three;
			}
			return null;
#endif
			return Brushes.Blue;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

}
