using SoundCloud.Api;
using SoundCloudClient.Interfaces;
using SoundCloudClient.Models;
using SoundCloudClient.ModelView.View.ViewModel;
using SoundCloudClient.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SoundCloudClient.ViewModels
{
    public class UserCredentialsViewModel : INotifyPropertyChanged
    {
        private UserCredentials user;
        IUserService _userService;
        public UserCredentialsViewModel(IUserService userService)
        {
            user = new UserCredentials();
            _userService = userService;
        }

        public ISoundCloudClient _client;



        private RelayCommandService addCommand;
        public RelayCommandService AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommandService(obj =>
                  {
                    
                      _userService.InitializeUser(user.Login, user.Password);
                  }));
            }
        }

        public string Login
        {
            get { return user.Login; }
            set
            {
                user.Login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get { return user.Password; }
            set
            {
                user.Password = value;
                OnPropertyChanged("Password");
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
