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

namespace WebBrowserTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class ResolveState
    {
        string hostName;
        IPHostEntry resolvedIPs;

        public ResolveState(string host)
        {
            hostName = host;
        }

        public IPHostEntry IPs
        {
            get { return resolvedIPs; }
            set { resolvedIPs = value; }
        }
        public string host
        {
            get { return hostName; }
            set { hostName = value; }
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void request_Click(object sender, RoutedEventArgs e)
        {
            WebRequest request = WebRequest.Create("http://" + txb_url.Text);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            request.BeginGetResponse(new AsyncCallback(OnResponse),request);

            HttpWebRequest Httprequest = WebRequest.Create("http://" + txb_url.Text) as HttpWebRequest;
            // Get the response.
            Httprequest.BeginGetResponse(new AsyncCallback(OnResponseHttp), Httprequest);
            // Display the status.

            string HostName = txb_url.Text;
         
            ResolveState ioContext = new ResolveState(HostName);

            Dns.BeginGetHostEntry(ioContext.host,
                new AsyncCallback(OnResponseIP), ioContext);

            
        }

        protected void OnResponseIP(IAsyncResult ar)
        {
            ResolveState ioContext = (ResolveState)ar.AsyncState;
            ioContext.IPs = Dns.EndGetHostEntry(ar);
            foreach (IPAddress ip in ioContext.IPs.AddressList)
                Dispatcher.Invoke(() =>
                {
                    txbIp.Text += ip.ToString() + "\n";
                });
            Dispatcher.Invoke(() =>
            {
                foreach (string aliasName in ioContext.IPs.Aliases)
                    txbIp.Text += aliasName;
            });
            Dispatcher.Invoke(() =>
            {
                txbIp.Text += "Реальное название хоста: " + ioContext.IPs.HostName;
            });
        }

        protected void OnResponse(IAsyncResult ar)
        {
            WebRequest request = (WebRequest)ar.AsyncState;
            WebResponse response = request.EndGetResponse(ar);

            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                    this.Dispatcher.Invoke(() =>
                    {
                        txb_sourceCode.Text += line + "\n";
                    });
            }

            string messageServer = "Целевой URL: \t" + request.RequestUri + "\nМетод запроса: \t" + request.Method +
                 "\nТип полученных данных: \t" + response.ContentType + "\nДлина ответа: \t" + response.ContentLength + "\nЗаголовки";

            WebHeaderCollection header = response.Headers;
            var headers = Enumerable.Range(0, header.Count)
                .Select(p =>
                {
                    return new
                    {
                        Key = header.GetKey(p),
                        Names = header.GetValues(p)
                    };
                });
            foreach (var item in headers)
            {
                messageServer += "\n " + item.Key + " ";
                foreach (var name in item.Names)
                    messageServer += "\t" + name;
            }

            this.Dispatcher.Invoke(() =>
            {
                txb_serverInfo.Text = messageServer;
            });


        }
        protected void OnResponseHttp(IAsyncResult ar)
        {
            

            HttpWebRequest httprequest = (HttpWebRequest)ar.AsyncState;
            HttpWebResponse httpresponse = (HttpWebResponse)httprequest.EndGetResponse(ar);
            Console.WriteLine(httpresponse.StatusDescription);
            using (StreamReader stream = new StreamReader(httpresponse.GetResponseStream()))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                    this.Dispatcher.Invoke(() =>
                    {

                        txbHttpWeb_sourceCode.Text += line + "\n";
                    });
            }

            string messageServer = "Целевой URL: \t" + httprequest.RequestUri + "\nМетод запроса: \t" + httprequest.Method +
                 "\nТип полученных данных: \t" + httpresponse.ContentType + "\nДлина ответа: \t" + httpresponse.ContentLength + "\nЗаголовки";

            WebHeaderCollection header = httpresponse.Headers;
            var headers = Enumerable.Range(0, header.Count)
               .Select(p =>
               {
                   return new
                   {
                       Key = header.GetKey(p),
                       Names = header.GetValues(p)
                   };
               });
            foreach (var item in headers)
            {
                messageServer += "\n " + item.Key + " ";
                foreach (var name in item.Names)
                    messageServer += "\t" + name;
            }

            this.Dispatcher.Invoke(() =>
            {
                txbHttp_serverInfo.Text = messageServer;
            });
        }
    }
}
