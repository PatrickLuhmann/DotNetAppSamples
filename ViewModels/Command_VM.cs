using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModels
{
	public class Command_VM : ViewModelBase
	{
		private string buttonOne;
		public string ButtonOne
		{
			get { return buttonOne; }
			set
			{
				buttonOne = value;
				RaisePropertyChanged("ButtonOne");
			}
		}

		public ICommand ButtonOneACmd { get { return new ButtonOneACommand(); } }
		public ICommand ButtonOneBCmd { get { return new ButtonOneBCommand(); } }

		public Command_VM()
		{
			ButtonOne = "Click the buttons";
		}
	}

	public class ButtonOneACommand : ICommand
	{
		public bool CanExecute(object parameter)
		{
			// I tried making sure that parameter is a Command_VM
			// but it is only ever null.
			return true;
		}

		// TODO: What is this meant to be used for?
		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
			Command_VM cvm = (Command_VM)parameter;
			if (cvm != null)
				cvm.ButtonOne = "Hello World";
		}
	}

	public class ButtonOneBCommand : ICommand
	{
		public bool CanExecute(object parameter)
		{
			// I tried making sure that parameter is a Command_VM
			// but it is only ever null.
			return true;
		}

		// TODO: What is this meant to be used for?
		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
			Command_VM cvm = (Command_VM)parameter;
			if (cvm != null)
				cvm.ButtonOne = "Goodbye City Life";
		}
	}
}
