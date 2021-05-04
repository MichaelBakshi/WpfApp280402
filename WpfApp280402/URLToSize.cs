using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp280402
{
    class URLToSize: INotifyPropertyChanged
    {
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
            }
        }

        public URLToSize()
        {
            url = "Nirav";
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
