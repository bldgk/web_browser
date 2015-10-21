using System.Windows;
using System.Windows.Controls;
using WBCore.Dom;

namespace WebBrowserTest
{
    public partial class MainWindow : Window
    {       

        public MainWindow()
        {
            InitializeComponent();
        }

        //public IAsyncResult AsyncResult { get; set; }

        public DomModel Dom { get; set; }

        //public void OnResponse()
        //{
        //    WebRequest request = (WebRequest)AsyncResult.AsyncState;
        //    WebResponse response = request.EndGetResponse(AsyncResult);

        //    using (StreamReader stream = new StreamReader(response.GetResponseStream()))
        //    {
        //        string line;
        //        while ((line = stream.ReadLine()) != null)
        //        {
        //            Dispatcher.Invoke(() =>
        //            {
        //                txb_sourceCode.Text += line + "\n";
        //            });
        //        }
        //    }

        //    string messageServer = "Целевой URL: \t" + request.RequestUri + "\nМетод запроса: \t" + request.Method +
        //         "\nТип полученных данных: \t" + response.ContentType + "\nДлина ответа: \t" + response.ContentLength + "\nЗаголовки";

        //    WebHeaderCollection header = response.Headers;
        //    var headers = Enumerable.Range(0, header.Count)
        //        .Select(p =>
        //        {
        //            return new
        //            {
        //                Key = header.GetKey(p),
        //                Names = header.GetValues(p)
        //            };
        //        });
        //    foreach (var item in headers)
        //    {
        //        messageServer += "\n " + item.Key + " ";
        //        foreach (var name in item.Names)
        //        {
        //            messageServer += "\t" + name;
        //        }
        //    }

        //    Dispatcher.Invoke(() =>
        //    {
        //        txb_serverInfo.Text = messageServer;
        //    });
        //}

        //public void OnResponseFile(IAsyncResult iar)
        //{
        //    FileWebRequest filerequest = (FileWebRequest)iar.AsyncState;
        //    FileWebResponse fileResponse = (FileWebResponse)filerequest.EndGetResponse(iar);

        //    using (StreamReader stream = new StreamReader(fileResponse.GetResponseStream()))
        //    {
        //        string line;
        //        while ((line = stream.ReadLine()) != null)
        //        {
        //            Dispatcher.Invoke(() =>
        //            {
        //                txbHttpWeb_sourceCode.Text += line + "\n";
        //            });
        //        }
        //    }
        //}

        //public void OnResponseHttp()
        //{
        //    HttpWebRequest httprequest = (HttpWebRequest)AsyncResult.AsyncState;
        //    HttpWebResponse httpresponse = (HttpWebResponse)httprequest.EndGetResponse(AsyncResult);
        //    Console.WriteLine(httpresponse.StatusDescription);
        //    using (StreamReader stream = new StreamReader(httpresponse.GetResponseStream()))
        //    {
        //        string line;
        //        while ((line = stream.ReadLine()) != null)
        //        {
        //            Dispatcher.Invoke(() =>
        //            {
        //                txbHttpWeb_sourceCode.Text += line + "\n";
        //            });
        //        }
        //    }

        //    string messageServer = "Целевой URL: \t" + httprequest.RequestUri + "\nМетод запроса: \t" + httprequest.Method +
        //         "\nТип полученных данных: \t" + httpresponse.ContentType + "\nДлина ответа: \t" + httpresponse.ContentLength + "\nЗаголовки";

        //    WebHeaderCollection header = httpresponse.Headers;
        //    var headers = Enumerable.Range(0, header.Count)
        //       .Select(p =>
        //       {
        //           return new
        //           {
        //               Key = header.GetKey(p),
        //               Names = header.GetValues(p)
        //           };
        //       });
        //    foreach (var item in headers)
        //    {
        //        messageServer += "\n " + item.Key + " ";
        //        foreach (var name in item.Names)
        //        {
        //            messageServer += "\t" + name;
        //        }
        //    }

        //    Dispatcher.Invoke(() =>
        //    {
        //        txbHttp_serverInfo.Text = messageServer;
        //    });

        //}

        private void Request_Click(object sender, RoutedEventArgs e)
        {

            //WebRequest request = WebRequest.Create("http://" + txb_url.Text);
            //// If required by the server, set the credentials.
            //request.Credentials = CredentialCache.DefaultCredentials;
            //request.BeginGetResponse(new AsyncCallback(OnResponse),request);

            //HttpWebRequest Httprequest = WebRequest.Create("http://" + txb_url.Text) as HttpWebRequest;
            //Httprequest.BeginGetResponse(new AsyncCallback(OnResponseHttp), Httprequest);

            ////WebClient WebClient = new WebClient();
            ////WebClient.Encoding = Encoding.UTF8;
            ////string str = WebClient.DownloadString(new Uri("http://" + txb_url.Text));
            ////txb_sourceCode.Text = str;

            //Stream stream = WebClient.OpenRead("http://www.professorweb.ru");
            //StreamReader sr = new StreamReader(stream);
            //string newLine;
            //while ((newLine = sr.ReadLine()) != null)
            //    txb_sourceCode.Text += newLine + "\n";
            //stream.Close();

            ////FileWebRequest FWRequest = (FileWebRequest)WebRequest.Create("http://" + txb_url.Text);// as FileWebRequest;
            //FWRequest.BeginGetResponse(new AsyncCallback(OnResponseFile), FWRequest);
            //FileWebRequest FwR = WebRequest.Create("http://" + txb_url.Text) as FileWebRequest;
            //using (StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream()))
            //{
            //    txbFileWeb_sourceCode.Text = sr.ReadToEnd();
            //}

            //string HostName = txb_url.Text;
            //txb_sourceCode.Text = str;
            //ResolveState ioContext = new ResolveState(HostName);

            //Dns.BeginGetHostEntry(ioContext.host,
            //    new AsyncCallback(OnResponseIP), ioContext);
            Dom = new DomModel();
            Dom.CreateModel();
            INode document = Dom.Model;
            foreach (var n in document.ChildNodes)
            {
                TreeViewItem item = new TreeViewItem();
                item.Tag = n;
                item.Header = n.ToString();

                treeView.Items.Add(item);
            }
        }

    }
}