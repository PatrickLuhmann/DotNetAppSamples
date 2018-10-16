using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
	public class StyleSample_VM : ViewModelBase
	{
		private ObservableCollection<int> theList;
		public ObservableCollection<int> TheList {
			get {
				return theList;
			}
		}

		public string SomeText { get; set; }

		public StyleSample_VM()
		{
			theList = new ObservableCollection<int>();
			theList.Add(1);
			theList.Add(0);
			theList.Add(-1);

			SomeText = "Hello world";
		}
	}
}
