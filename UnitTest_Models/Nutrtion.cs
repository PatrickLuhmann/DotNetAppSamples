using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace UnitTest_Models
{
	[TestClass]
	public class Nutrtion
	{
		[ClassInitialize]
		public static void CreateAndMigrateDatabase(TestContext context)
		{
			System.IO.File.Delete("nutrition.db");
			using (var db = new NutritionContext())
			{
				db.Database.Migrate();
			}
		}

		[TestMethod]
		public void AddFoodItem()
		{
			FoodItem food = new FoodItem();
			food.Name = "Whole Grain Penne";
			food.Brand = "Barilla";
			food.ServingSize = 56;
			food.ServingUnit = "g";
			food.TotalFat = 1.5M;
			food.TotalCarbs = 39;

			int count = -1;
			using (var db = new NutritionContext())
			{
				db.FoodItems.Add(food);
				count = db.SaveChanges();
			}

			Assert.AreEqual(1, count);

			List<FoodItem> items;
			using (var db = new NutritionContext())
			{
				items = db.FoodItems.Where(fi => fi.Brand == "Barilla").ToList();
			}
			Assert.AreEqual(1, items.Count);
			Assert.AreEqual("Whole Grain Penne", items[0].Name);
		}
	}
}
