using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace UnitTest_Models
{
	[TestClass]
	public class UnitTest_Nutrition
	{
		[TestMethod]
		public void AddFoodItem()
		{
			// TODO: See if there is a better place for this.
			// TODO: Will this change if/when there is a New File command?
			using (var db = new NutritionContext())
			{
				db.Database.Migrate();
			}
		}
	}
}
