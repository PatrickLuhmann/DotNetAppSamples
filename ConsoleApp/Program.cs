using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the DotNetAppSamples console app!");
			// TODO: See if there is a better place for this.
			// TODO: Will this change if/when there is a New File command?
			using (var db = new NutritionContext())
			{
				db.Database.Migrate();
			}
		}
	}
}
