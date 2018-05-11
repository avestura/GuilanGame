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

    public partial class Question8: QuestionPage
    {
        public Question8()
        {
            InitializeComponent();
            HintBorder = _HintBorder;
            AnswerArea = _AnswerArea;
            QuestionArea = _QuestionArea;
        }

        public override (int Score, string Message) Evaluate()
        {
            if (Chk1.IsChecked == true)
            {
                return (!HintUsed) ?
                    (80, "دقیقا درسته! اسمی از زبان روسی روی تابلو برده نشده") :
                    (40, "دقیقا درسته! اسمی از زبان روسی روی تابلو برده نشده");

            }
            else
            {
                return (0, "متاسفانه گزینه اشتباه رو انتخاب کردی");
            }

        }
    }
}
