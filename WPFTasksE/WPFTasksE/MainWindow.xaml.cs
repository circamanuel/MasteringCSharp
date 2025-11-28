using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Threading;
using System.Net.Http;
using System.Net;

namespace WPFTasksE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached(
            "Html", typeof(string),
            typeof(MainWindow),
            new FrameworkPropertyMetadata(OnHtmlChanged));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Debug.WriteLine($"Trhead Nr. {Thread.CurrentThread.ManagedThreadId}");
                HttpClient webClient = new HttpClient();
                string html = webClient.GetStringAsync("http://ipv4.download.thinkbroadband.com/10MB.zip").Result;

                myButton.Dispatcher.Invoke(() =>
                {
                    Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} Owns MyButton");
                    myButton.Content = "Done";
                });
            });
           
        }

        private async void MyButton_Click2(object sender, RoutedEventArgs e)
        {
            string myHtml = "";
            Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} during await task");
            await Task.Run(async () =>
            {
                Debug.WriteLine($"Trhead Nr. {Thread.CurrentThread.ManagedThreadId}");
                HttpClient webClient = new HttpClient();
                string html = await webClient.GetStringAsync("http://www.google.com");
                myHtml = html;
            });
            Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} after wait task");
            myButton.Content = "Done Downloading";
            MyWebBrowser.SetValue(HtmlProperty, myHtml);
        }

        static void OnHtmlChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser webBrowser = dependencyObject as WebBrowser;
            if (webBrowser != null)
            {
                webBrowser.NavigateToString(e.NewValue as string);
            }
        }
    }
}
