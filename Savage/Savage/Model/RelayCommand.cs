using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Savage.Model
{
	public class RelayCommand:ICommand
	{
		private Action<object> executeCommand;
		private Predicate<object> canExecuteCommand;

		private event EventHandler CanExecuteChangedInternal;
		public RelayCommand(Action<object>execute)
			:this(execute, DefaultCanExecute)
		{

		}

		public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
			if(execute == null)
			{
				throw new ArgumentNullException(nameof(execute));
			}
			if(canExecute == null)
			{
				throw new ArgumentNullException(nameof(canExecute));
			}
			executeCommand = execute;
			canExecuteCommand = canExecute;
		}

		public event EventHandler CanExecuteChanged
		{
			add
			{
				CommandManager.RequerySuggested += value;
				CanExecuteChangedInternal += value;
			}
			remove
			{
				CommandManager.RequerySuggested -= value;
				CanExecuteChangedInternal -= value;
			}
		}
		public bool CanExecute(object param)
		{
			return canExecuteCommand != null && canExecuteCommand(param);
		}
		public void Execute(object param)
		{
			executeCommand(param);
		}
		public void OnCanExecuteChanged()
		{

			EventHandler handler = CanExecuteChangedInternal;
			handler?.Invoke(this, EventArgs.Empty);
		}
		public void Destroy()
		{
			canExecuteCommand = _ => false;
			executeCommand = _ =>
			{
			};
		}
		private static bool DefaultCanExecute(object parameter)
		{
			
			return true;
		}
	}
}
