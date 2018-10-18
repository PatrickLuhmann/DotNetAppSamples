using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Reflection;
using System.Windows.Media;
using System.Linq;
using GalaSoft.MvvmLight;
using Models;
using Microsoft.EntityFrameworkCore;

namespace ViewModels
{
	public class MainWindow_VM : ViewModelBase
	{
		public MainWindow_VM()
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
