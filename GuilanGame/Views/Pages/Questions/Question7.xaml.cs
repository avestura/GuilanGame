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

    public partial class Question7: QuestionPage
    {
        public Question7()
        {
            InitializeComponent();
            HintBorder = _HintBorder;
            AnswerArea = _AnswerArea;
            QuestionArea = _QuestionArea;
        }

        public override (int Score, string Message) Evaluate()
        {
            if (Chk3.IsChecked == true)
            {
                return (!HintUsed) ?
                    (80, "مرسی به دقتت!") :
                    (40, "مرسی به دقتت!");

            }
            else if (Chk1.IsChecked == true)
            {
                return (0, "هیچی؟ خالیه خالی؟ (:");
            }
            else
            {
                return (0, "گزینه وسوسه برانگیزی بود نه؟ ^_^");
            }

        }
    }
}
