using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
		private string buttonOneRaw;
		public string ButtonOneRaw
		{
			get { return buttonOneRaw; }
			set
			{
				buttonOneRaw = value;
				RaisePropertyChanged("ButtonOneRaw");
			}
		}

		public ICommand ButtonOneACmd { get { return new ButtonOneACommand(); } }
		public ICommand ButtonOneBCmd { get { return new ButtonOneBCommand(); } }

		private string buttonOneRelay;
		public string ButtonOneRelay
		{
			get { return buttonOneRelay; }
			set
			{
				buttonOneRelay = value;
				RaisePropertyChanged("ButtonOneRelay");
			}
		}

		public RelayCommand RelayButtonOneACmd { get; private set; }
		public RelayCommand RelayButtonOneBCmd { get; private set; }

		private void SetButtonOneHelloWorld()
		{
			ButtonOneRelay = "relayHello World";
		}

		private void SetButtonOneGoodbye()
		{
			ButtonOneRelay = "relayGoodbye City Life";
		}

		public Command_VM()
		{
			ButtonOneRaw = "Click the buttons";
			ButtonOneRelay = "Click the buttons";

			RelayButtonOneACmd = new RelayCommand(SetButtonOneHelloWorld);
			RelayButtonOneBCmd = new RelayCommand(SetButtonOneGoodbye);
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
				cvm.ButtonOneRaw = "Hello World";
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
				cvm.ButtonOneRaw = "Goodbye City Life";
		}
	}
}
