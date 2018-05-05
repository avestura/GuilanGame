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
    /// Interaction logic for Intro.xaml
    /// </summary>
    public partial class Intro : Page
    {
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            //IntroPlayer.BeginInit();
            IntroPlayer.Source = new Uri($"{AppDomain.CurrentDomain.BaseDirectory}/Assets/Media/Video/GameIntro 1920x1080.mp4");
            //IntroPlayer.EndInit();
            //IntroPlayer.Play();
            Focus();
        }

        private void IntroPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {

            App.CastedMainWindow.MainFrame.Navigate(App.MainMenu);

        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Escape)
                App.CastedMainWindow.MainFrame.Navigate(App.MainMenu);

        }
    }
}
