using Savage.Core;
using Savage.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace Savage
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		MainWindowViewModel mainWindowViewModel
		{
			get;
			set;
		}
		public MainWindow()
		{
			InitializeComponent();
			mainWindowViewModel = new MainWindowViewModel();
			DataContext = mainWindowViewModel;
			//btn_naviTo.Click += mainWindowViewModel.NavigateToCommandExecute
        }
		public string Url
		{
			get
			{
				return tb_url.Text;
			}
			set
			{
				tb_url.Text = value;
			}
		}

		public IAsyncResult AsyncResult
		{
			get; set;
		}

		public string SourceCode
		{
			get;
			set;
		}

		private void tabControl_MouseDoubleClick(Object sender, MouseButtonEventArgs e)
		{
			if(state == false)
			{
				this.WindowState = WindowState.Normal;
			}
			else
			{
				this.WindowState = WindowState.Maximized;
			}
			state = !state;
		}

		private void btn_bookPad_Click(Object sender, RoutedEventArgs e)
		{

		}

		private void btn_back_Click(Object sender, RoutedEventArgs e)
		{

		}

		private void btn_forward_Click(Object sender, RoutedEventArgs e)
		{

		}

		private void btn_refresh_Click(Object sender, RoutedEventArgs e)
		{

		}

		private void btn_home_Click(Object sender, RoutedEventArgs e)
		{

		}

		private void btn_naviTo_Click(Object sender, RoutedEventArgs e)
		{
			SourceCode = File.ReadAllText(@"C:\Users\kiril_000\Desktop\1.html");
			//HttpWebRequest httprequest = WebRequest.Create("http://" + tb_url.Text) as HttpWebRequest;
			//httprequest.BeginGetResponse(new AsyncCallback(OnResponse), httprequest);
		}

		private void btn_show_Click(Object sender, RoutedEventArgs e)
		{
			BuildModel();
		}

		private void btn_settings_Click(Object sender, RoutedEventArgs e)
		{

		}
		private bool state = false;

		public void BuildModel()
		{
			desk.Build(SourceCode);
			//desk.Text = CoreAssistant.PrintModel(CoreAssistant.GetModelFromSourceCode(SourceCode));
		}


		private void OnResponse(IAsyncResult asyncResult)
		{
			HttpWebRequest httprequest = (HttpWebRequest)asyncResult.AsyncState;
			HttpWebResponse httpresponse = (HttpWebResponse)httprequest.EndGetResponse(asyncResult);
			using(StreamReader stream = new StreamReader(httpresponse.GetResponseStream()))
			{
				string line;
				while((line = stream.ReadLine()) != null)
				{
					Dispatcher.Invoke(() =>
					{
						SourceCode += line;
					});
				}
			}
			Dispatcher.Invoke(() =>
			{
			//	desk.Text = SourceCode;
			});
		}
	}
}
