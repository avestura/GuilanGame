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

    public partial class Question5: QuestionPage
    {
        public Question5()
        {
            InitializeComponent();
            HintBorder = _HintBorder;
            AnswerArea = _AnswerArea;
            QuestionArea = _QuestionArea;
        }

        public override (int Score, string Message) Evaluate()
        {
            if (Chk2.IsChecked == true)
            {
                return (!HintUsed) ?
                    (50, "احسنت!") :
                    (20, "احنست!");

            }
            else
            {
                return (0, "به فرهنگ باشد روان تندست!");
            }

        }
    }
}
