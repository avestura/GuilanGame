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

namespace GuilanGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Frame MainFrame { get { return Frame; } }
        public MediaPlayer MusicPlayer { get; } = new MediaPlayer();
        public MediaPlayer EffectPlayer { get; } = new MediaPlayer();
        public bool SoundPlayerRepeatMode { get; set; }

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MusicPlayer.MediaEnded += SoundPlayer_MediaEnded;
            MusicPlayer.Volume = App.CurrentApp.Configuration.MusicPlayerVolume;
            EffectPlayer.Volume = App.CurrentApp.Configuration.EffectPlayerVolume;
        }

        private void MusicPlayer_Changed(object sender, EventArgs e)
        {

        }

        private async void SoundPlayer_MediaEnded(object sender, EventArgs e)
        {
            if (SoundPlayerRepeatMode)
            {
                await Task.Delay(2000);
                MusicPlayer.Position = new TimeSpan(0, 0, 0);
                MusicPlayer.Play();
            }
        }
    }
}
