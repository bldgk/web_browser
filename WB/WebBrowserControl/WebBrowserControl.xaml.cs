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

namespace WebBrowserControl
{
	/// <summary>
	/// Interaction logic for WebBrowserControl.xaml
	/// </summary>
	public partial class WebBrowserControl : UserControl
	{
		public WebBrowserControl()
		{
			InitializeComponent();
		}
		public string Text
		{
					get
			{
				return tb_view.Text;
			}
			set
			{
				tb_view.Text = value;
			}
		}
	}
}
