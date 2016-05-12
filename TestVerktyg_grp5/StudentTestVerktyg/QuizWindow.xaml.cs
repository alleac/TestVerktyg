using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using TestVerktygLib;
using static TestVerktygLib.UtilityTestVerktyg;

namespace StudentTestVerktyg
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window, INotifyPropertyChanged
    {
        private Repository repo { get; set; } = new Repository();
        public int QuizLengthNumber { get; set; }
        public List<Question> Questions { get; set; }

        private int time { get; set; }
        private DispatcherTimer _timer { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private Question _question;
        public Question Question
        {
            get
            { return _question; }

            set
            {
                _question = value;
                NotifyPropertyChanged(nameof(Question));

            }
        }

        public QuizWindow()
        {
            InitializeComponent();

            SelectedQuestionNumber = 0;

            Questions = new List<Question>(repo.GetQuestionsForQuiz(SelectedQuizId));
            CurrentQuizQuestions = new List<Question>(Questions);
            QuizLength = Questions.Count();
            CurrentPoints = new int[QuizLength];

            Question = Questions[SelectedQuestionNumber];
            QuizLengthNumber = UtilityTestVerktyg.QuizLength;
            QuizWindowGrid.DataContext = this;

            time = SelectedQuiz.TimeToComplete * 60;

            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            TimeSpan newTime = TimeSpan.FromSeconds(time);

            if (time > 0)
            {
                if (time < 60)
                {
                    if (time%2 == 0)
                    {
                        tb_Timer.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        tb_Timer.Foreground = new SolidColorBrush(Colors.White);
                    }
                }
                time--;
                tb_Timer.FontSize = 25;
                tb_Timer.Text = newTime.ToString(@"mm\:ss");
            }
            else
            {
                _timer.Stop();
                MessageBox.Show("Time's up");
                Close();
            }
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            Question = Questions[SelectedQuestionNumber - 1];
            SelectedQuestionNumber--;

            StudentAnsweredQuestion();

            if (SelectedQuestionNumber == 0)
                btn_Back.Visibility = Visibility.Hidden;

            if (SelectedQuestionNumber + 1 < QuizLength)
            { 
                btn_Forward.Visibility = Visibility.Visible;
                btn_FinnishQuiz.Visibility = Visibility.Hidden;
            }
        }

        private void btn_Forward_Click(object sender, RoutedEventArgs e)
        {

            Question = Questions[SelectedQuestionNumber + 1];
            SelectedQuestionNumber++;

            StudentAnsweredQuestion();

            if (SelectedQuestionNumber > 0)
                btn_Back.Visibility = Visibility.Visible;

            if (SelectedQuestionNumber + 1 == QuizLength)
            {
                btn_Forward.Visibility = Visibility.Hidden;
                btn_FinnishQuiz.Visibility = Visibility.Visible;
            }
        }

        private void NotifyPropertyChanged(String prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void Rbone_Checked(object sender, RoutedEventArgs e)
        {
            CurrentQuizQuestions[SelectedQuestionNumber].HasAnsweredNumber = 1;

            if (CurrentQuizQuestions[SelectedQuestionNumber].RightAnswer == 1)
                CurrentPoints[SelectedQuestionNumber] = 1;
            else
                CurrentPoints[SelectedQuestionNumber] = 0;
        }

        private void Rbtwo_Checked(object sender, RoutedEventArgs e)
        {
            CurrentQuizQuestions[SelectedQuestionNumber].HasAnsweredNumber = 2;

            if (CurrentQuizQuestions[SelectedQuestionNumber].RightAnswer == 2)
                CurrentPoints[SelectedQuestionNumber] = 1;
            else
                CurrentPoints[SelectedQuestionNumber] = 0;
        }

        private void Rbthree_Checked(object sender, RoutedEventArgs e)
        {
            CurrentQuizQuestions[SelectedQuestionNumber].HasAnsweredNumber = 3;

            if (CurrentQuizQuestions[SelectedQuestionNumber].RightAnswer == 3)
                CurrentPoints[SelectedQuestionNumber] = 1;
            else
                CurrentPoints[SelectedQuestionNumber] = 0;
        }

        private void Rbfour_Checked(object sender, RoutedEventArgs e)
        {
            CurrentQuizQuestions[SelectedQuestionNumber].HasAnsweredNumber = 4;

            if (CurrentQuizQuestions[SelectedQuestionNumber].RightAnswer == 4)
                CurrentPoints[SelectedQuestionNumber] = 1;
            else
                CurrentPoints[SelectedQuestionNumber] = 0;
        }
        private void StudentAnsweredQuestion()
        {
            Rbone.IsChecked = false; Rbtwo.IsChecked = false; Rbthree.IsChecked = false; Rbfour.IsChecked = false;
            switch (CurrentQuizQuestions[SelectedQuestionNumber].HasAnsweredNumber)
            {
                case 1:
                    Rbone.IsChecked = true;
                    break;
                case 2:
                    Rbtwo.IsChecked = true;
                    break;
                case 3:
                    Rbthree.IsChecked = true;
                    break;
                case 4:
                    Rbfour.IsChecked = true;
                    break;
                default:
                    break;
            }
        }

        private void btn_FinnishQuiz_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan testDuration = TimeSpan.FromSeconds((SelectedQuiz.TimeToComplete * 60) - time);

            MessageBox.Show(CurrentPoints.Sum().ToString());
            UtilityTestVerktyg.Quizzes.Remove(UtilityTestVerktyg.SelectedQuiz);
            var userGrade = new Grade
            {
                CompletionDate = DateTime.Now,
                QuizId = SelectedQuizId,
                UserId = LoggedInUserId,
                UserScore = CurrentPoints.Sum(),
                UserGrade = (CurrentPoints.Sum() > QuizLength / 2) ? "G" : "IG",
                TimeToComplete = testDuration.ToString(@"mm\:ss")
                

            };

            _timer.Stop();
            Repo.SaveUserQuizScore(userGrade);
            this.Close();
        }
    }
}
