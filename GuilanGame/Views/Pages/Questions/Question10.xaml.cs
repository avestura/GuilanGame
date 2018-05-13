using GuilanGame.Views.Controls;
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

namespace GuilanGame.Views.Pages.Questions
{

    public partial class Question10 : QuestionPage
    {
        public Question10()
        {
            InitializeComponent();
            HintBorder = _HintBorder;
            AnswerArea = _AnswerArea;
            QuestionArea = _QuestionArea;
        }

        static int tempScore = 0;
        public override (int Score, string Message) Evaluate()
        {
            if (InputTextBox.Text == "101" || InputTextBox.Text == "۱۰۱")
            {
                tempScore = 100;
            }

            if (Chk4.IsChecked == true)
            {
                return (!HintUsed) ?
                    (80, "با پاسخ درستت بازی رو تموم کردی") :
                    (40, "با پاسخ درستت بازی رو تموم کردی");

            }
            else
            {
                return (0, "ظاهرا تو سوال آخر زیاد موفق نبودی");
            }

        }
    }
}
