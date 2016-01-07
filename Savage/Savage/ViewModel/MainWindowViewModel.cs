using Savage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Savage.ViewModel
{
	public class MainWindowViewModel
	{
		private ICommand naviageToCommand;
		private ICommand buildCommand;

		public MainWindowViewModel()
		{
			SubscribeToCommands();
        }

		public ICommand NavigateToCommand
		{
			get
			{
				return naviageToCommand;
			}
			set
			{
				naviageToCommand = value;
			}
		}

		public ICommand BuildCommand
		{
			get
			{
				return buildCommand;
			}
			set
			{
				buildCommand = value;
			}
		}



		private void SubscribeToCommands()
		{
			naviageToCommand = new RelayCommand(NavigateToCommandExecute);
		//	buildCommand = new RelayCommand(BuildCommand);
		}

		public void NavigateToCommandExecute(object obj)
		{

		}
	}
}
