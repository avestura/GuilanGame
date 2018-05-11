using GuilanGame.Views.Animations;
using GuilanGame.Views.Pages.Main;
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

namespace GuilanGame.Views.Pages.Extension
{
    /// <summary>
    /// Interaction logic for LoadingPage.xaml
    /// </summary>
    public partial class LoadingPage : Page
    {
        public LoadingPage()
        {
            InitializeComponent();
            LoadingScreen.Visibility = Visibility.Visible;
            GameRulesContent.Visibility = Visibility.Collapsed;
        }

        private async void Loading_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(500);
            await LoadingScreen.HideUsingLinearAnimationAsync(500);
            await GameRulesContent.ShowUsingLinearAnimationAsync(500);
        }

        private async void GoHome_ClickAsync(object sender, RoutedEventArgs e)
        {
            await this.HideUsingLinearAnimationAsync(milliSeconds: 250);
            App.MainMenu.PageFrame.Navigate(new MasterPage());
        }

        private void Field_TextChanged(object sender, TextChangedEventArgs e)
        {

            var forbiddonList = new string[]{
                "لطفا نام خود را وارد کنید",
                "لطفا رشته تحصیلی خود را وارد کنید"
            };

            try
            {
                if (forbiddonList.Contains(PlayerName.Text) || forbiddonList.Contains(FieldName.Text))
                {
                    StartButton.IsEnabled = false;
                }
                else
                {
                    StartButton.IsEnabled = true;
                }
            }
            catch { }
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentApp.CurrentRecord = new Models.RecordItem()
            {
                Name = PlayerName.Text,
                StudentFiled = FieldName.Text
            };

            await GameRulesContent.HideUsingLinearAnimationAsync(250);
            await LoadingScreen.ShowUsingLinearAnimationAsync(250);
            await Task.Delay(250);
            await this.HideUsingLinearAnimationAsync(500);
            App.MainMenu.PageFrame.Navigate(new QuestionLoader());
        }
    }
}
