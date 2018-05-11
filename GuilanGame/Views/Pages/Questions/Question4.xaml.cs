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
    public partial class Question4 : QuestionPage
    {
        public Question4()
        {
            InitializeComponent();
            HintBorder = _HintBorder;
            AnswerArea = _AnswerArea;
            QuestionArea = _QuestionArea;
        }

        public override (int Score, string Message) Evaluate()
        {

            if (Word.Text == "mitsubishi" || Word.Text == "mitcubishi" || Word.Text == "میتسوبیشی" || Word.Text == "میتصبیشی" ||
                    Word.Text == "mitsobishi" || Word.Text == "mitcobishi" || Word.Text == "میتسبیشی" || Word.Text == "میتصوبیشی" ||
                    Word.Text == "میتثوبیشی" || (Word.Text.Contains("m") && Word.Text.Contains("bishi")))
            {

                return (!HintUsed) ?
                    (80, "درسته. تو 80 امتیاز رو برای خودت کردی!.") :
                    (30, "درسته. تو 30 امتیاز رو برای خودت کردی!.");

            }

            return (0, "عبارت روی ماشین «Mitsubishi» هست و متاسفانه بهت امتیازی تعلق نمیگیره");

        }
    }
}
