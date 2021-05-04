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

namespace WpfApp280402
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string SizeMessage { get; set; }
        public MainWindow()
        {

            InitializeComponent();

            SizeMessage = "Please wait";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
             var urlTextBox = (TextBox)FindName("UrlTextBox");
            //string url = "https://www.ynet.co.il/home/0,7340,L-8,00.html";
            WebRequest webRequest = WebRequest.Create(urlTextBox.Text);
            WebResponse response = webRequest.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string text = reader.ReadToEnd();
                var sizeTextBlock = (TextBlock)FindName("SizeTextBlock");
                sizeTextBlock.Inlines.Add(text.Length.ToString());
                // text.Length == is the length of the result
            }
        }

        private void UrlTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            UrlTextBox.Clear();
        }

        
    }
}
