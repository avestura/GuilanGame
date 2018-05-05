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

namespace GuilanGame.Views.Pages.SubPages.MainMenu
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Page
    {
        private bool backAvailable = true;

        public About()
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
    }
}
