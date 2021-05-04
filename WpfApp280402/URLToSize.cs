using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfApp280402
{
    class URLToSize: INotifyPropertyChanged
    {
        private bool buttonOffOn;
        public bool IsEnabled
        {
            get
            {
                return buttonOffOn;
            }
            set
            {
                buttonOffOn = value;
                OnPropertyRaised("IsEnabled");
            }
        }
        private string url;
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
                OnPropertyRaised("Url");
            }
        }

        

        private string size;

        public string Size
        {
            get
            {
                return size ;
            }
            set
            {
                size = value;
                OnPropertyRaised("Size");
            }
        }
        public DelegateCommand DispatcherButton { get; set; }
        public DelegateCommand AsyncButton { get; set; }

        public URLToSize()
        {
            DispatcherButton = new DelegateCommand(GetSizeByDispatcher);
            IsEnabled = true;
            // Url = "http://";
            //AsyncButton = new DelegateCommand(GetSizeByDispatcher);

        }
        //string url = "https://www.ynet.co.il/home/0,7340,L-8,00.html";

        public void GetSizeByDispatcher()
        {
           
                IsEnabled = false;
                Task.Run(() =>
                {
                    WebRequest webRequest = WebRequest.Create(Url);
                    WebResponse response = webRequest.GetResponse();
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string text = reader.ReadToEnd();
                        Dispatcher.CurrentDispatcher.Invoke(() => { Size = text.Length.ToString(); });
                    // Size = text.Length.ToString(); 
                    // text.Length == is the length of the result
                }
                });
                IsEnabled = true;

        }
        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        


    }
}
