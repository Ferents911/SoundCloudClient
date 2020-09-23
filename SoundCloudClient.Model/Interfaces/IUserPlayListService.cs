using SoundCloudClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloudClient.Interfaces
{
    public interface IUserPlayListService
    {
        Task<List<ExtendedTrack>> GetFavouriteTracks();

        Task<Dictionary<ExtendedPlayList, List<ExtendedTrack>>> GetPlayLists();
    }
}
