using System.Windows;
using System.Windows.Input;
using SoundCloud.Api;

using SoundCloudClient.ViewModels;

namespace SoundCloudClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        ISoundCloudClient _client;

        public MainWindow(ISoundCloudClient client)
        {
            InitializeComponent();
            
            _client = client;
            DataContext = new MainViewModel(_client);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        
    }
}
