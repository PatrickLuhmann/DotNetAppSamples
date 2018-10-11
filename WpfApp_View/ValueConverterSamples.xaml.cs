using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
using ViewModels;

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

		private void clickIncrease_Button(object sender, RoutedEventArgs e)
		{
			((ValueConverter_VM)DataContext).Increase();
		}

		private void clickDecrease_Button(object sender, RoutedEventArgs e)
		{
			((ValueConverter_VM)DataContext).Decrease();
		}
	}
}
