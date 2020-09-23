using SoundCloudClient.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloudClient.Models
{
    public class ExtendedTrack : IExtendedTrack, INotifyPropertyChanged
    {
        private string title;
        private DateTime createdAt;
        private int likes;
        public string Title {

            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public DateTime CreatedAt {
            get { return createdAt; }
            set
            {
                createdAt = value;
                OnPropertyChanged("CreatedAt");
            }
        }

        public int Likes {
            get { return likes; }
            set
            {
                likes = value;
                OnPropertyChanged("Likes");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
