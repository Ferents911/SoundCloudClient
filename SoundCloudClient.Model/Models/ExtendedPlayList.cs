using SoundCloudClient.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SoundCloudClient.Models
{
    public class ExtendedPlayList : IExtendedPlayList, INotifyPropertyChanged
    {
        private string playListTitle;
        private string playListCreatedAt;
        public string PlayListTitle
        {

            get { return playListTitle; }
            set
            {
                playListTitle = value;
                OnPropertyChanged("PlayListTitle");
            }
        }

        public string PlayListCreatedAt
        {
            get { return playListCreatedAt; }
            set
            {
                playListCreatedAt = value;
                OnPropertyChanged("PlayListCreatedAt");
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
