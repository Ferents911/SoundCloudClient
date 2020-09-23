using SoundCloudClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloudClient.Interfaces
{
    public interface IUserService
    {
        void InitializeUser(string login, string password);

    }
}
