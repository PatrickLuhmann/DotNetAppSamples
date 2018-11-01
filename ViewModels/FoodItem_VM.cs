using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
	public class FoodItem_VM : ViewModelBase
	{
		public FoodItem TheFoodItem { get; set; }

		public FoodItem_VM()
		{
			// TODO: The WPF EF sample creates an "entity" here,
			// says it is so insert does not fail. What do I do?
		}
	}
}
