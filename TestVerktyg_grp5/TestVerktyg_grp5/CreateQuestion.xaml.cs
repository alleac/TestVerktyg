using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestVerktygLib;

namespace TestVerktyg_grp5
{
    /// <summary>
    /// Interaction logic for CreateQuestion.xaml
    /// </summary>
    public partial class CreateQuestion : Window
    {
        Repository Repo = new Repository();

        public List<Question> Questions;
        public CreateQuestion()
        {
            InitializeComponent();

            Questions = new List<Question>();
        }

        private void cq_btn(object sender, RoutedEventArgs e)
        {
            var _nq = new Question();
            _nq.Title = q_tbx.Text;
            _nq.AnswerOne = a_one_tbx.Text;
            _nq.AnswerTwo = a_two_tbx.Text;
            _nq.AnswerThree = a_three_tbx.Text;
            _nq.AnswerFour = a_four_tbx.Text;


            if (a_one_rbn.IsChecked == true)
            {
                _nq.RightAnswer = 1;
            }
            else if (a_two_rbn.IsChecked == true)
            {
                _nq.RightAnswer = 2;
            }
            else if (a_three_rbn.IsChecked == true)
            {
                _nq.RightAnswer = 3;
            }
            else if (a_four_rbn.IsChecked == true)
            {
                _nq.RightAnswer = 4;
            }
            else
            {
                _nq.RightAnswer = 0;
            }
            _nq.QuizId = 1;

            Questions.Add(_nq);

            foreach (var item in Questions)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.AnswerOne);
                Console.WriteLine(item.AnswerTwo);
                Console.WriteLine(item.AnswerThree);
                Console.WriteLine(item.AnswerFour);
                Console.WriteLine(item.RightAnswer);

                q_tbx.Clear();
                a_one_tbx.Clear();
                a_two_tbx.Clear();
                a_three_tbx.Clear();
                a_four_tbx.Clear();
            }

            Repo.AddQuestion(_nq);
        }
    }
}
