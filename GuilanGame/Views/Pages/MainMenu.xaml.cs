using GuilanGame.Views.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuilanGame.Views.Pages
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        Unosquare.FFME.MediaElement PageMediaElement { get; set; }

        public MainMenu()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                PageMediaElement = new Unosquare.FFME.MediaElement();
                Background = new VisualBrush(PageMediaElement);
                PageMediaElement.LoadedBehavior = MediaState.Play;
                PageMediaElement.MediaEnded += PageMediaElement_MediaEnded;
                PageMediaElement.MediaOpened += PageMediaElement_MediaOpened;
                PageMediaElement.Source = new Uri($"{AppDomain.CurrentDomain.BaseDirectory}/Assets/Media/Video/Guilan Trailer.mp4");

            });
            PageFrame.Visibility = Visibility.Collapsed;
            App.CastedMainWindow.MusicPlayer.Open(new Uri($"{AppDomain.CurrentDomain.BaseDirectory}/Assets/Media/Sound/Music.mp3"));
            App.CastedMainWindow.SoundPlayerRepeatMode = true;

        }

        private void PageMediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            PageMediaElement.Position = new TimeSpan(0, 0, 0);
            PageMediaElement.Play();

        }

        private void PageMediaElement_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void PageMediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            App.CastedMainWindow.MusicPlayer.Play();
            PageFrame.ShowUsingLinearAnimation();
        }

        private void PageFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back || e.NavigationMode == NavigationMode.Forward)
                e.Cancel = true;
        }
    }
}
