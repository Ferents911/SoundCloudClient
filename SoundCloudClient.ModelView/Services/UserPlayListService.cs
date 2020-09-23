using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundCloud.Api;
using SoundCloud.Api.Entities;
using SoundCloudClient.Interfaces;
using SoundCloudClient.Models;

namespace SoundCloudClient.Services
{
    class UserPlayListService : IUserPlayListService
    {

        ISoundCloudClient _client;
        public UserPlayListService(ISoundCloudClient client)
        {
            _client = client;
        }

        public async Task<List<ExtendedTrack>> GetFavouriteTracks()
        {
            var tracks = await _client.Me.GetFavoritesAsync();

            List<ExtendedTrack> extendedTracks = new List<ExtendedTrack>();

            while (true)
            {
                foreach (var track in tracks)
                {
                    extendedTracks.Add(new ExtendedTrack
                    {
                        Title = track.Title,
                        CreatedAt = track.CreatedAt,
                        Likes = track.LikesCount
                    });
                }

                if (tracks.HasNextPage)
                {
                    tracks = await tracks.GetNextPageAsync();
                }
                else
                {
                    break;
                }
            }

            return extendedTracks;
        }


        public async Task<Dictionary<ExtendedPlayList, List<ExtendedTrack>>> GetPlayLists()
        {
            var playlists = await _client.Me.GetPlaylistsAsync();
            List<ExtendedTrack> tracksOfPlayList;
            ExtendedPlayList extendedPlayList;

            var playlistAndTracks = new Dictionary<ExtendedPlayList, List<ExtendedTrack>>();

            foreach (var playlist in playlists)
            {
                tracksOfPlayList = new List<ExtendedTrack>();
                extendedPlayList = new ExtendedPlayList
                {
                    PlayListTitle = playlist.Title,
                    PlayListCreatedAt = playlist.CreatedAt
                };


                foreach (var track in playlist.Tracks)
                {
                    tracksOfPlayList.Add(new ExtendedTrack { Title = track.Title, CreatedAt = track.CreatedAt, Likes = track.LikesCount });
                }

                playlistAndTracks.Add(extendedPlayList, tracksOfPlayList);
            }


            return playlistAndTracks;
        }
    }
}
