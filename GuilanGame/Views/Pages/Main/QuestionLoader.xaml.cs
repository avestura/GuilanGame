using GuilanGame.Views.Animations;
using GuilanGame.Views.Controls;
using GuilanGame.Views.Pages.Extension;
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
    /// Interaction logic for LoadingPage.xaml
    /// </summary>
    public partial class QuestionLoader : Page
    {

        public const int NumberOfQuestions = 10;

        public QuestionPage CurrentQuestionSheet => QuestionFrame.Content as QuestionPage;

        public Queue<QuestionPage> Questions { get; set; }

        private IEnumerable<QuestionPage> QuestionsEnum => new List<QuestionPage>
        {

            new Questions.Question1(),
            new Questions.Question2(),
            new Questions.Question3(),
            new Questions.Question4(),
            new Questions.Question5(),
            new Questions.Question6(),
            new Questions.Question7(),
            new Questions.Question8(),
            new Questions.Question9()

        }.OrderBy(x => Guid.NewGuid()).Take(NumberOfQuestions);

        public QuestionLoader()
        {
            InitializeComponent();

            Questions = new Queue<QuestionPage>(QuestionsEnum);
        }

        private void QuestionFrame_Navigated(object sender, NavigationEventArgs e)
        {
            try
            {
                QuestionTitle.Text = ((Page)QuestionFrame.Content).Title;
                QuestionTitle.MarginFadeInAnimation(new Thickness(20,0,0,0), new Thickness(0), TimeSpan.FromMilliseconds(500));

                try
                {
                    QuestionFrame.MarginFadeInAnimation(new Thickness(20,0,0,0), new Thickness(0), TimeSpan.FromMilliseconds(500));
                    KasrTextblock.Visibility = Visibility.Visible;
                }
                catch { }
            }
            catch { }
        }

        private void QLoader_Loaded(object sender, RoutedEventArgs e)
        {
            QuestionFrame.Navigate(Questions.Dequeue());
            ScoreBlock.Text = "۰ امتیاز";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await this.HideUsingLinearAnimationAsync(milliSeconds: 250);
            App.MainMenu.PageFrame.Navigate(new MasterPage());
        }

        private void HintButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentQuestionSheet.ShowHint();
        }

        bool processing = false;
        private async void ContinueGame_Click(object sender, RoutedEventArgs e)
        {
            if (!processing)
            {
                processing = true;
                if (CurrentQuestionSheet.ShowingMode == QuestionPageShowingMode.ShowinQuestion)
                {
                    App.CurrentApp.CurrentRecord.Score += CurrentQuestionSheet.Evaluate().Score;
                    ScoreBlock.Text = App.CurrentApp.CurrentRecord.Score.ToString() + " امتیاز";
                    KasrTextblock.Visibility = Visibility.Collapsed;
                    await CurrentQuestionSheet.ShowAnswer();
                }
                else
                {
                    if (Questions.Count > 0)

                        QuestionFrame.Navigate(Questions.Dequeue());
                    else
                        App.MainMenu.PageFrame.Navigate(new Finsihed(storeData: true));
                }
                await Task.Delay(200);
                processing = false;
            }
        }
    }
}
