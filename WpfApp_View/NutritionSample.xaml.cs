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
using ViewModels;

namespace WpfApp_View
{
    /// <summary>
    /// Interaction logic for NutritionSample.xaml
    /// </summary>
    public partial class NutritionSample : Window
    {
        public NutritionSample()
        {
            InitializeComponent();
        }

		private void clickAddFoodItem_Button(object sender, RoutedEventArgs e)
		{
			// TODO: Pop up an input window here.

			((Nutrition_VM)DataContext).AddFoodItem();
		}
	}
}
