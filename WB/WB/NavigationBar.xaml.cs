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

namespace WB
{
	/// <summary>
	/// Interaction logic for NavigationBar.xaml
	/// </summary>
	public partial class NavigationBar : UserControl
	{
		public NavigationBar()
		{
			InitializeComponent();
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
		private void btn_naviTo_Click(object sender, RoutedEventArgs e)
		{
			HttpWebRequest httprequest = WebRequest.Create("http://" + tb_url.Text) as HttpWebRequest;
			httprequest.BeginGetResponse(new AsyncCallback(OnResponse), httprequest);

		}


		private void OnResponse(IAsyncResult asyncResult)
		{
			HttpWebRequest httprequest = (HttpWebRequest)asyncResult.AsyncState;
			HttpWebResponse httpresponse = (HttpWebResponse)httprequest.EndGetResponse(asyncResult);
			using (StreamReader stream = new StreamReader(httpresponse.GetResponseStream()))
			{
				string line;
				while ((line = stream.ReadLine()) != null)
				{
					Dispatcher.Invoke(() =>
					{
						SourceCode += line;
					});
				}
			}
		}
	}
}