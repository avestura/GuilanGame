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

namespace GuilanGame.Views.Pages.Main
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {

        private bool backAvailable = true;
        private bool init = false;
        public Settings()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (backAvailable)
            {
                backAvailable = false;
                await this.HideUsingLinearAnimationAsync(milliSeconds: 250);
                App.MainMenu.PageFrame.Navigate(new MasterPage());
                App.MainMenu.PageFrame.ShowUsingLinearAnimation(milliSeconds: 250);
            }
        }

        private void MusicSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (init)
            {
                App.CurrentApp.Configuration.MusicPlayerVolume = MusicSlider.Value;
                App.CastedMainWindow.MusicPlayer.Volume = MusicSlider.Value / 100;

                App.CurrentApp.Configuration.SaveSettingsToFile();
            }
        }

        private void EffectSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (init)
            {
                App.CurrentApp.Configuration.EffectPlayerVolume = EffectSlider.Value;
                App.CastedMainWindow.EffectPlayer.Volume = EffectSlider.Value / 100;

                App.CurrentApp.Configuration.SaveSettingsToFile();
            }
        }

        private void SettingsPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!init)
            {
                MusicSlider.Value = App.CurrentApp.Configuration.MusicPlayerVolume ;
                EffectSlider.Value = App.CurrentApp.Configuration.EffectPlayerVolume;

                init = true;
            }
        }
    }
}
