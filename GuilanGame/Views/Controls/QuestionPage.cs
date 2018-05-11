using GuilanGame.Views.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GuilanGame.Views.Controls
{

    public enum QuestionPageShowingMode
    {
        ShowinQuestion, ShowingAnswer
    }

    public class QuestionPage : Page
    {
        public QuestionPage() : base()
        {
            Loaded += QuestionPage_Loaded;
        }

        private void QuestionPage_Loaded(object sender, RoutedEventArgs e)
        {
            QuestionArea.Visibility = Visibility.Visible;
            AnswerArea.Visibility = Visibility.Collapsed;
        }

        public string QuestionHint
        {
            get { return (string)GetValue(QuestionHintProperty); }
            set { SetValue(QuestionHintProperty, value); }
        }
        public static readonly DependencyProperty QuestionHintProperty =
            DependencyProperty.Register("QuestionHint", typeof(string), typeof(QuestionPage), null);

        public Border HintBorder
        {
            get { return (Border)GetValue(HintBorderProperty); }
            set { SetValue(HintBorderProperty, value); }
        }
        public static readonly DependencyProperty HintBorderProperty =
            DependencyProperty.Register("HintBorder", typeof(Border), typeof(QuestionPage), null);

        public Grid QuestionArea
        {
            get { return (Grid)GetValue(QuestionAreaProperty); }
            set { SetValue(QuestionAreaProperty, value); }
        }
        public static readonly DependencyProperty QuestionAreaProperty =
            DependencyProperty.Register("QuestionArea", typeof(Grid), typeof(QuestionPage), null);

        public Grid AnswerArea
        {
            get { return (Grid)GetValue(AnserAreaProperty); }
            set { SetValue(AnserAreaProperty, value); }
        }
        public static readonly DependencyProperty AnserAreaProperty =
            DependencyProperty.Register("AnserArea", typeof(Grid), typeof(QuestionPage), null);

        public bool HintUsed
        {
            get { return (bool)GetValue(HintUsedProperty); }
            set { SetValue(HintUsedProperty, value); }
        }
        public static readonly DependencyProperty HintUsedProperty =
            DependencyProperty.Register("HintUsed", typeof(bool), typeof(QuestionPage), new PropertyMetadata(false));

        public string ResultMessage
        {
            get { return (string)GetValue(ResultMessageProperty); }
            set { SetValue(ResultMessageProperty, value); }
        }
        public static readonly DependencyProperty ResultMessageProperty =
            DependencyProperty.Register("ResultMessage", typeof(string), typeof(QuestionPage), null);

        public async void ShowHint()
        {
            if (!HintUsed)
            {
                HintUsed = true;
                await HintBorder.ShowUsingLinearAnimationAsync(250);
            }
        }

        public QuestionPageShowingMode ShowingMode
        {
            get { return (QuestionPageShowingMode)GetValue(ShowingModeProperty); }
            set { SetValue(ShowingModeProperty, value); }
        }
        public static readonly DependencyProperty ShowingModeProperty =
            DependencyProperty.Register("ShowingMode", typeof(QuestionPageShowingMode), typeof(QuestionPage), new PropertyMetadata(QuestionPageShowingMode.ShowinQuestion));

        public virtual (int Score, string Message) Evaluate()
        {
            return (0, "");
        }

        public async Task ShowAnswer()
        {
            ShowingMode = QuestionPageShowingMode.ShowingAnswer;
            await QuestionArea.HideUsingLinearAnimationAsync(250);
            ResultMessage = Evaluate().Message;
            await AnswerArea.ShowUsingLinearAnimationAsync(250);
        }

    }
}
