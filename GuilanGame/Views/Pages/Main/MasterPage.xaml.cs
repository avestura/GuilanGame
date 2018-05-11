using GuilanGame.Views.Animations;
using GuilanGame.Views.Pages.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace GuilanGame.Views.Pages.Main{
    /// <summary>
    /// Interaction logic for MasterPage.xaml
    /// </summary>
    public partial class MasterPage : Page
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            string versionText = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

            VersionText.Text = versionText;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private bool _isNavigatingAbout = false;
        private async void AboutGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_isNavigatingAbout)
            {
                _isNavigatingAbout = true;
                await this.HideUsingLinearAnimationAsync(milliSeconds: 250);
                App.MainMenu.PageFrame.Navigate(new About());
                _isNavigatingAbout = false;
            }

        }
        private bool _isNavigatingSettings = false;
        private async void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_isNavigatingSettings)
            {
                _isNavigatingSettings = true;
                await this.HideUsingLinearAnimationAsync(milliSeconds: 250);
                App.MainMenu.PageFrame.Navigate(new Settings());
                _isNavigatingSettings = false;
            }

        }

        private bool _isNavigatingGuilan = false;
        private async void TutorialButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_isNavigatingGuilan)
            {
                _isNavigatingGuilan = true;
                await this.HideUsingLinearAnimationAsync(milliSeconds: 250);
                App.MainMenu.PageFrame.Navigate(new University());
                _isNavigatingGuilan = false;
            }

        }

        private bool _isNavigatingScore = false;
        private async void ScoreBoardButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_isNavigatingScore)
            {
                _isNavigatingScore = true;
                await this.HideUsingLinearAnimationAsync(milliSeconds: 250);
                App.MainMenu.PageFrame.Navigate(new Scoreboard());
                _isNavigatingScore = false;
            }

        }

        private bool _isNavigatingPlay = false;
        private async void OnlinePlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_isNavigatingPlay)
            {
                _isNavigatingPlay = true;
                await this.HideUsingLinearAnimationAsync(milliSeconds: 250);
                App.MainMenu.PageFrame.Navigate(new LoadingPage());
                _isNavigatingPlay = false;
            }

        }
    }
}
