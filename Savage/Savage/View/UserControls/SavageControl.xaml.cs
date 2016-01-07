
using Savage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Savage.UserControls
{
	/// <summary>
	/// Interaction logic for SavageControl.xaml
	/// </summary>
	public partial class SavageControl : UserControl
	{
		public SavageControl()
		{
			InitializeComponent();
		}

		//public string Text
		//{
		//	get
		//	{
		//		return tb_view.Text;
		//	}
		//	set
		//	{
		//		tb_view.Text = value;
		//	}
		//}

		public void Build(string sourceCode)
		{
			Grid p = new Grid();

			CoreAssistant.Build(CoreAssistant.GetModelFromSourceCode(sourceCode), ref p);
			var tabitem = new TabItem();

			tabitem.Header = "Untitled";
			tabitem.Content = p;
			tbc_OpenPages.Items.Add(tabitem);
			tbc_OpenPages.SelectedItem = tabitem;
		}

		private void listBox_SourceUpdated(Object sender, DataTransferEventArgs e)
		{

		}
	}
}
