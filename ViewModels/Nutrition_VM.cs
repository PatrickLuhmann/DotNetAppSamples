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
	public class Nutrition_VM : ViewModelBase
	{
		public string GreetingMessage { get; private set; }
		public ObservableCollection<FoodItem_VM> FoodItems { get; set; }

		public void AddFoodItem()
		{
			// TODO: Replace this test code.
			FoodItem food = new FoodItem();
			food.Name = "Whole Grain Penne";
			food.Brand = "Barilla";
			food.ServingSize = 56;
			food.ServingUnit = "g";
			food.TotalFat = 1.5M;
			food.TotalCarbs = 39;

			using (var db = new NutritionContext())
			{
				db.FoodItems.Add(food);
				db.SaveChanges();
			}
		}

		public Nutrition_VM()
		{
			GreetingMessage = "Welcome to the Nutrition database sample. Enjoy your stay.";


			// TODO: See if there is a better place for this.
			// TODO: Will this change if/when there is a New File command?
			using (var db = new NutritionContext())
			{
				db.Database.Migrate();
			}

			using (var db = new NutritionContext())
			{
				ObservableCollection<FoodItem_VM> items = new ObservableCollection<FoodItem_VM>();
				List<FoodItem> res = db.FoodItems.ToList();
				foreach (FoodItem fi in res)
				{
					items.Add(new FoodItem_VM { TheFoodItem = fi });
				}
				FoodItems = items;
				RaisePropertyChanged("FoodItems");
			}
		}
	}
}
