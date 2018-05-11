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

    public partial class Question9: QuestionPage
    {
        public Question9()
        {
            InitializeComponent();
            HintBorder = _HintBorder;
            AnswerArea = _AnswerArea;
            QuestionArea = _QuestionArea;
        }

        public override (int Score, string Message) Evaluate()
        {
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
