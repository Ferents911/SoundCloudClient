using SoundCloudClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloudClient.Interfaces
{
    interface IExtendedTrack
    {
        string Title { get; set; }

        DateTime CreatedAt { get; set; }

        int Likes { get; set; }

    }
}
