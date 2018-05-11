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
    /// <summary>
    /// Interaction logic for Question1.xaml
    /// </summary>
    public partial class Question1 : QuestionPage
    {
        public Question1()
        {
            InitializeComponent();
            HintBorder = _HintBorder;
            AnswerArea = _AnswerArea;
            QuestionArea = _QuestionArea;
        }

        public override (int Score, string Message) Evaluate()
        {
            if (Input.Text.Contains("شهدا") && (Input.Text.Contains("گمنام") || Input.Text.Contains("گم نام")))
            {
                return (!HintUsed) ?
                    (50, "درسته. 50 امتیاز گرفتی. اسم این میدون شهدای گمنام هست.") :
                    (30, "درسته. 20 امتیاز گرفتی. اسم این میدون شهدای گمنام هست.");
            }
            else if (Input.Text.Contains("شهدا") || Input.Text.Contains("گمنام") || Input.Text.Contains("گم نام"))
            {
                return (!HintUsed) ?
                  (20, "اگرچه که نزدیک شدی، ولی اسم کامل این میدون «شهدای گمنام» ئه. در هر حالت ازت میپذیریم و 20 امتیاز میگیری") :
                  (10, "اگرچه که نزدیک شدی، ولی اسم کامل این میدون «شهدای گمنام» ئه. در هر حالت ازت میپذیریم و 10 امتیاز میگیری");

            }
            else if (Input.Text.Contains("شهید"))
            {
                return (!HintUsed) ?
                  (15, "اگرچه که نزدیک شدی، ولی اسم کامل این میدون «شهدای گمنام» ئه. در هر حالت ازت میپذیریم و 15 امتیاز میگیری") :
                  (5, "اگرچه که نزدیک شدی، ولی اسم کامل این میدون «شهدای گمنام» ئه. در هر حالت ازت میپذیریم و 5 امتیاز میگیری");

            }
            else
            {
                return (0, "متاسفم ولی اسم میدون «شهدای گمنام» هست");
            }
        }
    }
}
