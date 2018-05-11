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
    public partial class Question2 : QuestionPage
    {
        public Question2()
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
                    (50, "همینه! جواب درست رو گفتی. احتمالا اطراف سلف زیاد رفت و آمد میکنی (:") :
                    (20, "همینه! جواب درست رو گفتی. احتمالا اطراف سلف زیاد رفت و آمد میکنی (:");

            }
            else if (Chk2.IsChecked == true)
            {
                return (0, "پارک ممنوع؟ ایده جالبیه! ولی درست نیست (:");

            }
            else if (Chk3.IsChecked == true)
            {
                return (0, "تابلویی که انتخاب کردی رو میشه تو بعضی از بخش های دانشگاه پیدا کرد. ولی نه اینجا (:");

            }
            else if (Chk4.IsChecked == true)
            {
                return (!HintUsed) ?
                    (5, "امیدوارم اشتباه بصری نکرده باشی. تابلویی که انتخاب کردی شبیه جواب درسته، چون از راهنما استفاده نکردی، 5 امتیاز بهت میدم") :
                    (0, "امیدوارم اشتباه بصری نکرده باشی. تابلویی که انتخاب کردی شبیه جواب درسته، ولی متاسفانه امتیازی نداره. اگه از راهنما استفاده نمیکردی 5 امتیاز بهت میدادم");
            }
            else
            {
                return (0, "حنی نخواستی امتحان کنی! سخت نگیر. نمره منفی که نداره!");

            }

        }
    }
}
