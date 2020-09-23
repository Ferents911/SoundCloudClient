using SoundCloud.Api;
using SoundCloud.Api.Entities;
using SoundCloudClient.Interfaces;
using SoundCloudClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SoundCloudClient.Services
{
    class UserService : IUserService
    {
        const string clientId = "54fe3f90bb89322f417567a6c834b383";
        const string clientSecret = "d642c38645ae65288465b8ac0a06ee30"; 
        ISoundCloudClient _client;
        MainWindow mainWindow;
        public UserService(ISoundCloudClient client)
        {
            _client = client;
        }

        public async void InitializeUser(string login, string password)
        {
            if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password))
            {
                try
                {
                    var auth = await SoundCloudOAuth.FromPassword(clientId, clientSecret, login, password);
                    _client = SoundCloud.Api.SoundCloudClient.CreateAuthorized(auth.AccessToken);
                    mainWindow = new MainWindow(_client);
                    mainWindow.Show();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Invalid credentials: " + e.Message);
                }
            } else
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.Show();
            }
        }

    }
}
