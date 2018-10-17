using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class NutritionContext : DbContext
    {
		public DbSet<FoodItem> FoodItems { get; set; }
		public DbSet<RecipeLine> RecipeLines { get; set; }
		public DbSet<Recipe> Recipes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// The path is relative to the main assembly (.exe).
			optionsBuilder.UseSqlite(@"Data Source=nutrition.db");

			// I don't know why I need this. For some reason doing the Migration
			// from Nutrition_VM() throws an exception. Research led me to
			// https://stackoverflow.com/questions/40412992/cannot-run-sqlite-net-pcl-in-asp-net-mvc
			// which had the following line as a possible solution.
			// UnitTest_Models works fine without it, and I can't find any difference between
			// the references of the two projects. The only thing I can think of is that
			// I think I tried installing NuGet package Microsoft.EntityFrameworkCore instead
			// of MS.EFC.Sqlite, thinking that the ViewModel didn't need all of the packages. I
			// then added Sqlite but that apparently had no effect.
			Batteries.Init();
		}
	}

	public class FoodItem
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public string Brand { get; set; }

		public decimal ServingSize { get; set; }
		public string ServingUnit { get; set; }

		public decimal TotalFat { get; set; }
		public decimal SaturatedFat { get; set; }
		public decimal TransFat { get; set; }
		public decimal Cholesterol { get; set; }
		public decimal Sodium { get; set; }
		public decimal TotalCarbs { get; set; }
		public decimal DietaryFiber { get; set; }
		public decimal SolubleFiber { get; set; }
		public decimal InsolubleFiber { get; set; }
		public decimal Sugar { get; set; }
		public decimal Protein { get; set; }
	}

	public class RecipeLine
	{
		public int Id { get; set; }

		//public int FoodItemId { get; set; }
		public decimal Quantity { get; set; }
		public string QuantityUnit { get; set; }

		public FoodItem FoodItem { get; set; }
	}

	public class Recipe
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public int Servings { get; set; }

		public List<RecipeLine> RecipeLines { get; set; }
	}
}
