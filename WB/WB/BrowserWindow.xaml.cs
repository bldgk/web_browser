using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using WBCore;
using WBLibrary;
namespace WB
{
	/// <summary>
	/// Interaction logic for BrowserWindow.xaml
	/// </summary>
	public partial class BrowserWindow : Window
	{
		public BrowserWindow()
		{
			InitializeComponent();
		}

		public DocumentObjectModel Dom
		{
			get; set;
		}
		public List<Document> openedDocuments = new List<Document>();
		public Document DocumentPage
		{
			get;
			set;
		}
		
		private void WBWindow_Loaded(object sender, RoutedEventArgs e)
		{

		}

		private void btn_naviTo_Click(Object sender, RoutedEventArgs e)
		{
			SourceCode = File.ReadAllText(@"C:\Users\kiril_000\Desktop\1.html");
			desk.Text = SourceCode;
			//HttpWebRequest httprequest = WebRequest.Create("http://" + tb_url.Text) as HttpWebRequest;
			//httprequest.BeginGetResponse(new AsyncCallback(OnResponse), httprequest);

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
			get
			{
				return desk.Text;
			}
			set
			{
				desk.Text = value;
			}
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
				desk.Text = SourceCode;
			});
		}


		public void BuildModel()
		{
		//	Core.Build(SourceCode);
			desk.Text = Assistant.PrintModel(Core.GetModelFromSourceCode(SourceCode));
		}


		private bool state = false;
		

		private void tabControl_MouseDoubleClick(Object sender, System.Windows.Input.MouseButtonEventArgs e)
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

		private void btn_show_Click(Object sender, RoutedEventArgs e)
		{
			BuildModel();
		}
	}
}
