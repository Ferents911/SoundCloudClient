using SoundCloud.Api;
using SoundCloudClient.Interfaces;
using SoundCloudClient.Models;
using SoundCloudClient.ModelView.View.ViewModel;
using SoundCloudClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SoundCloudClient.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {       

        IUserPlayListService _userPlayListService;
        public ObservableCollection<ExtendedTrack> ExtendedTracks { get; set; }

        public ObservableCollection<ExtendedPlayList> PlayLists { get; set; }
        Dictionary<ExtendedPlayList, List<ExtendedTrack>> PlayListsAndTracks { get; set; }
        
        private ExtendedTrack selectedExtendedTrack;
        private ExtendedTrack track;
        private ExtendedPlayList selectedPlayList;
        private ExtendedPlayList playList;

        public ExtendedTrack SelectedExtendedTrack
        {
            get { return selectedExtendedTrack; }
            set
            {
                selectedExtendedTrack = value;
                OnPropertyChanged("SelectedExtendedTrack");
            }
        }

        public ExtendedPlayList SelectedPlayList
        {
            get { return selectedPlayList; }
            set
            {
                selectedPlayList = value;
                OnPlayListSourceChanged("SelectedPlayList");
            }
        }


        public MainViewModel(ISoundCloudClient client)
        {
            playList = new ExtendedPlayList();
            track = new ExtendedTrack();          
            _userPlayListService = new UserPlayListService(client);
            ExtendedTracks = new ObservableCollection<ExtendedTrack>();
            PlayLists = new ObservableCollection<ExtendedPlayList>();
        }
 
        private RelayCommandService getPlaylistsCommand;
        public RelayCommandService GetPlayListsCommand
        {
            get
            {
                return getPlaylistsCommand ??
                 (getPlaylistsCommand = new RelayCommandService(obj =>
                 {
                     GetPlayListsAndTracks();
                 }));
            }
        }

        private RelayCommandService getFavTracksCommand;
        public RelayCommandService GetFavTracksCommand
        {
            get
            {
                return getFavTracksCommand ??
                 (getFavTracksCommand = new RelayCommandService(obj =>
                 {
                     GetFavouriteTracks();
                 }));
            }
        }

        public async void GetFavouriteTracks()
        {
            PlayLists.Clear();
            var tracksSource = await _userPlayListService.GetFavouriteTracks();
            AddTracks(tracksSource);
        }

        public void AddTracks(List<ExtendedTrack> tracksSource)
        {
            ExtendedTracks.Clear();
            foreach (var track in tracksSource)
            {
                ExtendedTracks.Insert(0, new ExtendedTrack { Title = track.Title, CreatedAt = track.CreatedAt, Likes = track.Likes });
            }
        }

        public async void GetPlayListsAndTracks()
        {
            
            PlayLists.Clear();          
            PlayListsAndTracks = new Dictionary<ExtendedPlayList, List<ExtendedTrack>>();
            PlayListsAndTracks = await _userPlayListService.GetPlayLists();

             foreach (var playlist in PlayListsAndTracks.Keys)
             {
                PlayLists.Add(playlist);
             }
            AddTracks(PlayListsAndTracks[PlayLists[0]]);
        }

        public string PlayListTitle
        {
            get { return playList.PlayListTitle; }
            set
            {
                playList.PlayListTitle = value;
                OnPropertyChanged("PlayListTitle");
            }
        }

        public string PlayListCreatedAt
        {
            get { return playList.PlayListCreatedAt; }
            set
            {
                playList.PlayListCreatedAt = value;
                OnPropertyChanged("PlayListCreatedAt");
            }
        }


        public string Title
        {

            get { return track.Title; }
            set
            {
                track.Title = value;
                OnPropertyChanged("Title");
            }
        }

        public DateTime CreatedAt
        {
            get { return track.CreatedAt; }
            set
            {
                track.CreatedAt = value;
                OnPropertyChanged("CreatedAt");
            }
        }

        public int Likes
        {
            get { return track.Likes; }
            set
            {
                track.Likes = value;
                OnPropertyChanged("Likes");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            
        }

        public void OnPlayListSourceChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));

                if (SelectedPlayList != null)
                {
                    AddTracks(PlayListsAndTracks[SelectedPlayList]);
                }
            }
        }
    }
}
