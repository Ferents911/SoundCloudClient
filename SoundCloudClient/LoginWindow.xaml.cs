using SoundCloud.Api;
using SoundCloudClient.Interfaces;
using SoundCloudClient.Services;
using SoundCloudClient.ViewModels;
using System.Windows;

namespace SoundCloudClient
{
    public partial class LoginWindow : Window
    {
        ISoundCloudClient _client;
        IUserService _userService;
        public LoginWindow()
        {
            InitializeComponent();
            _userService = new UserService(_client);
            DataContext = new UserCredentialsViewModel(_userService);
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
