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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestVerktygLib;
using static TestVerktygLib.UtilityTestVerktyg;

namespace StudentTestVerktyg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        private Quiz _selectedQuiz;

        public Quiz SelectedQuiz
        {
            get { return _selectedQuiz; }
            set
            {
                if (value != null)
                {
                    _selectedQuiz = value;
                    SelectedQuizId = value.Id;
                    UtilityTestVerktyg.SelectedQuiz = value;
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            grid_loggedin.Visibility = Visibility.Hidden;

            QuizGrid.DataContext = this;
            
        }

        private void btn_TakeQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (UtilityTestVerktyg.SelectedQuiz != null)
            {
                
                var quizWin = new QuizWindow();
                quizWin.Closed += QuizQindowClosed;
                quizWin.Show();
            }
        }

        private void QuizQindowClosed(object sender, EventArgs e)
        {
            UtilityTestVerktyg.SelectedQuiz = null;

            if (!Repo.DoesGradeExcist(SelectedQuizId,LoggedInUserId))
            {

                MessageBox.Show(CurrentPoints.Sum().ToString());
                Quizzes.Remove(UtilityTestVerktyg.SelectedQuiz);

                var userGrade = new Grade
                {
                    CompletionDate = DateTime.Now,
                    QuizId = SelectedQuizId,
                    UserId = LoggedInUserId,
                    UserScore = CurrentPoints.Sum(),
                    UserGrade = (CurrentPoints.Sum() > QuizLength / 2) ? "G" : "IG"

                };
                Repo.SaveUserQuizScore(userGrade);
            }
            
        }

        private void SwitchScreen()
        {
            grid_loggedin.Visibility = Visibility.Visible;
            grd_loginscreen.Visibility = Visibility.Hidden;
        }


        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_inloggEmail.Text) ||
                string.IsNullOrEmpty(tbx_login.Password))
            {

                MessageBox.Show("All fields must be filled");
            }
            else
            {
                User user = Repo.CheckEmail(tbx_inloggEmail.Text);

                if (user != null)
                {
                    if (user.Password == tbx_login.Password &&
                        user.IsAdmin == false)
                    {
                        SwitchScreen();
                        LoggedInUserId = user.Id;
                        GetQuizForUser(LoggedInUserId);
                        lv_QuizList.ItemsSource = Quizzes;
                    }
                    else
                    {
                        MessageBox.Show("Wrong password");
                    }
                }
                else
                {
                    MessageBox.Show("User doesn't excist");
                }
            }

        }
    }
}