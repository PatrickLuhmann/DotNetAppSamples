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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void clickValueConverterSamples_Button(object sender, RoutedEventArgs e)
		{
			var wnd = new ValueConverterSamples();
			wnd.Show();
		}

		private void clickCommandSamples_Button(object sender, RoutedEventArgs e)
		{
			var wnd = new CommandSamples();
			wnd.Show();
		}

		private void clickNutritionSample_Button(object sender, RoutedEventArgs e)
		{
			var wnd = new NutritionSample();
			wnd.Show();
		}
	}
}
