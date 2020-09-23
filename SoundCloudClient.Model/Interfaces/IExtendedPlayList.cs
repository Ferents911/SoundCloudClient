using SoundCloudClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloudClient.Interfaces
{
    interface IExtendedPlayList
    {
        string PlayListTitle { get; set; }

        string PlayListCreatedAt { get; set; }

    }
}
