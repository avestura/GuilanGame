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

    public partial class Question3: QuestionPage
    {
        public Question3()
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
                    (60, "جوابت کاملا درست بود (: ما هممون ارادت خاصی به در فنی داریم") :
                    (30, "جوابت کاملا درست بود (: ما هممون ارادت خاصی به در فنی داریم");

            }
            else
            {
                return (0, "ایرادی نداره. بازم سوال برای جبران کردن هست (:");

            }

        }
    }
}
