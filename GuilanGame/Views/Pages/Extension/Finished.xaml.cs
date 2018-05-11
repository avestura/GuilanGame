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
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class Finsihed : Page
    {
        private bool backAvailable = true;

        private bool storeData = false;

        public Finsihed(bool storeData = false)
        {
            InitializeComponent();
            this.storeData = storeData;
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

        private void Finshed_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentName.Text = App.CurrentApp.CurrentRecord.Name;
            CurrentScore.Text = App.CurrentApp.CurrentRecord.Score.ToString();
            CurrentField.Text = App.CurrentApp.CurrentRecord.StudentFiled;

            if (storeData)
            {
                App.CurrentApp.Configuration.RecordData.Add(new Models.RecordItem()
                {
                    Name = App.CurrentApp.CurrentRecord.Name,
                    StudentFiled = App.CurrentApp.CurrentRecord.StudentFiled,
                    Score = App.CurrentApp.CurrentRecord.Score
                });

                App.CurrentApp.Configuration.SaveSettingsToFile();
            }

        }
    }
}
