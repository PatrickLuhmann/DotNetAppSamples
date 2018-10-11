﻿using System;
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

namespace WpfApp_View
{
    /// <summary>
    /// Interaction logic for StyleSamples.xaml
    /// </summary>
    public partial class StyleSamples : Window
    {
        public StyleSamples()
        {
            InitializeComponent();
        }
    }

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
			// Getting at the properties of 'value' takes a couple of steps.
			int itemValue1 = (int)value;

			if (itemValue1 < 0)
				return "(" + (itemValue1 * -1).ToString() + ")";
			else
				return itemValue1.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException("ConvertBack not supported");
		}
	}
}