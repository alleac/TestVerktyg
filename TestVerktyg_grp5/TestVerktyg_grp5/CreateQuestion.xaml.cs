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

        public List<Question> Questions;
        public CreateQuestion()
        {
            InitializeComponent();

            Questions = new List<Question>();
        }

        private void cq_btn(object sender, RoutedEventArgs e)
        {
            var _nq = new Question();

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

            var textBoxes = new TextBox[] { q_tbx, a_one_tbx, a_two_tbx, a_three_tbx, a_four_tbx };
            var radioButtons = new RadioButton[] { a_one_rbn, a_two_rbn, a_three_rbn, a_four_rbn };

            if (textBoxes.Any(tb => tb.Text == String.Empty))
            {
                MessageBox.Show("All fields must be filled");
            }
            else if (radioButtons.Any(rb => rb.IsChecked.Value == true))
            {
                _nq.Title = q_tbx.Text;
                _nq.AnswerOne = a_one_tbx.Text;
                _nq.AnswerTwo = a_two_tbx.Text;
                _nq.AnswerThree = a_three_tbx.Text;
                _nq.AnswerFour = a_four_tbx.Text;

                _nq.QuestionNumber = UtilityTestVerktyg.CreateQuestionNumber++;
                Questions.Add(_nq);
                UtilityTestVerktyg.QuizQuestions.Add(_nq);

                this.Close();
            }
            else
            {
                MessageBox.Show("All fields must be filled");
            }

            foreach (var item in Questions)
            {
                q_tbx.Clear();
                a_one_tbx.Clear();
                a_two_tbx.Clear();
                a_three_tbx.Clear();
                a_four_tbx.Clear();
            }
        }
    }
}
